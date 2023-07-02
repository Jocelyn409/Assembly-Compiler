using BitComponents;

namespace TestClasses
{
    public class BitTest
    {
        public static void RunTests() 
        {
            TestAND();
            TestOR();
            TestXOR();
            TestNOT();
        }

        public static void TestAND()
        {
            if(new Bit(0).AND(new Bit(0)).GetValue() != 0) throw new Exception("0 AND 0 failed");
            if(new Bit(0).AND(new Bit(1)).GetValue() != 0) throw new Exception("0 AND 1 failed");
            if(new Bit(1).AND(new Bit(0)).GetValue() != 0) throw new Exception("1 AND 0 failed");
            if(new Bit(1).AND(new Bit(1)).GetValue() != 1) throw new Exception("1 AND 1 failed");
            Console.WriteLine("AND testing successful");

            if(new Bit(0).AND(new Bit(0), new Bit(0), new Bit(0)).GetValue() != 0) throw new Exception("Variadic 0 AND failed");
            if(new Bit(0).AND(new Bit(0), new Bit(1), new Bit(0)).GetValue() != 0) throw new Exception("Variadic 0 AND 1 failed");
            if(new Bit(1).AND(new Bit(1), new Bit(1), new Bit(1)).GetValue() != 1) throw new Exception("Variadic 1 AND failed");
            Console.WriteLine("AND (Variadic) testing successful");
        }

        public static void TestOR() 
        {
            if(new Bit(0).OR(new Bit(0)).GetValue() != 0) throw new Exception("0 OR 0 failed");
            if(new Bit(0).OR(new Bit(1)).GetValue() != 1) throw new Exception("0 OR 1 failed");
            if(new Bit(1).OR(new Bit(0)).GetValue() != 1) throw new Exception("1 OR 0 failed");
            if(new Bit(1).OR(new Bit(1)).GetValue() != 1) throw new Exception("1 OR 1 failed");
            Console.WriteLine("OR testing successful");

            if(new Bit(0).OR(new Bit(0), new Bit(0), new Bit(0)).GetValue() != 0) throw new Exception("Variadic 0 OR failed");
            if(new Bit(1).OR(new Bit(0), new Bit(1), new Bit(0)).GetValue() != 1) throw new Exception("Variadic 1 OR 0 failed");
            if(new Bit(1).OR(new Bit(1), new Bit(1), new Bit(1)).GetValue() != 1) throw new Exception("Variadic 1 OR failed");
            Console.WriteLine("OR (Variadic) testing successful");
        }

        public static void TestXOR() 
        {
            if(new Bit(0).XOR(new Bit(0)).GetValue() != 0) throw new Exception("0 XOR 0 failed");
            if(new Bit(0).XOR(new Bit(1)).GetValue() != 1) throw new Exception("0 XOR 1 failed");
            if(new Bit(1).XOR(new Bit(0)).GetValue() != 1) throw new Exception("1 XOR 0 failed");
            if(new Bit(1).XOR(new Bit(1)).GetValue() != 0) throw new Exception("1 XOR 1 failed");
            Console.WriteLine("XOR testing successful");

            if(new Bit(0).XOR(new Bit(0), new Bit(0), new Bit(0)).GetValue() != 0) throw new Exception("Variadic 0 XOR failed");
            if(new Bit(1).XOR(new Bit(0), new Bit(1), new Bit(0)).GetValue() != 1) throw new Exception("Variadic 1 XOR 0 failed");
            if(new Bit(1).XOR(new Bit(1), new Bit(1), new Bit(1)).GetValue() != 0) throw new Exception("Variadic 1 XOR failed");
            Console.WriteLine("XOR (Variadic) testing successful");
        }

        public static void TestNOT() 
        {
            if(new Bit(0).NOT().GetValue() != 1) throw new Exception("NOT 0 failed");
            if(new Bit(1).NOT().GetValue() != 0) throw new Exception("NOT 1 failed");
            Console.WriteLine("NOT testing successful\n");
        }
        
    }
}
