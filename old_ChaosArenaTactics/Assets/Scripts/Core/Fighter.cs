using UnityEngine;

[CreateAssetMenu(menuName = "CAT/Fighter")]
public class Fighter : Unit
{
    public string FighterName
    {
        get { return this.UnitName; }
        protected set { this.UnitName = value; }
    }
}
