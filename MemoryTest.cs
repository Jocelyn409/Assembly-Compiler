using BitComponents;
using LongwordComponents;
using MemoryComponents;

namespace TestClasses 
{
    public class MemoryTest 
    {
        Memory memory = new();
        public void RunTests() 
        {
            Random random = new();
            Bit[] longwordOfZeros = new Bit[32];
            Bit[] longwordOfOnes = new Bit[32];
            Bit[] longwordOfRandoms = new Bit[32];
            Bit[] longwordOfRandoms2 = new Bit[32];
            for(int i = 0; i <= 31; i++) {
                longwordOfZeros[i] = new Bit(0);
                longwordOfOnes[i] = new Bit(1);
                longwordOfRandoms[i] = new Bit(0);
                longwordOfRandoms2[i] = new Bit(0);
                //if(i > 23) {
                    longwordOfRandoms[i] = new Bit(random.Next(0, 2));
                    longwordOfRandoms2[i] = new Bit(random.Next(0, 2));
                //}
            }

            TestWrite(new Longword(longwordOfOnes), new Longword(longwordOfRandoms));
            TestRead(new Longword(longwordOfOnes));
        }

        public void TestRead(Longword a) 
        {
            Console.WriteLine(memory.Read(a));
        }

        public void TestWrite(Longword a, Longword b) 
        {   
            memory.Write(a, b);
        }

    }
}