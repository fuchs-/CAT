using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public virtual void Btn_BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Btn_Close()
    {
        Debug.Log("Closing Application");
        Application.Quit();
    }
}
