using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Aelius
{
    public abstract class Ability
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Type { get; set; }
        public virtual string Stat { get; set; }
        public virtual float Scale { get; set; }
        public virtual float MPCost { get; set; }
        public virtual float SPCost { get; set; }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual string GetDescription()
        {
            return Description;
        }
    }

    public class Attack : Ability
    {
        public float BaseDmg { get; set; }
        public bool isUnblockable { get; set; }

        public float GetDmg(int stat)
        {
            return BaseDmg * (1 + stat * Scale);
        }
    }

    public class Spell : Ability
    {

    }

    public class Buff : Ability
    {
        public int StrT { get; set; }
        public int DexT { get; set; }
        public int IntT { get; set; }
        public float PhyResT { get; set; }
        public float MagResT { get; set; }
        public float RecHP { get; set; }
        public float RecMP { get; set; }
        public float RecSP { get; set; }

        public int GetStrBonus()
        {
            return StrT;
        }

        public int GetDexBonus()
        {
            return DexT;
        }

        public int GetIntBonus()
        {
            return IntT;
        }
    }

    public class Debuff : Ability
    {

    }

    public static class AllAttacks
    {
        //Physical Attacks
        public static Attack slash = new Attack();
        public static Attack precisionStrike = new Attack();

        //Magical Attacks
        public static Attack push = new Attack();
        public static Attack fireBall = new Attack();

        public static void Generate()
        {
            //Physical Attacks
            slash.Name = "Slash";
            slash.Description = "A simple but effective strike.";
            slash.Type = "physical";
            slash.Stat = "str";
            slash.Scale = 0.1F;
            slash.MPCost = 0;
            slash.SPCost = 1;
            slash.BaseDmg = 5;
            slash.isUnblockable = false;

            precisionStrike.Name = "Precision Strike";
            precisionStrike.Description = "A single, accurate strike guaranteed to hit.";
            precisionStrike.Type = "physical";
            precisionStrike.Stat = "dex";
            precisionStrike.Scale = 0.05F;
            precisionStrike.MPCost = 0;
            precisionStrike.SPCost = 10F;
            precisionStrike.BaseDmg = 10F;
            precisionStrike.isUnblockable = false;

            //Magical Attacks
            push.Name = "Push";
            push.Description = "A powerful telekinetic strike.";
            push.Type = "magic";
            push.Stat = "int";
            push.Scale = 0.1F;
            push.MPCost = 1;
            push.SPCost = 0;
            push.BaseDmg = 5F;
            push.isUnblockable = false;

            fireBall.Name = "Fireball";
            fireBall.Description = "A superheated conjuration.";
            fireBall.Type = "magic";
            fireBall.Stat = "int";
            fireBall.Scale = 0.05F;
            fireBall.MPCost = 5F;
            fireBall.SPCost = 0;
            fireBall.BaseDmg = 8F;
            fireBall.isUnblockable = false;
        }

        public static void Test()
        {
            AllAttacks.Generate();
        }
    }

    public static class AllBuffs
    {
        static Buff ironSkin = new Buff();

        public static void Generate()
        {
            ironSkin.Name = "Ironskin";
            ironSkin.Description = "Enhances physical and magical defense.";
            ironSkin.Type = "buff";
            ironSkin.Stat = "int";
            ironSkin.Scale = 0.05F;
            ironSkin.MPCost = 5;
            ironSkin.SPCost = 0;
            ironSkin.StrT = 0;
            ironSkin.DexT = 0;
            ironSkin.IntT = 0;
            ironSkin.PhyResT = 10 * (1 - ironSkin.Scale);
            ironSkin.MagResT = 10 * (1 - ironSkin.Scale);
        }
    }
}
