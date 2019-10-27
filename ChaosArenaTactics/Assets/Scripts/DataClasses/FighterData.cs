
[System.Serializable]
public class FighterData : UnitData
{
    public string shortName;    // "Itachi"
    public string universe;     // "Naruto"
    public string affiliation;  // "Akatsuki"

    // game balance 
    public float power;

    public float strength;      //starting 
    public float strengthGain;  //per level
    public float agility;
    public float agilityGain;
    public float intelligence;
    public float intelligenceGain;
}
