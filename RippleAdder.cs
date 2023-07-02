using BitComponents;
using LongwordComponents;

namespace RippleAdderComponents
{
    public class RippleAdder
    {
        public static Longword RippleCarryAdderSubtractor(Longword A, Longword B, Bit C_in) {
            Bit BitPositionA, BitPositionB, FirstXOR, Sum, Carry = C_in;
            Longword Answer = new();

            for(int i = 31; i >= 0; i--) 
            {
                // Ripple adder/subtractor logic //////////////////////////////////////
                BitPositionA = A.GetBit(i);                                          //
                BitPositionB = B.GetBit(i).XOR(C_in);                                //
                // Full adder logic //////////////////////////////////////////////   //
                FirstXOR = BitPositionA.XOR(BitPositionB);                      //   //
                Sum = FirstXOR.XOR(Carry);                                      //   //
                Carry = BitPositionA.AND(BitPositionB).OR(FirstXOR.AND(Carry)); //   //
                //////////////////////////////////////////////////////////////////   //
                Answer.SetBit(i, Sum);                                               //
                ///////////////////////////////////////////////////////////////////////
            }
            return Answer;
        }
        public static Longword ADD(Longword A, Longword B) 
        {
            return RippleCarryAdderSubtractor(A, B, new Bit(0));
        }
        
        public static Longword SUBTRACT(Longword A, Longword B)
        {
            return RippleCarryAdderSubtractor(A, B, new Bit(1));
        }

    }
}