using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formulas
{
    public static int GetMaxHp(Stats stats)
    {
        return Mathf.RoundToInt(10f * stats.level + 2f * stats.constitution);
    }
    public static int GetMaxMp(Stats stats)
    {
        return Mathf.RoundToInt(5f * stats.level + 1.5f * stats.intelligence + 1.5f * stats.wisdom);
    }
    public static int GetPhysicalDamage(Stats attacker, Stats defender, int multiplier)
    {
        return Mathf.RoundToInt((1.2f * attacker.level) + (1.5f * attacker.strength) - defender.constitution);
    }
    public static int GetMagicalDamage(Stats attacker, Stats defender, int multiplier)
    {
        return Mathf.RoundToInt((1.2f * attacker.level) + (1.5f * attacker.intelligence) - defender.wisdom);
    }
    public static int ManaCost(Stats stats)
    {
        return Mathf.RoundToInt((0.8f * stats.level) + (1f * stats.intelligence) - (0.6f * stats.wisdom));
    }
}
