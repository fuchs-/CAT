using UnityEngine;

public class Settings : MonoBehaviour
{
    #region Instance Stuff

    public static Settings Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            this.LoadSettings();
        }
        else if (Instance != this) Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    #endregion

    public bool theNameGameModeActive = false;

    private void LoadSettings()
    {
        //The Name Game Mode

        int tng = PlayerPrefs.GetInt("TheNameGameMode");
        if (tng != 0)
            this.theNameGameModeActive = true;
    }

    public static void SaveSettings()
    {
        //The Name Game Mode

        int tng = 0;
        if (Instance.theNameGameModeActive) tng = 1;
        PlayerPrefs.SetInt("TheNameGameMode", tng);


        PlayerPrefs.Save();
    }
}
