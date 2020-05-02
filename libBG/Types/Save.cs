using libBG.Interfaces;
using static libBG.Types.Characters;
using System.IO;

namespace libBG.Types
{
    public class Save : IGameData
    {
        public byte Language { get; set; }
        public Character[] Characters { get; private set; } =
        {
            new Character(Mikoto),
            new Character(Waka),
            new Character(Itsuki),
            new Character(Yuzuha),
            new UnlockableCharacter(M),
            new UnlockableCharacter(Cocoa),
            new UnlockableCharacter(Infinity),
            new UnlockableCharacter(Nagi),
            new UnlockableCharacter(MikotoW),
            new UnlockableCharacter(L)
        };
        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(28, SeekOrigin.Begin);
            Language = reader.ReadByte();
            foreach(Character character in Characters) { character.Read(reader); }
        }

        public void Write(BinaryWriter writer)
        {
            writer.BaseStream.Seek(28, SeekOrigin.Begin);
            writer.Write(Language);
            foreach (Character character in Characters) { character.Write(writer); }
        }
    }
}
