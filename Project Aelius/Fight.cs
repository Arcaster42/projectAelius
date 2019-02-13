using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Aelius
{
    public static class Fight
    {
        public static void AttackTarget(Attack att, EC ec)
        {
            ec.TakeDamage(CalcIncDamage(att, ec));
        }

        public static void AttackPlayer(Attack att, PC pc)
        {
            pc.TakeDamage(CalcIncDamage(att, pc));
        }

        public static float CalcIncDamage(Attack att, PC pc)
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
                red = pc.GetPhyRes();
            }
            if (att.Type == "magic")
            {
                red = pc.GetMagRes();
            }

            dmg = dmg * (1 - red);
            if (dmg < 1)
                dmg = 1;
            return dmg;
        }

        public static float CalcIncDamage(Attack att, EC ec)
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
                red = ec.GetPhyRes();
            }
            if (att.Type == "magic")
            {
                red = ec.GetMagRes();
            }

            dmg = dmg * (1 - red);
            if (dmg < 1)
                dmg = 1;
            return dmg;
        }
    }
}
