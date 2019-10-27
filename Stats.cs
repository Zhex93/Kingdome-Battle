using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int level;
    public int experience;
    public int intelligence; // Ataque mágico y maná
    public int strength; // Ataque físico y energía
    public int dexterity; // Velocidad, % de crítico, y esquive
    public int constitution; // Vida y def. física
    public int wisdom; // Def. mágica y maná
    public int statsPoints;

    public int maxHp;
    public int hp;
    public int maxMp;
    public int mp;
}
