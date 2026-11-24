#pragma warning disable IDE0090
#pragma warning disable IDE0028

using System.Diagnostics.CodeAnalysis;

namespace _6502_Disassmbler {
    static class Program {
        static void Main() {
            InstructionSet instructionSet = new InstructionSet();

            Console.WriteLine(instructionSet.Lookup[0xEA].Mnemonic);

            string FilePath = "";
            string ExportPath = "";
            List<byte> FileBinary = new List<byte>();
            bool running = true;
            while (running) {
                Console.WriteLine("Enter an Option:\n" +
                "1 - Set File Path\n" +
                "2 - Load File into Memory\n" +
                "3 - Set ASM Export Path\n" +
                "4 - Export Assembly\n" +
                "5 - Exit");
                string input = Console.ReadLine() ?? "";

                switch (input) {
                    case "1":
                        Console.Write("Enter the Path of the File: ");
                        FilePath = Console.ReadLine() ?? "";
                        break;
                        
                    case "2":
                        if (!File.Exists(FilePath)) {
                            Console.WriteLine("Invalid File Path!");
                            break;
                        }
                        BinaryReader reader = new BinaryReader(File.Open(FilePath, FileMode.Open));
                        FileBinary.Clear();

                        for (int i = 0; i < reader.BaseStream.Length; i++) {
                            FileBinary.Add(reader.ReadByte());
                        }
                        reader.Close();
                        Console.WriteLine("File Loaded Sucessfully!");
                        break;

                    case "3":
                        Console.Write("Enter the Path of the Export File: ");
                        ExportPath = Console.ReadLine() ?? "";
                        break;

                    case "4":
                        break;
                    
                    case "5":
                        running = false;
                        break;
                }
                Console.WriteLine();
            }
        }

        static void ExportASM(string ExportPath, ref List<byte> FileBinary) {
            ushort ResetVector = GetResetVector(ref FileBinary);

        }

        static ushort GetResetVector(ref List<byte> FileBinary) {
            
            return 0x8000;
        }


        static string FormatOperand(ushort Operand, string AddressMode) {
            switch (AddressMode)
            {
                case "Implied":
                    return "";
                case "Accumulator":
                    return "A";
                case "Immediate":
                    return $"#{Operand.ToString("X2")}";
                case "ZeroPage":
                    return $"${Operand.ToString("X2")}";
                case "ZeroPageX":
                    return $"${Operand.ToString("X2")},X";
                case "ZeroPageY":
                    return $"${Operand.ToString("X2")},Y";
                case "Absolute":
                    return $"${Operand.ToString("X4")}";
                case "AbsoluteX":
                    return $"${Operand.ToString("X4")},X";
                case "AbsoluteY":
                    return $"${Operand.ToString("X4")},Y";
                case "Indirect":
                    return $"(${Operand.ToString("X4")})";
                case "IndexedIndirect":
                    return $"(${Operand.ToString("X2")},X)";
                case "IndirectIndexed":
                    return $"(${Operand.ToString("X2")}),Y";
                case "Relative":
                    return $"${Operand.ToString("X4")}";
            }
            throw new Exception("Invalid Addressing Mode in FormatOperand()!");
        }
    }
}