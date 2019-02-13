using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Aelius
{
    public abstract class Character
    {
        public virtual string Name { get; set; }
        public virtual string Gender { get; set; }
    }

    public class NPC : Character
    {
        public virtual string Description { get; set; }
        public virtual string Class { get; set; }

        public virtual string GetDescription()
        {
            return Description;
        }
    }

    public class PC : Character
    {
        public int Level { get; set; }
        public int XP { get; set; }
        public string Class { get; set; }
        public float MaxHP { get; set; }
        public float CurHP { get => MaxHP; set => CurHP = MaxHP; }
        public float MaxMP { get; set; }
        public float CurMP { get => MaxMP; set => CurMP = MaxMP; }
        public float MaxSP { get; set; }
        public float CurSP { get => MaxSP; set => CurSP = MaxSP; }
        public int Str { get; set; }
        public int StrB { get; set; }
        public int StrT { get; set; }
        public int Dex { get; set; }
        public int DexB { get; set; }
        public int DexT { get; set; }
        public int Int { get; set; }
        public int IntB { get; set; }
        public int IntT { get; set; }
        public float PhyResBase { get; set; }
        public float PhyResBon { get; set; }
        public float PhyResT { get; set; }
        public float MagResBase { get; set; }
        public float MagResBon { get; set; }
        public float MagResT { get; set; }

        public void NewCharacter(PC pc)
        {
            switch (pc.Class)
            {
                case "Warrior":
                    pc.Level = 1;
                    pc.XP = 0;
                    pc.MaxHP = 100;
                    pc.MaxMP = 10;
                    pc.MaxSP = 50;
                    pc.Str = 12;
                    pc.Dex = 8;
                    pc.Int = 5;
                    pc.StrB = 0;
                    pc.StrT = 0;
                    pc.DexB = 0;
                    pc.DexT = 0;
                    pc.IntB = 0;
                    pc.IntT = 0;
                    pc.PhyResBase = (float)(Str / 100);
                    pc.MagResBase = (float)(Int / 100) + (Str / 200);
                    PhyResBon = 0;
                    PhyResT = 0;
                    MagResBon = 0;
                    MagResT = 0;
                    break;

                case "Rogue":
                    pc.Level = 1;
                    pc.XP = 0;
                    pc.MaxHP = 70;
                    pc.MaxMP = 20;
                    pc.MaxSP = 70;
                    pc.Str = 8;
                    pc.Dex = 11;
                    pc.Int = 6;
                    pc.StrB = 0;
                    pc.StrT = 0;
                    pc.DexB = 0;
                    pc.DexT = 0;
                    pc.IntB = 0;
                    pc.IntT = 0;
                    pc.PhyResBase = (float)(Dex / 100);
                    pc.MagResBase = (float)(Int / 100);
                    PhyResBon = 0;
                    PhyResT = 0;
                    MagResBon = 0;
                    MagResT = 0;
                    break;

                case "Mage":
                    pc.Level = 1;
                    pc.XP = 0;
                    pc.MaxHP = 60;
                    pc.MaxMP = 80;
                    pc.MaxSP = 20;
                    pc.Str = 6;
                    pc.Dex = 7;
                    pc.Int = 12;
                    pc.StrB = 0;
                    pc.StrT = 0;
                    pc.DexB = 0;
                    pc.DexT = 0;
                    pc.IntB = 0;
                    pc.IntT = 0;
                    pc.PhyResBase = (float)(Str / 150);
                    pc.MagResBase = (float)(Int / 85);
                    PhyResBon = 0;
                    PhyResT = 0;
                    MagResBon = 0;
                    MagResT = 0;
                    break;
            }
        }

        public void TakeDamage(float dmg)
        {
            CurHP -= dmg;
            if (CurHP < 0)
                CurHP = 0;
        }

        public void StateUpdate(PC pc)
        {
            
        }

        public float GetPhyRes()
        {
            return PhyResBase + PhyResBon + PhyResT;
        }

        public float GetMagRes()
        {
            return MagResBase + MagResBon + MagResT;
        }
    }

    public class EC : Character
    {
        public string Description { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public float MaxHP { get; set; }
        public float CurHP { get => MaxHP; set => CurHP = MaxHP; }
        public float MaxMP { get; set; }
        public float CurMP { get => MaxMP; set => CurMP = MaxMP; }
        public float MaxSP { get; set; }
        public float CurSP { get => MaxSP; set => CurSP = MaxSP; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Int { get; set; }
        public float PhyResBase { get; set; }
        public float PhyResT { get; set; }
        public float MagResBase { get; set; } 
        public float MagResT { get; set; }

        public string GetDescription()
        {
            return Description;
        }

        public void TakeDamage(float dmg)
        {
            CurHP -= dmg;
            if (CurHP < 0)
                CurHP = 0;
        }

        public float GetPhyRes()
        {
            return PhyResBase + PhyResT;
        }

        public float GetMagRes()
        {
            return MagResBase + PhyResT;
        }
    }

    public static class AllEC
    {
        //Enemies Level 1 - 5
        public static EC bandit = new EC();
        public static EC thug = new EC();

        public static void Generate()
        {
            bandit.Name = "Bandit";
            bandit.Gender = "Male";
            bandit.Description = "A masked man in rough clothing with an old blade.";
            bandit.Level = 1;
            bandit.Class = "Rogue";
            bandit.MaxHP = 25;
            bandit.MaxMP = 0;
            bandit.MaxSP = 10;
            bandit.Str = 4;
            bandit.Dex = 7;
            bandit.Int = 3;
            bandit.PhyResBase = (float)(bandit.Dex / 100);
            bandit.MagResBase = (float)(bandit.Int / 100);
            bandit.PhyResT = 0;
            bandit.MagResT = 0;

            thug.Name = "Thug";
            thug.Gender = "Male";
            thug.Description = "A dirty ruffian with a menacing look.";
            thug.Level = 1;
            thug.Class = "Warrior";
            thug.MaxHP = 35;
            thug.MaxMP = 0;
            thug.MaxSP = 10;
            thug.Str = 8;
            thug.Dex = 5;
            thug.Int = 1;
            thug.PhyResBase = (float)(thug.Str / 100);
            thug.MagResBase = (float)(thug.Str / 80);
        }
    }
}
