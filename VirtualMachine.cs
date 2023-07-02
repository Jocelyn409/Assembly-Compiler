using TestClasses;
using MemoryComponents;

class VirtualMachine
{
    static void Main(string[] args)
    {
        //BitTest.RunTests();
        //LongwordTest.RunTests();
        //RippleAdderTest.RunTests();
        //MultiplierTest.RunTests();
        //ALUTest.RunTests();
        MemoryTest memoryTest = new();
        memoryTest.RunTests();
        //ComputerTest.RunTests();
    }
}