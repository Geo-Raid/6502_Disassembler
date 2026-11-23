#pragma warning disable IDE0161 // Or IDE0160
#pragma warning disable IDE0090
#pragma warning disable IDE0028

namespace _6502_Disassmbler {
    static class Program {
        static void Main() {
            InstructionSet instructionSet = new InstructionSet();

            Console.WriteLine(instructionSet.Lookup[0xEA].Mnemonic);

            string FilePath = "";
            List<byte> FileBinary = new List<byte>();
            bool running = true;
            while (running) {
                Console.WriteLine("Enter an Option:\n" +
                "1 - Set File Path\n" +
                "2 - Load File into Memory");
                string input = Console.ReadLine() ?? "";

                switch (input) {
                    case "1":
                    Console.Write("Enter the Path of the File: ");
                    FilePath = Console.ReadLine() ?? "";
                        break;
                        
                    case "2":
                        if (!File.Exists(FilePath)) break;
                        BinaryReader reader = new BinaryReader(File.Open(FilePath, FileMode.Open));
                        FileBinary.Clear();

                        for (int i = 0; i < reader.BaseStream.Length; i++) {
                            FileBinary.Add(reader.ReadByte());
                        }
                        reader.Close();
                        Console.WriteLine("File Loaded Sucessfully!");
                        break;
                }
            }
        }
    }
}