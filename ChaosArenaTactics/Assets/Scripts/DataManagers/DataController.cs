using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController _instance;

    public static FileSystemHelper FileSystem;
    public static SpriteLoader Sprites;
    public static FighterLoader Fighters;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        FileSystem = new FileSystemHelper();
        Sprites = new SpriteLoader();
        Fighters = new FighterLoader();
    }
}
