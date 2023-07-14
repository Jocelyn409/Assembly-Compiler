namespace AssemblerComponents 
{
    public class Assembler 
    {
        public static String CheckRegValue(String InputStr, int CheckInstr) 
        {
            if(CheckInstr <= 1) {
                return InputStr switch
                {
                    "R0"    => "0000",
                    "R1"    => "0001",
                    "R2"    => "0010",
                    "R3"    => "0011",
                    "R4"    => "0100",
                    "R5"    => "0101",
                    "R6"    => "0110",
                    "R7"    => "0111",
                    "R8"    => "1000",
                    "R9"    => "1001",
                    "R10"   => "1010",
                    "R11"   => "1011",
                    "R12"   => "1100",
                    "R13"   => "1101",
                    "R14"   => "1110",
                    "R15"   => "1111",
                    _ => throw new Exception("Invalid register \"" + InputStr + "\" in instruction")
                };
            }
            else if(CheckInstr >= 1 && int.TryParse(InputStr, out int OutputInt)) 
            {
                int Factor = 128;
                char[] OutputBits = new char[8] {'0', '0', '0', '0', '0', '0', '0', '0',};
                if(OutputInt < 0) {
                    OutputBits[0] = '1';
                    OutputInt *= -1;
                }
                for(int i = 1; i <= 7; i++) 
                {
                    if(OutputInt >= Factor) 
                    {
                        OutputInt -= Factor;
                        OutputBits[i-1] = '1';
                    }
                    Factor /= 2;
                }
                return new string(OutputBits);
            }
            else 
            {
                throw new Exception("");
            }
        }

        public static String[] Assemble(String[] InputStrings) 
        {
            String[] BitPatterns = new String[InputStrings.Length];
            for(int i = 0; i <= InputStrings.Length-1; i++) 
            {
                String[] Instr = InputStrings[i].ToUpper().Split();
                BitPatterns[i] = Instr[0] switch
                {
                    "AND"       => "1000" + CheckRegValue(Instr[1], 0) + CheckRegValue(Instr[2], 0) + CheckRegValue(Instr[3], 0),
                    "OR"        => "1001" + CheckRegValue(Instr[1], 0) + CheckRegValue(Instr[2], 0) + CheckRegValue(Instr[3], 0),
                    "XOR"       => "1010" + CheckRegValue(Instr[1], 0) + CheckRegValue(Instr[2], 0) + CheckRegValue(Instr[3], 0),
                    "NOT"       => "1011" + CheckRegValue(Instr[1], 0) + "00000000",

                    "SAL"       => "1100" + CheckRegValue(Instr[1], 0) + CheckRegValue(Instr[2], 2),
                    "SAR"       => "1101" + CheckRegValue(Instr[1], 0) + CheckRegValue(Instr[2], 2),

                    "ADD"       => "1110" + CheckRegValue(Instr[1], 1) + CheckRegValue(Instr[2], 1) + CheckRegValue(Instr[3], 0),
                    "SUB"       => "1111" + CheckRegValue(Instr[1], 1) + CheckRegValue(Instr[2], 1) + CheckRegValue(Instr[3], 0),
                    "MUL"       => "0111" + CheckRegValue(Instr[1], 1) + CheckRegValue(Instr[2], 1) + CheckRegValue(Instr[3], 0),

                    "HALT"      => "0000000000000000",
                    "MOVE"      => "0001" + CheckRegValue(Instr[1], 0) + CheckRegValue(Instr[2], 2),
                    "INTERRUPT" => "001000000000000" + Instr[Instr.Length-1],
                    "JUMP"      => "0011000000000100", // needs 12 bits more
                    "COMPARE"   => "01000000", // 8 bits more
                    "BRANCH"    => "0101",
                    _ => throw new Exception("Invalid mnemonic \"" + Instr[0] + "\" in instruction."),
                };
            }
            return BitPatterns;
        }

    }
}