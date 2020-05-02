using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using libBG.Interfaces;
using static libBG.Types.Skills;

namespace libBG.Types
{
    public static class Characters
    {
        public const int Mikoto =   0x0;
        public const int Waka =     0x1;
        public const int Itsuki =   0x2;
        public const int Yuzuha =   0x3;
        public const int M =        0x4;
        public const int Cocoa =    0x5;
        public const int Infinity = 0x6;
        public const int Nagi =     0x7;
        public const int MikotoW =  0x8;
        public const int L =        0x9;
    }
    public class Character : IGameData
    {
        internal int _character = 0;
        public Skill[] Skills { get; private set; }
        public Character(int position)
        {
            _character = position;
            Skills = new Skill[]
            {
                new Skill(_character, DashAttack),
                new Skill(_character, Hijump),
                new Skill(_character, AirThrow)
            };
        }
        public virtual void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(Offset + _character * Size, SeekOrigin.Begin);
            Level = reader.ReadInt32();
            XP = reader.ReadInt32();
            AvailableSkillPoints = reader.ReadInt32();
            TotalSkillPoints = reader.ReadInt32();
            foreach (Skill skill in Skills) { skill.Read(reader); }
        }

        public virtual void Write(BinaryWriter writer)
        {
            writer.BaseStream.Seek(64 + _character * Size, SeekOrigin.Begin);
            writer.Write(Level);
            writer.Write(XP);
            writer.Write(AvailableSkillPoints);
            writer.Write(TotalSkillPoints);
            foreach (Skill skill in Skills) { skill.Write(writer); }
        }

        public const int Size =   0x24;
        public const int Offset = 0x40;

        public virtual bool Unlockable => false;
        private bool _unlocked = true;
        public bool Unlocked
        {
            get => Unlockable ? _unlocked : true;
            set { _unlocked = Unlockable ? value : true; }
        }

        public int Level { get; set; }
        public int XP { get; set; }
        public int AvailableSkillPoints { get; set; }
        public int TotalSkillPoints { get; set; }
    }

    public class UnlockableCharacter : Character
    {
        private const int UnlockablesBegin = 4;
        public UnlockableCharacter(int position) : base(position) { }
        public override void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(52 + (_character - UnlockablesBegin), SeekOrigin.Begin); //read byte for unlocked
            Unlocked = reader.ReadBoolean();
            base.Read(reader);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.BaseStream.Seek(52 + (_character - UnlockablesBegin), SeekOrigin.Begin);
            writer.Write(Unlocked);
            //stream.WriteByte(Convert<bool>.Get.To(Unlocked));
            base.Write(writer);
        }

        public override bool Unlockable => true;
    }

}
