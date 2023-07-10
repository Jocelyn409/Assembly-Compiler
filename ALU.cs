using BitComponents;
using LongwordComponents;
using RippleAdderComponents;
using MultiplierComponents;
using HelperFunctionComponents;

namespace ALUComponents 
{
    public class ALU 
    {
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

            if(HelperFunctions.CheckOperation(Operation, AND_OP)) return A.AND(B);
            else if(HelperFunctions.CheckOperation(Operation, OR_OP)) return A.OR(B);
            else if(HelperFunctions.CheckOperation(Operation, XOR_OP)) return A.XOR(B);
            else if(HelperFunctions.CheckOperation(Operation, NOT_OP)) return A.NOT(); // B value is ignored.
            else if(HelperFunctions.CheckOperation(Operation, LEFT_SHIFT_OP))
            {
                return A.LeftShift(HelperFunctions.MaskerAND(B, 27, 31).GetSigned());
            }
            else if(HelperFunctions.CheckOperation(Operation, RIGHT_SHIFT_OP))
            {
                return A.RightShift(HelperFunctions.MaskerAND(B, 27, 31).GetSigned());
            }
            else if(HelperFunctions.CheckOperation(Operation, ADD_OP)) return RippleAdder.ADD(A, B);
            else if(HelperFunctions.CheckOperation(Operation, SUBTRACT_OP)) return RippleAdder.SUBTRACT(A, B);
            else if(HelperFunctions.CheckOperation(Operation, MULTIPLY_OP)) return Multiplier.MULTIPLY(A, B);
            else throw new Exception("--- INVALID INPUT FOR ALU OPERATOR BITS ---");

	    }
    }
}