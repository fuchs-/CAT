using System.Collections.Generic;

[System.Serializable]
public class UnitData
{
    public string id;           // "uchiha-itachi"
    public string name;         // "Itachi Uchiha"

    public float HP;
    public float HPRegen;
    public float MP;
    public float MPRegen;

    public float moveSpeed;
    public float armor;
    public float magicResistance;   //percentage

    public float attackDamage;
    public float attackSpeed;       //0-1 = 1 attack per turn. 1-2 = 2 attacks per turn ...
    public float attackRange;       //0 = doesn't attack, 1 = melee, >1 = ranged
    public float criticalChance;    //percentage
    public float criticalDamage;    //percentage, default 200%
    public float spellDamage;

    public AbilityData[] abilities;
    public EffectData[] effects;
}
