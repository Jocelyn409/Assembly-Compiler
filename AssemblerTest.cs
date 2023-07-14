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
            String[] test = new String[4] {"jump 4","move R1 5","interrupt 0","halt"};
            string[] AssembledCode = Assembler.Assemble(test);
            foreach(string x in AssembledCode) 
            {
                Console.WriteLine(x);
            }
        }

    }
}