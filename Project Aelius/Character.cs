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

    class NPC : Character
    {
        public virtual string Description { get; set; }
        public virtual string Class { get; set; }

        public virtual string GetDescription()
        {
            return Description;
        }
    }

    class PC : Character
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

        public void TakeAttack(Attack att, EC ec)
        {
            float dmg = CalcIncDamage(att, ec);
            TakeDamage(dmg);
        }

        public void TakeDamage(float dmg)
        {
            CurHP -= dmg;
            if (CurHP < 0)
                CurHP = 0;
        }

        public float CalcIncDamage(Attack att, EC ec)
        {
            float dmg = 0;
            int stat = 0;

            if (att.Stat == "str")
                stat = ec.Str;
            if (att.Stat == "dex")
                stat = ec.Dex;
            if (att.Stat == "int")
                stat = ec.Int;

            dmg = att.GetDmg(stat);

            float red = 0;

            if (att.Type == "physical")
            {
                red = GetPhyRes();
            }
            if (att.Type == "magic")
            {
                red = GetMagRes();
            }

            dmg = dmg * (1 - red);
            if (dmg < 1)
                dmg = 1;
            return dmg;
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

    class EC : Character
    {
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

        public void TakeAttack(Attack att, PC pc)
        {
            float dmg = CalcIncDamage(att, pc);
            TakeDamage(dmg);
        }

        public void TakeDamage(float dmg)
        {
            CurHP -= dmg;
            if (CurHP < 0)
                CurHP = 0;
        }

        public float CalcIncDamage(Attack att, PC pc)
        {
            float dmg = 0;
            int stat = 0;

            if (att.Stat == "str")
                stat = pc.Str + pc.StrB + pc.StrT;
            if (att.Stat == "dex")
                stat = pc.Dex + pc.DexB + pc.DexT;
            if (att.Stat == "int")
                stat = pc.Int + pc.IntB + pc.IntT;

            dmg = att.GetDmg(stat);

            float red = 0;

            if (att.Type == "physical")
            {
                red = GetPhyRes();
            }
            if (att.Type == "magic")
            {
                red = GetMagRes();
            }

            dmg = dmg * (1 - red);
            if (dmg < 1)
                dmg = 1;
            return dmg;
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
}
