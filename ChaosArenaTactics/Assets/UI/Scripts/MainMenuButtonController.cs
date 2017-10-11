using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
    public void Btn_Close()
    {
        Debug.Log("Closing Application");
        Application.Quit();
    }

}
