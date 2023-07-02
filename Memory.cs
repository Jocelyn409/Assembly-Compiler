using BitComponents;
using LongwordComponents;

namespace MemoryComponents 
{
    public class Memory 
    {
        public Memory() 
        {
            for(int x = 0; x < 8192; x++) 
            {
                Storage[x] = new Bit(0);
            }
        }

        public Bit[] Storage = new Bit[8192]; // 8192 bits, 1024 bytes, or 256 longwords.

        public Longword Read(Longword Address) // Reads 2 bytes at a time.
        {
            for(int i = 0; i < 22; i++) 
            {
                Address.SetBit(i, new Bit(0));
            }
            int DecimalAdress = (int)Address.GetUnsigned();
            Bit[] TempArray = new Bit[32];
            for(int n = DecimalAdress*8, Pos = 0; n < DecimalAdress*8+16; n++, Pos++) 
            {
                TempArray[Pos] = Storage[n];
            }
            Array.Fill(TempArray, new Bit(0), 16, 16);
            return new Longword(TempArray);
        }

        public void Write(Longword Address, Longword Value) // Writes 2 bytes at a time.
        {
            for(int i = 0; i < 22; i++) 
            {
                Address.SetBit(i, new Bit(0));
            }
            int DecimalAdress = (int)Address.GetUnsigned();
            for(int n = DecimalAdress*8, Pos = 0; n < DecimalAdress*8+16; n++, Pos++) 
            {
                Storage[n] = Value.GetBit(Pos);
            }
        }

    }
}