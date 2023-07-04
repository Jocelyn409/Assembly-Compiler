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
        
        private Bit HaltStatus = new(0); // 1 if computer is halted, 0 if not.
        private Memory MemoryInstance = new();
        private Longword ProgramCounter = new(0);
        private Longword CurrentInstruction = new(0);
        private Longword[] Register = new Longword[16];
        private Longword Op1 = new(0), Op2 = new(0);
        int Op1Index, Op2Index;
        Bit[] OpCode = new Bit[4];
        private Longword Result = new(0);
        private Longword MoveValue = new(0);

        private void HaltSystem() 
        {
            HaltStatus.Set(1);
            Console.WriteLine("Halted");
        }

        public void Preload(String[] Input) 
        {
            String WriteString;
            Longword WriteLongword = new(0), MemoryIndex = new(0), Incrementor = new(0);
            Incrementor.SetBit(31, new Bit(1));
            int BitValue;
            for(int i = 0; i <= Input.Length-1; i+=2) //its not adding the two arrays
            {
                if(i+1 >= Input.Length-1) 
                {
                    WriteString = Input[i] + new Longword(0).ToString();
                }
                else
                {
                    WriteString = Input[i] + Input[i+1];
                }
                for(int s = 0; s <= 31; s++) 
                {
                    BitValue = int.Parse(WriteString[s].ToString());
                    WriteLongword.SetBit(s, new Bit(BitValue));
                }
                MemoryInstance.Write(MemoryIndex, WriteLongword);
                Incrementor = RippleAdder.ADD(MemoryIndex, Incrementor);
            }
        }

        private void Fetch()
        {
            Longword Incrementor = new(0);
            Incrementor.Set(2); // set is only used for tests. change this
            CurrentInstruction =   MemoryInstance.Read(ProgramCounter).RightShift(16);
            ProgramCounter =       RippleAdder.ADD(ProgramCounter, Incrementor);
        }

        private void Decode()
        {
            OpCode = HelperFunctions.GetLongwordSegment(CurrentInstruction, 16, 19);
            if(HelperFunctions.CheckOperation(OpCode, MOVE_OP)) 
            {
                MoveValue = HelperFunctions.MaskerAND(CurrentInstruction, 24, 31);
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
                HaltSystem();
            }
            else if(HelperFunctions.CheckOperation(OpCode, MOVE_OP)) 
            {
                if(MoveValue.GetBit(24).GetValue() == 1) 
                {
                    MoveValue = HelperFunctions.MaskerOR(MoveValue, 0, 24);
                }
            }
            else if(HelperFunctions.CheckOperation(OpCode, INTERRUPT_OP)) 
            {
                if(CurrentInstruction.GetBit(31).GetValue() == 0) 
                    Console.WriteLine(Register);
                else 
                    Console.WriteLine(MemoryInstance.Storage);
            }
            else
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
                
            }
            else {
                int RegisterNumber =        HelperFunctions.MaskerAND(CurrentInstruction, 28, 31).GetSigned();
                Register[RegisterNumber] =  Result; // Put result of ALU operation in register.
            }
        }

        public void Run() 
        {   
            while(HaltStatus.GetValue() == 0) {
                Fetch();
                Decode();
                Execute();
                Store();
            }
        }

    }
}