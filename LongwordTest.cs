using BitComponents;
using LongwordComponents;

namespace TestClasses
{
    public class LongwordTest 
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
                longwordOfRandoms[i] = new Bit(random.Next(0, 2));
                longwordOfRandoms2[i] = new Bit(random.Next(0, 2));
            }
            /*TestAND(longwordOfZeros, longwordOfOnes, longwordOfRandoms, longwordOfRandoms2);
            TestOR(longwordOfZeros, longwordOfOnes, longwordOfRandoms, longwordOfRandoms2);
            TestXOR(longwordOfZeros, longwordOfOnes, longwordOfRandoms, longwordOfRandoms2);
            TestNOT(longwordOfZeros, longwordOfOnes);*/
            TestLeftShift(longwordOfOnes);
            TestRightShift(longwordOfOnes);
            /*TestGetUnsigned(longwordOfRandoms);
            TestGetSigned(longwordOfRandoms);
            TestSet(longwordOfOnes);*/
        }

        public static void TestAND(Bit[] zeros, Bit[] ones, Bit[] randoms, Bit[] randoms2)
        {
            Console.WriteLine(new Longword(zeros).AND(new Longword(zeros)).ToString());
            Console.WriteLine(new Longword(ones).AND(new Longword(ones)).ToString());
            Console.WriteLine(new Longword(randoms).ToString());
            Console.WriteLine(new Longword(randoms2).ToString());
            Console.WriteLine(new Longword(randoms).AND(new Longword(randoms2)).ToString());
            Console.WriteLine("AND testing complete\n");
        }

        public static void TestOR(Bit[] zeros, Bit[] ones, Bit[] randoms, Bit[] randoms2)
        {
            Console.WriteLine(new Longword(zeros).OR(new Longword(zeros)).ToString());
            Console.WriteLine(new Longword(ones).OR(new Longword(ones)).ToString());
            Console.WriteLine(new Longword(randoms).ToString());
            Console.WriteLine(new Longword(randoms2).ToString());
            Console.WriteLine(new Longword(randoms).OR(new Longword(randoms2)).ToString());
            Console.WriteLine("OR testing complete\n");
        }

        public static void TestXOR(Bit[] zeros, Bit[] ones, Bit[] randoms, Bit[] randoms2)
        {
            Console.WriteLine(new Longword(zeros).XOR(new Longword(zeros)).ToString());
            Console.WriteLine(new Longword(ones).XOR(new Longword(ones)).ToString());
            Console.WriteLine(new Longword(randoms).ToString());
            Console.WriteLine(new Longword(randoms2).ToString());
            Console.WriteLine(new Longword(randoms).XOR(new Longword(randoms2)).ToString());
            Console.WriteLine("XOR testing complete\n");
        }
        
        public static void TestNOT(Bit[] zeros, Bit[] ones) 
        {
            Console.WriteLine(new Longword(zeros).NOT());
            Console.WriteLine(new Longword(ones).NOT());
            Console.WriteLine("NOT testing complete\n");
        }

        public static void TestLeftShift(Bit[] ones) 
        {
            Console.WriteLine(new Longword(ones));
            Console.WriteLine(new Longword(ones).LeftShift(1).ToString());
            Console.WriteLine(new Longword(ones).LeftShift(3).ToString());
            Console.WriteLine("LeftShift testing complete\n");
        }

        public static void TestRightShift(Bit[] ones) 
        {
            Console.WriteLine(new Longword(ones));
            Console.WriteLine(new Longword(ones).RightShift(1).ToString());
            Console.WriteLine(new Longword(ones).RightShift(3).ToString());
            Console.WriteLine("RightShift testing complete\n");
        }

        public static void TestGetUnsigned(Bit[] randoms) 
        {
            /*Bit[] negativeOne = new Bit[32] {new Bit(1), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0),
            new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), 
            new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), 
            new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(1)};
            Console.WriteLine("Before unsigned conversion: " + new Longword(negativeOne).ToString());
            Console.WriteLine(new Longword(negativeOne).GetUnsigned().ToString());*/

            Console.WriteLine("Before unsigned conversion: " + new Longword(randoms).ToString());
            Console.WriteLine(new Longword(randoms).GetUnsigned().ToString());
            Console.WriteLine("GetUnsigned testing complete\n");
        }

        public static void TestGetSigned(Bit[] randoms) 
        {
            /*Bit[] negativeOne = new Bit[32] {new Bit(1), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0),
            new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), 
            new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), 
            new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0), new Bit(0)};
            Console.WriteLine("Before signed conversion: " + new Longword(negativeOne).ToString());
            Console.WriteLine(new Longword(negativeOne).GetSigned().ToString());*/

            Console.WriteLine("Before signed conversion:   " + new Longword(randoms).ToString());
            Console.WriteLine(new Longword(randoms).GetSigned().ToString());
            Console.WriteLine("GetSigned testing complete\n");
            
        }

        public static void TestSet(Bit[] ones)
        {
            Longword testSet = new(ones);
            testSet.Set(-33);
            Console.WriteLine(testSet.ToString());
            testSet.Set(0);
            Console.WriteLine(testSet.ToString());
            testSet.Set(453408913);
            Console.WriteLine(testSet.ToString());
            testSet.Set(-0);
            Console.WriteLine(testSet.ToString());
            testSet.Set(-1434320);
            Console.WriteLine(testSet.ToString());
        }

    }
}