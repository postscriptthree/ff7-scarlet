﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class CodeBlock : Code
    {
        private readonly List<Code> block = new List<Code> { };

        public CodeBlock(Code first)
        {
            AddToEnd(first);
        }

        public CodeBlock(List<Code> list)
        {
            block = list;
        }

        public void AddToTop(Code code)
        {
            block.Insert(0, code);
        }

        public void AddToEnd(Code code)
        {
            block.Add(code);
        }

        public Code GetCodeAtPosition(int i)
        {
            if (i < 0 || i >= block.Count) { return null; }
            else { return block[i]; }
        }

        public override int GetHeader()
        {
            return block[0].GetHeader();
        }

        public override int GetPrimaryOpcode()
        {
            return block[block.Count - 1].GetPrimaryOpcode();
        }

        public override FFText GetParameter()
        {
            return block[block.Count - 1].GetParameter();
        }

        public override string Disassemble(bool verbose)
        {
            string output = "";
            if (Enum.IsDefined(typeof(Opcodes), GetPrimaryOpcode()))
            {
                var opcode = (Opcodes)GetPrimaryOpcode();
                CodeLine pop1, pop2;
                switch (opcode)
                {
                    case Opcodes.Add:
                        output += $"({block[0].Disassemble(false)} + {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Subtract:
                        output += $"({block[0].Disassemble(false)} - {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Multiply:
                        output += $"({block[0].Disassemble(false)} * {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Divide:
                        output += $"({block[0].Disassemble(false)} / {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.Modulo:
                        output += $"({block[0].Disassemble(false)} % {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.BitwiseAnd:
                        output += $"({block[0].Disassemble(false)} & {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.BitwiseOr:
                        output += $"({block[0].Disassemble(false)} | {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.BitwiseNot:
                        output += $"~({block[0].Disassemble(false)})";
                        break;
                    case Opcodes.Equal:
                        output += $"({block[0].Disassemble(false)} == {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.NotEqual:
                        output += $"({block[0].Disassemble(false)} != {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.GreaterOrEqual:
                        output += $"({block[0].Disassemble(false)} >= {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LessThanOrEqual:
                        output += $"({block[0].Disassemble(false)} <= {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.GreaterThan:
                        output += $"({block[0].Disassemble(false)} > {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LessThan:
                        output += $"({block[0].Disassemble(false)} < {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LogicalAnd:
                        output += $"({block[0].Disassemble(false)} && {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LogicalOr:
                        output += $"({block[0].Disassemble(false)} || {block[1].Disassemble(false)})";
                        break;
                    case Opcodes.LogicalNot:
                        output += $"(!{block[0].Disassemble(false)})";
                        break;
                    case Opcodes.JumpEqual:
                        pop1 = block[1] as CodeLine;
                        output += $"If ({block[0].Disassemble(false)}) Goto Label {pop1.Parameter}";
                        break;
                    case Opcodes.JumpNotEqual:
                        pop1 = block[1] as CodeLine;
                        output += $"If (1st in Stack != {block[0].Disassemble(false)})";
                        output += $" Goto Label {pop1.Parameter}";
                        break;
                    case Opcodes.Mask:
                        output += $"({block[0].Disassemble(false)}.{block[1].Disassemble(false)})";
                        break;
                    case Opcodes.RandomByte:
                        output += $"RandomBit({block[0].Disassemble(false)})";
                        break;
                    case Opcodes.Assign:
                        output += $"{block[0].Disassemble(false)} = {block[1].Disassemble(false)}";
                        break;
                    case Opcodes.Attack:
                        pop1 = block[0] as CodeLine;
                        pop2 = block[1] as CodeLine;
                        if (pop1.Parameter.ToString() == "24")
                        {
                            output += "Wait";
                        }
                        else
                        {
                            output += $"PerformAttack ({pop1.Parameter}, {pop2.Parameter})";
                        }
                        break;
                    case Opcodes.AssignGlobal:
                        output += $"GlobalVar:{block[0].Disassemble(false)} = {block[1].Disassemble(false)}";
                        break;
                    default:
                        output += $"{Enum.GetName(typeof(Opcodes), opcode)}({block[0].Disassemble(false)}";
                        if (block.Count > 2)
                        {
                            output += $", {block[1].Disassemble(false)}";
                        }
                        output += ")";
                        break;
                }
            }
            else
            {
                foreach (var c in block)
                {
                    output += c.Disassemble(verbose);
                }
            }
            return output;
        }

        public override List<CodeLine> BreakDown()
        {
            var separated = new List<CodeLine> { };
            foreach (var b in block)
            {
                foreach (var c in b.BreakDown())
                {
                    separated.Add(c);
                }
            }
            return separated;
        }
    }
}