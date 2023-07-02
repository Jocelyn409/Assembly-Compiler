using BitComponents;
using LongwordComponents;
using MultiplierComponents;

namespace TestClasses 
{
    public class MultiplierTest 
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
                longwordOfRandoms[i] = new Bit(random.Next(0, 2));
                longwordOfRandoms2[i] = new Bit(random.Next(0, 2));
            }

            TestMULTIPLY(new Longword(longwordOfRandoms), new Longword(longwordOfRandoms2));
        }

        public static void TestMULTIPLY(Longword random, Longword random2) 
        {
            Longword Answer = Multiplier.MULTIPLY(random, random2);
            Console.WriteLine(random + " | = " + random.GetSigned());
            Console.WriteLine(random2 + " | = " + random2.GetSigned());
            Console.WriteLine(Answer.ToString() + " | = " + Answer.GetSigned());
        }
        
    }
}