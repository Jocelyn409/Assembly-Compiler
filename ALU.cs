using BitComponents;
using LongwordComponents;
using RippleAdderComponents;
using MultiplierComponents;
using HelperFunctionComponents;

namespace ALUComponents 
{
    public class ALU 
    {
        public static Boolean CheckOperation(Bit[] InputOp, Bit[] OpCode) 
        {
            for(int i = 0; i < 4; i++) 
            {
                if(InputOp[i].GetValue() != OpCode[i].GetValue()) return false;
            }
            return true;
        }

	    public static Longword DoOperation(Bit[] Operation, Longword A, Longword B)
	    {
            Bit[] AND_OP =          new Bit[4] {new Bit(1), new Bit(0), new Bit(0), new Bit(0)};
            Bit[] OR_OP =           new Bit[4] {new Bit(1), new Bit(0), new Bit(0), new Bit(1)};
            Bit[] XOR_OP =          new Bit[4] {new Bit(1), new Bit(0), new Bit(1), new Bit(0)};
            Bit[] NOT_OP =          new Bit[4] {new Bit(1), new Bit(0), new Bit(1), new Bit(1)};
            Bit[] LEFT_SHIFT_OP =   new Bit[4] {new Bit(1), new Bit(1), new Bit(0), new Bit(0)};
            Bit[] RIGHT_SHIFT_OP =  new Bit[4] {new Bit(1), new Bit(1), new Bit(0), new Bit(1)};
            Bit[] ADD_OP =          new Bit[4] {new Bit(1), new Bit(1), new Bit(1), new Bit(0)};
            Bit[] SUBTRACT_OP =     new Bit[4] {new Bit(1), new Bit(1), new Bit(1), new Bit(1)};
            Bit[] MULTIPLY_OP =     new Bit[4] {new Bit(0), new Bit(1), new Bit(1), new Bit(1)};
            
            Bit[] HALT_OP =         new Bit[4] {new Bit(0), new Bit(0), new Bit(0), new Bit(0)};
            Bit[] MOVE_OP =         new Bit[4] {new Bit(0), new Bit(0), new Bit(0), new Bit(1)};
            Bit[] INTERRUPT_OP =    new Bit[4] {new Bit(0), new Bit(0), new Bit(1), new Bit(0)};
            Bit[] JUMP_OP =         new Bit[4] {new Bit(0), new Bit(0), new Bit(1), new Bit(1)};

            if(CheckOperation(Operation, AND_OP)) return A.AND(B);
            else if(CheckOperation(Operation, OR_OP)) return A.OR(B);
            else if(CheckOperation(Operation, XOR_OP)) return A.XOR(B);
            else if(CheckOperation(Operation, NOT_OP)) return A.NOT(); // B value is ignored.
            else if(CheckOperation(Operation, LEFT_SHIFT_OP))
            {
                return A.LeftShift(HelperFunctions.MaskerAND(B, 27, 31).GetSigned());
            }
            else if(CheckOperation(Operation, RIGHT_SHIFT_OP))
            {
                return A.RightShift(HelperFunctions.MaskerAND(B, 27, 31).GetSigned());
            }
            else if(CheckOperation(Operation, ADD_OP)) return RippleAdder.ADD(A, B);
            else if(CheckOperation(Operation, SUBTRACT_OP)) return RippleAdder.SUBTRACT(A, B);
            else if(CheckOperation(Operation, MULTIPLY_OP)) return Multiplier.MULTIPLY(A, B);
            else if(CheckOperation(Operation, HALT_OP)) return new Longword(0);
            else if(CheckOperation(Operation, MOVE_OP)) return new Longword(0);
            else if(CheckOperation(Operation, INTERRUPT_OP)) return new Longword(0);
            else if(CheckOperation(Operation, JUMP_OP)) return new Longword(0);
            else throw new Exception("--- INVALID INPUT FOR ALU OPERATOR BITS ---");

	    }
    }
}