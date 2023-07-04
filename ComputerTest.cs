using ComputerComponents;

namespace TestClasses 
{
    public class ComputerTest 
    {
        public static void RunTests() 
        {
            Test1();
        }

        public static void Test1() 
        {
            string[] input = new string[2];
            /*
            Computer cpu1 = new();
            input[0] = "0000000000000001";
            input[1] = "0000000000000000";
            cpu1.Preload(input);
            cpu1.Run();
            Console.WriteLine("End of CPU1");*/

            Computer cpu2 = new();
            input[0] = "0001001000001010";
            input[1] = "0010000000000000";
            cpu2.Preload(input);
            cpu2.Run();
            Console.WriteLine("End of CPU2");
            

            /*Computer cpu3 = new();
            input[0] = "0000000000000001";
            input[1] = "0000000000000000";
            cpu3.Preload(input);
            cpu3.Run();
            Console.WriteLine("End of CPU3");*/
        }
    }
}