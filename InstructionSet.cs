#pragma warning disable IDE0161 // Or IDE0160

namespace _6502_Disassmbler
{
    public enum AddressingMode
    {
        Implied,
        Accumulator,
        Immediate,
        ZeroPage,
        ZeroPageX,
        ZeroPageY,
        Relative,
        Absolute,
        AbsoluteX,
        AbsoluteY,
        Indirect,
        IndexedIndirect,
        IndirectIndexed
    }
    public class OpcodeInfo
    {
        public byte Opcode;
        public string Mnemonic = "";
        public AddressingMode Mode;
        public byte Length;
        public byte Cycles;
    }

    public class InstructionSet
    {
        public OpcodeInfo[] Lookup = new OpcodeInfo[256];

        public InstructionSet()
        {
            BuildTable();
        }

    private void AddOpcode(byte opcode, string mnemonic, AddressingMode mode, byte length, byte cycles)
        {
            Lookup[opcode] = new OpcodeInfo
            {
                Opcode = opcode,
                Mnemonic = mnemonic,
                Mode = mode,
                Length = length,
                Cycles = cycles
            };
        }

        private void BuildTable()
        {
            AddOpcode(0x69, "ADC", AddressingMode.Immediate, 2, 2);
            AddOpcode(0x65, "ADC", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x75, "ADC", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0x6D, "ADC", AddressingMode.Absolute, 3, 4);
            AddOpcode(0x7D, "ADC", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0x79, "ADC", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0x61, "ADC", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0x71, "ADC", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0x29, "AND", AddressingMode.Immediate, 2, 2);
            AddOpcode(0x25, "AND", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x35, "AND", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0x2D, "AND", AddressingMode.Absolute, 3, 4);
            AddOpcode(0x3D, "AND", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0x39, "AND", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0x21, "AND", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0x31, "AND", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0x0A, "ASL", AddressingMode.Accumulator, 1, 2);
            AddOpcode(0x06, "ASL", AddressingMode.ZeroPage, 2, 5);
            AddOpcode(0x16, "ASL", AddressingMode.ZeroPageX, 2, 6);
            AddOpcode(0x0E, "ASL", AddressingMode.Absolute, 3, 6);
            AddOpcode(0x1E, "ASL", AddressingMode.AbsoluteX, 3, 7);

            AddOpcode(0x90, "BCC", AddressingMode.Relative, 2, 2);

            AddOpcode(0xB0, "BCS", AddressingMode.Relative, 2, 2);

            AddOpcode(0xF0, "BEQ", AddressingMode.Relative, 2, 2);

            AddOpcode(0x24, "BIT", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x2C, "BIT", AddressingMode.Absolute, 2, 4);

            AddOpcode(0x30, "BMI", AddressingMode.Relative, 2, 2);

            AddOpcode(0xD0, "BNE", AddressingMode.Relative, 2, 2);

            AddOpcode(0x10, "BPL", AddressingMode.Relative, 2, 2);

            AddOpcode(0x00, "BRK", AddressingMode.Implied, 1, 7);

            AddOpcode(0x50, "BVC", AddressingMode.Relative, 2, 2);

            AddOpcode(0x70, "BVS", AddressingMode.Relative, 2, 2);

            AddOpcode(0x18, "CLC", AddressingMode.Implied, 1, 2);

            AddOpcode(0xD8, "CLD", AddressingMode.Implied, 1, 2);

            AddOpcode(0x58, "CLI", AddressingMode.Implied, 1, 2);

            AddOpcode(0xB8, "CLV", AddressingMode.Implied, 1, 2);

            AddOpcode(0xC9, "CMP", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xC5, "CMP", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xD5, "CMP", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0xCD, "CMP", AddressingMode.Absolute, 3, 4);
            AddOpcode(0xDD, "CMP", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0xD9, "CMP", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0xC1, "CMP", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0xD1, "CMP", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0xE0, "CPX", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xE4, "CPX", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xEC, "CPX", AddressingMode.Absolute, 3, 4);

            AddOpcode(0xC0, "CPY", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xC4, "CPY", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xCC, "CPY", AddressingMode.Absolute, 3, 4);

            AddOpcode(0xC6, "DEC", AddressingMode.ZeroPage, 2, 5);
            AddOpcode(0xD6, "DEC", AddressingMode.ZeroPageX, 2, 5);
            AddOpcode(0xCE, "DEC", AddressingMode.Absolute, 2, 5);
            AddOpcode(0xDE, "DEC", AddressingMode.AbsoluteX, 2, 5);

            AddOpcode(0xCA, "DEX", AddressingMode.Implied, 1, 2);

            AddOpcode(0x88, "DEY", AddressingMode.Implied, 1, 2);

            AddOpcode(0x49, "EOR", AddressingMode.Immediate, 2, 2);
            AddOpcode(0x45, "EOR", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x55, "EOR", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0x4D, "EOR", AddressingMode.Absolute, 3, 4);
            AddOpcode(0x5D, "EOR", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0x59, "EOR", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0x41, "EOR", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0x51, "EOR", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0xE6, "INC", AddressingMode.ZeroPage, 2, 5);
            AddOpcode(0xF6, "INC", AddressingMode.ZeroPage, 2, 6);
            AddOpcode(0xEE, "INC", AddressingMode.ZeroPage, 3, 6);
            AddOpcode(0xFE, "INC", AddressingMode.ZeroPage, 3, 7);

            AddOpcode(0xE8, "INX", AddressingMode.Implied, 1, 2);

            AddOpcode(0xC8, "INY", AddressingMode.Implied, 1, 2);

            AddOpcode(0x4C, "JMP", AddressingMode.Absolute, 3, 3);
            AddOpcode(0x6C, "JMP", AddressingMode.Indirect, 3, 5);

            AddOpcode(0x20, "JSR", AddressingMode.Absolute, 3, 6);

            AddOpcode(0xA9, "LDA", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xA5, "LDA", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xB5, "LDA", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0xAD, "LDA", AddressingMode.Absolute, 3, 4);
            AddOpcode(0xBD, "LDA", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0xB9, "LDA", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0xA1, "LDA", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0xB1, "LDA", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0xA2, "LDX", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xA6, "LDX", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xB6, "LDX", AddressingMode.ZeroPageY, 2, 4);
            AddOpcode(0xAE, "LDX", AddressingMode.Absolute, 3, 4);
            AddOpcode(0xBE, "LDX", AddressingMode.AbsoluteY, 3, 4);

            AddOpcode(0xA0, "LDY", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xA4, "LDY", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xB4, "LDY", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0xAC, "LDY", AddressingMode.Absolute, 3, 4);
            AddOpcode(0xBC, "LDY", AddressingMode.AbsoluteX, 3, 4);

            AddOpcode(0x4A, "LSR", AddressingMode.Immediate, 1, 2);
            AddOpcode(0x46, "LSR", AddressingMode.ZeroPage, 2, 5);
            AddOpcode(0x56, "LSR", AddressingMode.ZeroPageX, 2, 6);
            AddOpcode(0x4E, "LSR", AddressingMode.Absolute, 3, 6);
            AddOpcode(0x5E, "LSR", AddressingMode.AbsoluteX, 3, 7);

            AddOpcode(0xEA, "NOP", AddressingMode.Implied, 1, 2);

            AddOpcode(0x09, "ORA", AddressingMode.Immediate, 2, 2);
            AddOpcode(0x05, "ORA", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x15, "ORA", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0x0D, "ORA", AddressingMode.Absolute, 3, 4);
            AddOpcode(0x1D, "ORA", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0x19, "ORA", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0x01, "ORA", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0x11, "ORA", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0x48, "PHA", AddressingMode.Implied, 1, 3);

            AddOpcode(0x08, "PHP", AddressingMode.Implied, 1, 3);

            AddOpcode(0x68, "PLA", AddressingMode.Implied, 1, 4);

            AddOpcode(0x28, "PLP", AddressingMode.Implied, 1, 4);

            AddOpcode(0x2A, "ROL", AddressingMode.Accumulator, 1, 2);
            AddOpcode(0x26, "ROL", AddressingMode.ZeroPage, 2, 5);
            AddOpcode(0x36, "ROL", AddressingMode.ZeroPageX, 2, 6);
            AddOpcode(0x2E, "ROL", AddressingMode.Absolute, 3, 6);
            AddOpcode(0x3E, "ROL", AddressingMode.AbsoluteX, 3, 7);

            AddOpcode(0x6A, "ROR", AddressingMode.Accumulator, 1, 2);
            AddOpcode(0x66, "ROR", AddressingMode.ZeroPage, 2, 5);
            AddOpcode(0x76, "ROR", AddressingMode.ZeroPageX, 2, 6);
            AddOpcode(0x6E, "ROR", AddressingMode.Absolute, 3, 6);
            AddOpcode(0x7E, "ROR", AddressingMode.AbsoluteX, 3, 7);

            AddOpcode(0x40, "RTI", AddressingMode.Implied, 1, 6);

            AddOpcode(0x60, "RTS", AddressingMode.Implied, 1, 6);

            AddOpcode(0xE9, "SBC", AddressingMode.Immediate, 2, 2);
            AddOpcode(0xE5, "SBC", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0xF5, "SBC", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0xED, "SBC", AddressingMode.Absolute, 3, 4);
            AddOpcode(0xFD, "SBC", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0xF9, "SBC", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0xE1, "SBC", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0xF1, "SBC", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0x38, "SEC", AddressingMode.Implied, 1, 2);

            AddOpcode(0xF8, "SED", AddressingMode.Implied, 1, 2);

            AddOpcode(0x78, "SEI", AddressingMode.Implied, 1, 2);

            AddOpcode(0x85, "STA", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x95, "STA", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0x8D, "STA", AddressingMode.Absolute, 3, 4);
            AddOpcode(0x9D, "STA", AddressingMode.AbsoluteX, 3, 4);
            AddOpcode(0x99, "STA", AddressingMode.AbsoluteY, 3, 4);
            AddOpcode(0x81, "STA", AddressingMode.IndexedIndirect, 2, 6);
            AddOpcode(0x91, "STA", AddressingMode.IndirectIndexed, 2, 5);

            AddOpcode(0x86, "STX", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x96, "STX", AddressingMode.ZeroPageY, 2, 4);
            AddOpcode(0x8E, "STX", AddressingMode.Absolute, 3, 4);

            AddOpcode(0x84, "STY", AddressingMode.ZeroPage, 2, 3);
            AddOpcode(0x94, "STY", AddressingMode.ZeroPageX, 2, 4);
            AddOpcode(0x8C, "STY", AddressingMode.Absolute, 3, 4);

            AddOpcode(0xAA, "TAX", AddressingMode.Implied, 1, 2);

            AddOpcode(0xA8, "TAY", AddressingMode.Implied, 1, 2);

            AddOpcode(0xBA, "TSX", AddressingMode.Implied, 1, 2);

            AddOpcode(0x8A, "TXA", AddressingMode.Implied, 1, 2);

            AddOpcode(0x9A, "TXS", AddressingMode.Implied, 1, 2);

            AddOpcode(0x98, "TYA", AddressingMode.Implied, 1, 2);
        }
    }
}
