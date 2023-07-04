using BitComponents;
using LongwordComponents;

namespace HelperFunctionComponents
{
    public class HelperFunctions
    {
        // Extract bits.
        public static Longword MaskerAND(Longword A, int MaskFrom, int MaskUntil) 
        {
            Longword MaskedLongword = new(0);
            for(int i = MaskFrom; i <= MaskUntil; i++) 
            {
                MaskedLongword.SetBit(i, A.GetBit(i));
            }
            return MaskedLongword;
        }

        // Set bits.
        public static Longword MaskerOR(Longword A, int MaskFrom, int MaskUntil) 
        {
            Longword MaskedLongword = A;
            for(int i = MaskFrom; i <= MaskUntil; i++) 
            {
                MaskedLongword.SetBit(i, new Bit(1));
            }
            return MaskedLongword;
        }

        // Toggle bits.
        public static Longword MaskerXOR(Longword A, int MaskFrom, int MaskUntil) 
        {
            Longword MaskedLongword = A;
            Bit MaskerBit;
            for(int i = MaskFrom; i <= MaskUntil; i++) 
            {
                MaskerBit = A.GetBit(i);
                MaskerBit.Toggle();
                MaskedLongword.SetBit(i, MaskerBit);
            }
            return MaskedLongword;
        }

        public static Bit[] GetLongwordSegment(Longword A, int From, int Until) 
        {
            Bit[] Segment = new Bit[Until-From+1];
            for(int i = 0, n = From; i <= Until-From; n++, i++) 
            {
                Segment[i] = A.GetBit(n);
            }
            return Segment;
        }

        public static Boolean CheckOperation(Bit[] InputOp, Bit[] OpCode) 
        {
            for(int i = 0; i < 4; i++) 
            {
                if(InputOp[i].GetValue() != OpCode[i].GetValue()) return false;
            }
            return true;
        }

    }
}