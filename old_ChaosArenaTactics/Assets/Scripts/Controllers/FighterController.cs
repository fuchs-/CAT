using UnityEngine;

public class FighterController : UnitController
{
    public Fighter FighterData { get {return (Fighter)base.UnitData; } }

    public static FighterController LoadFighterWithName(string name)
    {
        FighterController ret;

        ret = Resources.Load<GameObject>("Prefabs/Fighters/" + name).GetComponent<FighterController>();

        return ret;
    }
}
