using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public Toggle tglTheNameGameMode;

    private void Awake()
    {
        tglTheNameGameMode.isOn = Settings.Instance.theNameGameModeActive;
    }

    public void TheNameGameModeToggled(bool active)
    {
        Settings.Instance.theNameGameModeActive = active;
    }
    
}
