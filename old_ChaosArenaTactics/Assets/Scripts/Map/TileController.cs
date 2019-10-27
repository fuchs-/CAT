using UnityEngine;

//Controls a single tile gameobject
public class TileController : MonoBehaviour
{
    public TileData tileData;

    public void moveToPosition(Position p)
    {
        tileData.position = p;
        transform.position = p.vector3;
    }
}
