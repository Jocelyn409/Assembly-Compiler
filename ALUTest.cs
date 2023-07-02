using ALUComponents;
using BitComponents;
using LongwordComponents;

namespace TestClasses 
{
    public class ALUTest 
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
                if(i > 25) {
                    longwordOfRandoms[i] = new Bit(random.Next(0, 2));
                    longwordOfRandoms2[i] = new Bit(random.Next(0, 2));
                }
            }

            TestDoOperation(new Longword(longwordOfRandoms), new Longword(longwordOfRandoms2));
        }

        public static void TestDoOperation(Longword A, Longword B) 
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
            
            Console.WriteLine(A + " | " + A.GetSigned());
            Console.WriteLine(B + " | " + B.GetSigned());
            Console.WriteLine("---------------------------------|");
            Console.WriteLine(ALU.DoOperation(AND_OP, A, B) + " | AND");
            Console.WriteLine(ALU.DoOperation(OR_OP, A, B) + " | OR");
            Console.WriteLine(ALU.DoOperation(XOR_OP, A, B) + " | XOR");
            Console.WriteLine(ALU.DoOperation(NOT_OP, A, B) + " | NOT");
            Console.WriteLine(ALU.DoOperation(LEFT_SHIFT_OP, A, B) + " | LEFT_SHIFT");
            Console.WriteLine(ALU.DoOperation(RIGHT_SHIFT_OP, A, B) + " | RIGHT_SHIFT");
            Console.WriteLine(ALU.DoOperation(ADD_OP, A, B) + " | ADD");
            Console.WriteLine(ALU.DoOperation(SUBTRACT_OP, A, B) + " | SUBTRACT");
            Console.WriteLine(ALU.DoOperation(MULTIPLY_OP, A, B) + " | MULTIPLY");
        }
    }
}