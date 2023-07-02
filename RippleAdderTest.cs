using BitComponents;
using LongwordComponents;
using RippleAdderComponents;

namespace TestClasses
{
    public class RippleAdderTest
    {
        public static void RunTests()
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
                if(i > 24)
                {
                    longwordOfRandoms[i] = new Bit(random.Next(0, 2));
                    longwordOfRandoms2[i] = new Bit(random.Next(0, 2));
                }
            }

            TestADD(new Longword(longwordOfRandoms), new Longword(longwordOfRandoms2));
            TestSUBTRACT(new Longword(longwordOfRandoms), new Longword(longwordOfRandoms2));
        }
 
        public static void TestADD(Longword A, Longword B) 
        {
            Longword answer = RippleAdder.ADD(A, B);
            Console.WriteLine(A + " | = " + A.GetSigned());
            Console.WriteLine(B + " | = " + B.GetSigned());
            Console.WriteLine("-------------------------------- +");
            Console.WriteLine(answer + " | = " + answer.GetSigned() + "\n");
        }

        public static void TestSUBTRACT(Longword A, Longword B)
        {
            Longword answer = RippleAdder.SUBTRACT(A, B);
            Console.WriteLine(A + " | = " + A.GetSigned());
            Console.WriteLine(B + " | = " + B.GetSigned());
            Console.WriteLine("-------------------------------- -");
            Console.WriteLine(answer + " | = " + answer.GetSigned());
        }
    }
}