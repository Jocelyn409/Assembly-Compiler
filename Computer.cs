using BitComponents;
using LongwordComponents;
using RippleAdderComponents;
using ALUComponents;
using MemoryComponents;
using HelperFunctionComponents;

namespace ComputerComponents 
{
    public class Computer 
    {
        readonly Bit[] HALT_OP =      new Bit[4] {new Bit(0), new Bit(0), new Bit(0), new Bit(0)};
        readonly Bit[] MOVE_OP =      new Bit[4] {new Bit(0), new Bit(0), new Bit(0), new Bit(1)};
        readonly Bit[] INTERRUPT_OP = new Bit[4] {new Bit(0), new Bit(0), new Bit(1), new Bit(0)};
        readonly Bit[] JUMP_OP =      new Bit[4] {new Bit(0), new Bit(0), new Bit(1), new Bit(1)};
        readonly Bit[] COMPARE_OP =    new Bit[4] {new Bit(0), new Bit(1), new Bit(0), new Bit(0)};
        readonly Bit[] BRANCH_OP =    new Bit[4] {new Bit(0), new Bit(1), new Bit(0), new Bit(1)};
        
        private Bit HaltStatus = new(); // 1 if computer is halted, 0 if not.
        private Memory MemoryInstance = new();
        private Longword Incrementor = new(0);
        private Longword ByteCount = new(0);
        private Longword ProgramCounter = new(0);
        private Longword CurrentInstruction = new(0);
        private Longword[] Register = new Longword[16]; // reset registers before writing to them?
        private Longword Op1 = new(0), Op2 = new(0);
        int Op1Index, Op2Index;
        Bit[] OpCode = new Bit[4];
        private Longword Result = new(0);
        private Longword MoveValue = new(0);
        private Longword JumpValue = new(0);
        private Longword CR1 = new(0), CR2 = new(0); // Compare registers.
        private Bit BC1 = new(0);
        private Bit BC2 = new(0);

        public Computer() 
        {
            Incrementor.SetBit(30, new Bit(1)); // Incrementor set to 2.
            ByteCount.SetBit(30, new Bit(1)); // Number of bytes to read is 2.
        }

        public void Preload(String[] Input) 
        {
            String WriteString;
            Longword MemoryIndex = new(0), Incrementor = new(0), ByteCount = new(0);
            Incrementor.SetBit(29, new Bit(1)); // Incrementor of 1.
            ByteCount.SetBit(29, new Bit(1)); // Number of bytes to write is 4.
            for(int i = 0; i <= Input.Length-1; i+=2)
            {
                Longword WriteLongword = new(0);
                if(i >= Input.Length-1)
                {
                    WriteString = Input[i] + "0000000000000000";
                }
                else
                {
                    WriteString = Input[i] + Input[i+1];
                }

                for(int s = 0; s <= 31; s++) 
                {
                    WriteLongword.SetBit(s, new Bit(int.Parse(WriteString[s].ToString())));
                }
                /*for(int s = 0; s <= 15; s++) 
                {
                    WriteLongword.SetBit(s, new Bit(int.Parse(Input[i][s].ToString())));
                    WriteLongword.SetBit(s+16, new Bit(int.Parse(Input[i+1][s+16].ToString())));
                }*/
                MemoryInstance.Write(MemoryIndex, WriteLongword, ByteCount);
                MemoryIndex = RippleAdder.ADD(MemoryIndex, Incrementor);
            }

        }

        private void Fetch()
        { // Read 2 bytes at memory address ProgramCounter. Then increase PC by Incrementor.
            CurrentInstruction = MemoryInstance.Read(ProgramCounter, ByteCount).RightShift(16);
            ProgramCounter = RippleAdder.ADD(ProgramCounter, Incrementor);
        }

        private void Decode()
        {
            OpCode = HelperFunctions.GetLongwordSegment(CurrentInstruction, 16, 19);
            if(HelperFunctions.CheckOperation(OpCode, MOVE_OP)) 
            {
                MoveValue = HelperFunctions.MaskerAND(CurrentInstruction, 24, 31);
            }
            else if(HelperFunctions.CheckOperation(OpCode, JUMP_OP)) 
            {
                JumpValue = HelperFunctions.MaskerAND(CurrentInstruction, 20, 31);
            }
            else if(HelperFunctions.CheckOperation(OpCode, COMPARE_OP)) 
            {
                CR1 = HelperFunctions.MaskerAND(CurrentInstruction, 24, 27);
                CR2 = HelperFunctions.MaskerAND(CurrentInstruction, 28, 31);
            }
            else if(HelperFunctions.CheckOperation(OpCode, BRANCH_OP)) 
            {
                BC1 = CurrentInstruction.GetBit(20);
                BC2 = CurrentInstruction.GetBit(21);
            }
            Op1 = HelperFunctions.MaskerAND(CurrentInstruction, 20, 23).RightShift(8);
            Op2 = HelperFunctions.MaskerAND(CurrentInstruction, 24, 27).RightShift(4);
            Op1Index = Op1.GetSigned();
            Op2Index = Op2.GetSigned();
        }

        private void Execute() 
        {
            if(HelperFunctions.CheckOperation(OpCode, HALT_OP)) 
            {
                HaltStatus.Set(1);
                Console.WriteLine("Halted");
            }
            else if(HelperFunctions.CheckOperation(OpCode, MOVE_OP)) 
            {
                if(MoveValue.GetBit(24).GetValue() == 1) 
                {
                    MoveValue = HelperFunctions.MaskerOR(MoveValue, 0, 23);
                }
            }
            else if(HelperFunctions.CheckOperation(OpCode, INTERRUPT_OP)) 
            {
                if(CurrentInstruction.GetBit(31).GetValue() == 0)
                {
                    for(int i = 0; i <= 15; i++)
                    {
                        Console.WriteLine(Register[i]);
                    }
                }
                else
                {
                    for(int i = 0; i < 8192; i++) 
                    {
                        Console.Write(MemoryInstance.Storage[i]);
                    }
                    Console.WriteLine();
                }
            }
            else if(!HelperFunctions.CheckOperation(OpCode, JUMP_OP))
            {
                Result = ALU.DoOperation(OpCode, Register[Op1Index], Register[Op2Index]);
            }
        }

        private void Store() 
        {
            if(HelperFunctions.CheckOperation(OpCode, MOVE_OP)) 
            {
                Register[Op1Index] = MoveValue;
            }
            else if(HelperFunctions.CheckOperation(OpCode, JUMP_OP)) 
            {
                ProgramCounter = JumpValue;
            }
            else if(!HelperFunctions.CheckOperation(OpCode, INTERRUPT_OP))
            {
                Register
                [HelperFunctions.MaskerAND(CurrentInstruction, 28, 31).GetSigned()] 
                =  Result; // Put result of ALU operation in register.
            }
        }

        public void Run() 
        {   
            while(HaltStatus.GetValue() == 0)
            {
                Fetch();
                Decode();
                Execute();
                Store();
            }
        }

    }
}