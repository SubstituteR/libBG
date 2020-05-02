using System;
using libBG.Types;
using System.IO;
using static libBG.Types.Characters;


namespace Test_libBG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Save save = new Save();
            using(BinaryReader fs = new BinaryReader(File.Open("C:\\Users\\Substitute\\Documents\\Saved Games\\Phantom Breaker BG\\config\\config20200429000.dat", FileMode.Open, FileAccess.Read)))
            {
                save.Read(fs);
            }
            Console.WriteLine($"Mikoto Level {save.Characters[Mikoto].Level}");
            Console.WriteLine($"Mikoto XP {save.Characters[Mikoto].XP}");
            Console.WriteLine($"Mikoto A Points {save.Characters[Mikoto].AvailableSkillPoints}");
            Console.WriteLine($"Mikoto T Points {save.Characters[Mikoto].TotalSkillPoints}");
            Console.WriteLine($"M unlockable {save.Characters[M].Unlockable} -> unlocked {save.Characters[M].Unlocked}");
            using (BinaryWriter fs = new BinaryWriter(File.Open("C:\\Users\\Substitute\\Documents\\Saved Games\\Phantom Breaker BG\\config\\config20200429000.dat", FileMode.Open, FileAccess.Write)))
            {
                save.Write(fs);
            }


            Console.ReadLine();
        }
    }
}
