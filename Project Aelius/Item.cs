using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Aelius
{
    public abstract class Item
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Value { get; set; }

        public virtual string Describe()
        {
            return Description;
        }
    }

    public abstract class Weapon : Item
    {
        public virtual string WeaponType { get; set; }
        public virtual int MinDam { get; set; }
        public virtual int MaxDam { get; set; }
        public virtual int CritMult { get; set; }
        public virtual int CritChance { get; set; }
        public virtual bool IsTwoHanded { get; set; }
        public virtual bool IsRanged { get; set; }

        public virtual float CalcDam()
        {
            Random ran = new Random();
            float roll = ran.Next(MinDam, MaxDam);
            return roll;
        }
    }

    abstract class Armor : Item
    {
        public virtual string ArmorType { get; set; }
        public virtual float Reduction { get; set; }
        public virtual string Slot { get; set; }

        public abstract float CalcReduction(float baseDmg, int stat);
    }

    abstract class Jewelry : Item
    {
        public virtual string JewelryType { get; set; }
        public virtual string BuffType { get; set; }
        public virtual float BuffValue { get; set; }

        public virtual string GetBuffType()
        {
            return BuffType;
        }

        public virtual float GetBuffValue()
        {
            return BuffValue;
        }
    }

    class Dagger : Weapon
    {
        public Dagger()
        {
            WeaponType = "dagger";
            CritMult = 5;
        }
    }

    public class Sword : Weapon
    {
        public Sword()
        {
            WeaponType = "sword";
            CritMult = 2;
            IsRanged = false;
        }
    }

    class Axe : Weapon
    {
        public Axe()
        {
            WeaponType = "axe";
            CritMult = 2;
        }
    }

    class Bow : Weapon
    {
        public Bow()
        {
            WeaponType = "bow";
            CritMult = 3;
        }
    }

    class Staff : Weapon
    {
        public Staff()
        {
            WeaponType = "staff";
            CritMult = 2;
        }
    }

    class Shield : Item
    {
        public string ShieldType { get; set; }
        public float BlockChance { get; set; }
        public float Reduction { get; set; }

        public virtual float CalcBlock(int stat)
        {
            return BlockChance + (stat / 100);
        }

        public virtual float CalcReduction(float baseDmg, int stat)
        {
            return baseDmg * Reduction;
        }
    }

    class LightArmor : Armor
    { 
        public override float CalcReduction(float baseDmg, int stat)
        {            
            return baseDmg * Reduction;
        }
    }

    class MediumArmor : Armor
    {
        public override float CalcReduction(float baseDmg, int stat)
        {
            return baseDmg * (Reduction + (stat / 100));
        }
    }

    class HeavyArmor : Armor
    {
        public override float CalcReduction(float baseDmg, int stat)
        {
            return baseDmg * (Reduction + (stat / 50));
        }
    }

    class Amulet : Jewelry
    {
        public Amulet()
        {
            JewelryType = "amulet";
        }
    }

    class Ring : Jewelry
    {
        public Ring()
        {
            JewelryType = "ring";
        }
    }

    public static class AllWeapons
    {
        //One-Handed Swords
        public static Sword copperSword = new Sword();

        public static void Generate()
        {
            copperSword.Name = "Copper Sword";
            copperSword.Description = "An old, worn sword made of cheap metal.";
            copperSword.Value = 30;
            copperSword.MinDam = 4;
            copperSword.MaxDam = 7;
            copperSword.CritChance = 90;
            copperSword.IsTwoHanded = false;
        }
    }
}
