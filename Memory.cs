using BitComponents;
using LongwordComponents;

namespace MemoryComponents 
{
    public class Memory 
    {
        public Memory() 
        { // Initialize Storage.
            for(int x = 0; x < 8192; x++) 
            {
                Storage[x] = new Bit(0);
            }
        }

        public Bit[] Storage = new Bit[8192]; // 8192 bits, 1024 bytes, or 256 longwords.

        public Longword Read(Longword Address, Longword ByteCount) // Reads ByteCount bytes at a time.
        {
            for(int i = 0; i <= 21; i++)
            {
                Address.SetBit(i, new Bit(0)); // or just use an error instead? or a masker if not.
            }
            
            int DecimalAddress = Address.GetSigned()*8;
            int DecimalByteCount = ByteCount.GetSigned()*8+DecimalAddress;
            Longword ReturnLongword = new(0);

            for(int n = DecimalAddress, Pos = 0; n < DecimalByteCount; n++, Pos++) 
            {
                ReturnLongword.SetBit(Pos, Storage[n]);
            }
            return ReturnLongword;
        }

        public void Write(Longword Address, Longword Value, Longword ByteCount) // Writes ByteCount bytes at a time.
        {
            for(int i = 0; i <= 21; i++) 
            {
                Address.SetBit(i, new Bit(0)); // or just use an error instead? or a masker if not.
            }
            int DecimalAddress = Address.GetSigned()*8;
            int DecimalByteCount = ByteCount.GetSigned()*8+DecimalAddress;
            for(int n = DecimalAddress, Pos = 0; n < DecimalByteCount; n++, Pos++) 
            {
                Storage[n] = Value.GetBit(Pos);
            }
        }

    }
}