
[System.Serializable]
public class AbilityData
{
    public string id;                   //"itachi-tsukuyomi"
    public string name;                 //"Tsukuyomi"
    public string scriptFunctionName;   //"tsukuyomi"
    public string image;  //"sharingan-level-1"

    public string type;         //"unit-target"
    public int maxLevel;        //4
    public bool isUltimate;     //false

    public string manaCost;     //"35,40,45,50"
    public string cooldown;     //"11,9,7,5"
    public string castRange;    //"5"
    public string area;         //"3"
    public string areaType;     //"cone"

    public string[][] levelUpRequires;  //[["itachi-sharingan:4","fighter:8"],["fighter:12"],["fighter:16"],["fighter:20"]]
    public string[][] requires;         //[["itachi-sharingan:active"]]
}
