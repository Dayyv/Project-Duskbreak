using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Duskbreak.Methods
{
    internal class DealDmg
    {
        public class DamageParams
        {
            // Base scaling
            public double BaseStat;              // ATK / HP / DEF
            public double SkillMultiplier;       // np. 2.40 = 240%
            public double FlatDamage;            // dodatkowe płaskie obrażenia

            // Damage Bonus
            public double ElementalDamageBonus;  // np. 0.388
            public double TypeDamageBonus;       // Follow-up/Ultimate/Skill itd.
            public double AllDamageBonus;        // ogólny bonus

            // Crit
            public bool IsCrit;
            public double CritDamage;            // np. 2.00 = 200%

            // Levels
            public int AttackerLevel;
            public int EnemyLevel;

            // Defense
            public double DefenseIgnore;         // np. 0.20
            public double DefenseReduction;      // np. 0.40

            // Resistance
            public double Resistance;            // np. 0.20
            public double ResPen;                // np. 0.25

            // Enemy debuffs
            public double Vulnerability;         // np. 0.30

            // Misc
            public double WeakenMultiplier = 1.0;
            public double DamageMitigation = 1.0;
            public double BrokenMultiplier = 1.0;
            public double OriginalDamageMultiplier = 1.0;
        }

        public static double Calculate(DamageParams p)
        {
            // Base Damage
            double baseDamage =
                (p.BaseStat * p.SkillMultiplier) +
                p.FlatDamage;

            // DMG Bonus
            double dmgBoostMultiplier =
                1.0 +
                p.ElementalDamageBonus +
                p.TypeDamageBonus +
                p.AllDamageBonus;

            // Crit
            double critMultiplier =
                p.IsCrit
                    ? 1.0 + p.CritDamage
                    : 1.0;

            // Defense
            double defenseFactor =
                Math.Max(
                    0.0,
                    1.0 -
                    p.DefenseIgnore -
                    p.DefenseReduction);

            double defenseMultiplier =
                (p.AttackerLevel + 20.0)
                /
                (
                    (p.AttackerLevel + 20.0)
                    +
                    ((p.EnemyLevel + 20.0)
                    * defenseFactor)
                );

            // Resistance
            double effectiveRes =
                p.Resistance - p.ResPen;

            double resistanceMultiplier;

            if (effectiveRes < 0)
            {
                resistanceMultiplier =
                    1.0 - (effectiveRes / 2.0);
            }
            else if (effectiveRes <= 0.75)
            {
                resistanceMultiplier =
                    1.0 - effectiveRes;
            }
            else
            {
                resistanceMultiplier =
                    1.0 / (1.0 + (effectiveRes * 4.0));
            }

            // Vulnerability
            double vulnerabilityMultiplier =
                1.0 + p.Vulnerability;

            // Final
            double result =
                baseDamage
                * dmgBoostMultiplier
                * critMultiplier
                * defenseMultiplier
                * resistanceMultiplier
                * vulnerabilityMultiplier
                * p.WeakenMultiplier
                * p.DamageMitigation
                * p.BrokenMultiplier
                * p.OriginalDamageMultiplier;

            return Math.Floor(result);
        }
    }
    }


