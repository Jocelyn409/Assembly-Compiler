using AssemblerComponents;

namespace TestClasses 
{
    public class AssemblyTest 
    {
        public static void RunTests() 
        {
            TestAssemble();
        }

        public static void TestAssemble() 
        {
            String[] test = new String[1] {"SAL R1 32"};
            Console.WriteLine(Assembler.Assemble(test)[0]);
        }

    }
}