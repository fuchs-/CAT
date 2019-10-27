using UnityEngine;

public enum TileType
{
    Empty,
    Floor,
    Wall,
    Water,
    Lava
}

[CreateAssetMenu(menuName = "CAT/TileData")]
public class TileData : ScriptableObject
{
    #region Fields and Properties

    //Tile coordinates
    public int x;
    public int y;
    public Position position
    {
        get { return new Position(x, y); }
        set
        {
            this.x = value.x;
            this.y = value.y;
        }
    }

    public TileType type;

    //MOVEMENT COST - INT 1-5
    //if 5 	- not walkable
    //if 1	- Full speed
    //1 - 100%
    //2 - 75%
    //3 - 50%
    //4 - 25%
    //5 - 0%
    [Range(1, 5)]
    public int movementCost;
    public virtual bool isWalkable { get { return this.movementCost < 5; } }

    #endregion
}
