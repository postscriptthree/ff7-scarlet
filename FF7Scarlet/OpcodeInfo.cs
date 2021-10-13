﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public enum OpcodeGroups
    {
        Push, Mathematical, Logical, Jump, BitOperation, Command
    }

    public enum ParameterTypes
    {
        None, OneByte, TwoByte, ThreeByte, String, Label
    }

    public class OpcodeInfo
    {
        public static readonly OpcodeInfo[] OPCODE_LIST = new OpcodeInfo[]
        {
            new OpcodeInfo(Opcodes.PushAddress00, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 0"),
            new OpcodeInfo(Opcodes.PushAddress01, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 1"),
            new OpcodeInfo(Opcodes.PushAddress02, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 2"),
            new OpcodeInfo(Opcodes.PushAddress03, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Address Type 3"),

            new OpcodeInfo(Opcodes.PushValue10, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 0"),
            new OpcodeInfo(Opcodes.PushValue11, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 1"),
            new OpcodeInfo(Opcodes.PushValue12, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 2"),
            new OpcodeInfo(Opcodes.PushValue13, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Value Type 3"),

            new OpcodeInfo(Opcodes.Add, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "+"),
            new OpcodeInfo(Opcodes.Subtract, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "-"),
            new OpcodeInfo(Opcodes.Multiply, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "*"),
            new OpcodeInfo(Opcodes.Divide, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "/"),
            new OpcodeInfo(Opcodes.Modulo, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "%"),
            new OpcodeInfo(Opcodes.BitwiseAnd, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "&"),
            new OpcodeInfo(Opcodes.BitwiseOr, OpcodeGroups.Mathematical, ParameterTypes.None, 2, "|"),
            new OpcodeInfo(Opcodes.BitwiseNot, OpcodeGroups.Mathematical, ParameterTypes.None, 1, "~"),

            new OpcodeInfo(Opcodes.Equal, OpcodeGroups.Logical, ParameterTypes.None, 2, "=="),
            new OpcodeInfo(Opcodes.NotEqual, OpcodeGroups.Logical, ParameterTypes.None, 2, "!="),
            new OpcodeInfo(Opcodes.GreaterOrEqual, OpcodeGroups.Logical, ParameterTypes.None, 2, ">="),
            new OpcodeInfo(Opcodes.LessThanOrEqual, OpcodeGroups.Logical, ParameterTypes.None, 2, "<="),
            new OpcodeInfo(Opcodes.GreaterThan, OpcodeGroups.Logical, ParameterTypes.None, 2, ">"),
            new OpcodeInfo(Opcodes.LessThan, OpcodeGroups.Logical, ParameterTypes.None, 2, "<"),

            new OpcodeInfo(Opcodes.LogicalAnd, OpcodeGroups.Logical, ParameterTypes.None, 2, "&&"),
            new OpcodeInfo(Opcodes.LogicalOr, OpcodeGroups.Logical, ParameterTypes.None, 2, "||"),
            new OpcodeInfo(Opcodes.LogicalNot, OpcodeGroups.Logical, ParameterTypes.None, 1, "!"),

            new OpcodeInfo(Opcodes.PushConst01, OpcodeGroups.Push, ParameterTypes.OneByte, 0, "Const Type 1"),
            new OpcodeInfo(Opcodes.PushConst02, OpcodeGroups.Push, ParameterTypes.TwoByte, 0, "Const Type 2"),
            new OpcodeInfo(Opcodes.PushConst03, OpcodeGroups.Push, ParameterTypes.ThreeByte, 0, "Const Type 3"),

            new OpcodeInfo(Opcodes.JumpEqual, OpcodeGroups.Jump, ParameterTypes.TwoByte, 1),
            new OpcodeInfo(Opcodes.JumpNotEqual, OpcodeGroups.Jump, ParameterTypes.TwoByte, 1),
            new OpcodeInfo(Opcodes.Jump, OpcodeGroups.Jump, ParameterTypes.TwoByte, 0),
            new OpcodeInfo(Opcodes.End, OpcodeGroups.Command, ParameterTypes.None, 0),
            new OpcodeInfo(Opcodes.PopUnused, OpcodeGroups.Command, ParameterTypes.None, 0),
            new OpcodeInfo(Opcodes.Link, OpcodeGroups.Command, ParameterTypes.None, 1),

            new OpcodeInfo(Opcodes.Mask, OpcodeGroups.BitOperation, ParameterTypes.None, 2, "."),
            new OpcodeInfo(Opcodes.RandomWord, OpcodeGroups.BitOperation, ParameterTypes.None, 0, "Random"),
            new OpcodeInfo(Opcodes.RandomByte, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.CountBits, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.MaskGreatest, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.MaskLeast, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.MPCost, OpcodeGroups.BitOperation, ParameterTypes.None, 1),
            new OpcodeInfo(Opcodes.TopBit, OpcodeGroups.BitOperation, ParameterTypes.None, 1),

            new OpcodeInfo(Opcodes.Assign, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.Pop, OpcodeGroups.Command, ParameterTypes.None, 0),
            new OpcodeInfo(Opcodes.Attack, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.ShowMessage, OpcodeGroups.Command, ParameterTypes.String, 0),
            new OpcodeInfo(Opcodes.CopyStats, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.AssignGlobal, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.ElementalDef, OpcodeGroups.Command, ParameterTypes.None, 2),
            new OpcodeInfo(Opcodes.DebugMessage, OpcodeGroups.Command, ParameterTypes.String, 1),
            new OpcodeInfo(Opcodes.Pop2, OpcodeGroups.Command, ParameterTypes.None, 0),

            new OpcodeInfo(Opcodes.Label, OpcodeGroups.Jump, ParameterTypes.Label, 0),
        };

        private string shortName;

        public Opcodes EnumValue { get; }
        public OpcodeGroups Group { get; }
        public ParameterTypes ParameterType { get; }
        public int PopCount { get; }
        public int Code
        {
            get { return (int)EnumValue; }
        }
        public string Name
        {
            get { return Enum.GetName(typeof(Opcodes), EnumValue); }
        }
        public string ShortName
        {
            get
            {
                if (shortName == null)
                {
                    return Name;
                }
                return shortName;
            }
        }

        public OpcodeInfo(Opcodes enumValue, OpcodeGroups group, ParameterTypes parameterType, int popCount,
            string shortName = null)
        {
            EnumValue = enumValue;
            Group = group;
            ParameterType = parameterType;
            PopCount = popCount;
            this.shortName = shortName;
        }

        public static OpcodeInfo GetInfo(int opcode)
        {
            for (int i = 0; i < OPCODE_LIST.Length; ++i)
            {
                if (OPCODE_LIST[i].Code == opcode)
                {
                    return OPCODE_LIST[i];
                }
            }
            return null;
        }

        public static OpcodeInfo GetInfo(Opcodes opcode)
        {
            return GetInfo((int)opcode);
        }

        public bool IsOperand()
        {
            return (Group == OpcodeGroups.Mathematical || Group == OpcodeGroups.Logical
                || Group == OpcodeGroups.BitOperation) && PopCount > 0;
        }

        public bool IsParameter()
        {
            return Group == OpcodeGroups.Push || Group == OpcodeGroups.Jump
                || Code == (int)Opcodes.RandomWord || ParameterType == ParameterTypes.String;
        }
    }
}
