using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : ButtonController
{
    public void Btn_Play()
    {
        SceneManager.LoadScene("FighterSelectionMenu");
    }

    public void Btn_Fighters()
    {
        Debug.LogWarning("Fighters button not implemented yet!");
    }

    public void Btn_Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

}
