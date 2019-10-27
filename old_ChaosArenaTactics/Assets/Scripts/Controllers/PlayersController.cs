using UnityEngine;

public class PlayersController : MonoBehaviour
{
    #region Instance Stuff

    public static PlayersController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            //this.LoadSettings();
        }
        else if (Instance != this) Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        if (Instance == this) Instance = null;
        Players = null;
    }

    #endregion

    public Player[] Players { get; set; }

    public int NumOfPlayers
    {
        get
        {
            if (Players != null)
            {
                return Players.Length;
            }
            return 0;
        }
    }
}
