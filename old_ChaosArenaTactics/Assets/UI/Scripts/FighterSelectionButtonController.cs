using UnityEngine;
using UnityEngine.SceneManagement;

public class FighterSelectionButtonController : ButtonController {

    public GameObject fighterPool;
    public PlayerFighterSelectionController player1Box;
    public PlayerFighterSelectionController player2Box;

    public void FighterClicked(GameObject fighterInfo)
    {
        SelectedFighterInfoController controller = fighterInfo.GetComponent<SelectedFighterInfoController>();

        if (controller.isInFighterPool)
        {
            if (player1Box.AddFighter(fighterInfo))
            {
                controller.isInFighterPool = false;
            }
            else if (player2Box.AddFighter(fighterInfo))
            {
                controller.isInFighterPool = false;
            }
        }
        else
        {
            fighterInfo.transform.SetParent(fighterPool.transform, false);
            controller.isInFighterPool = true;
        }
    }

    private bool isGameReadyToStart()
    {
        return player1Box.isReadyToStartGame && player2Box.isReadyToStartGame;
    }

    public void Btn_StartMatch()
    {
        if (!isGameReadyToStart()) return;

        PlayersController playersController = PlayersController.Instance;

        playersController.Players = new Player[2];

        playersController.Players[0] = player1Box.CreatePlayer();
        playersController.Players[1] = player2Box.CreatePlayer();

        SceneManager.LoadScene("Game");
    }

}
