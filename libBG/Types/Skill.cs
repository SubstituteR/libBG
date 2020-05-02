using libBG.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace libBG.Types
{
    public static class Skills
    {
        public const int DashAttack      = 0x0;
        public const int Hijump          = 0x1;
        public const int AirThrow        = 0x2;
        public const int GDCancel        = 0x3;
        public const int CounterBurstLv1 = 0x4;
        public const int CounterBurstLv2 = 0x5;
        public const int DoubleJump      = 0x6;
        public const int CriticalBurst   = 0x7;
        public const int SPAttackLv1     = 0x8;
        public const int SPAttackLv2     = 0x9;
        public const int ComboLv1        = 0xA;
        public const int ComboLv2        = 0xB;
        public const int ExAttack        = 0xC;
        public const int PhantomBreak    = 0xD;
        public const int OverDriveLv1    = 0xE;
        public const int OverDriveLv2    = 0xF;
    }
    public static class SkillStates
    {
        public const byte Locked   = 0x0;
        public const byte Unlocked = 0x1;
        public const byte Owned    = 0x2;
    }
    public class Skill : IGameData
    {
        public byte State { get; set; }
        private readonly int _skill;
        private readonly int _character;
        public const int Offset = 0x10;
        public Skill(int Character, int Skill)
        {
            _skill = Skill; _character = Character;
        }
        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(Character.Offset + _character * Character.Size + Offset + _skill, SeekOrigin.Begin);
            State = reader.ReadByte();
        }

        public void Write(BinaryWriter writer)
        {
            writer.BaseStream.Seek(Character.Offset + _character * Character.Size + Offset + _skill, SeekOrigin.Begin);
            writer.Write(State);
        }
    }
}
