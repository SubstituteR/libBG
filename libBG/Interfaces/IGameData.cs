using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace libBG.Interfaces
{
    interface IGameData
    {
        void Read(BinaryReader reader);
        void Write(BinaryWriter writer);
    }
}
