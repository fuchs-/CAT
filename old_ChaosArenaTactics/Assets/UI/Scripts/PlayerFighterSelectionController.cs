using UnityEngine;
using UnityEngine.UI;

public class PlayerFighterSelectionController : MonoBehaviour
{
    public int playerID = 0;
    public InputField txf_playerName;
    public GameObject fightersContainer;

    //Hero info prefab
    private GameObject fighterInfo;

    private void Awake()
    {
        GameObject placeholder = txf_playerName.transform.GetChild(0).gameObject;
        placeholder.GetComponent<Text>().text = "Insert Player " + playerID + " Name";

        fighterInfo = Resources.Load<GameObject>("FighterSelectedInfo");
    }

    public bool hasFighterSelected { get { return fightersContainer.transform.childCount > 0; } }

    public bool isReadyToStartGame { get { return hasFighterSelected; } }


    public bool AddFighter(GameObject fighterInfo)
    {
        if (!hasFighterSelected)
        {
            fighterInfo.transform.SetParent(fightersContainer.transform);
            return true;
        }

        return false;
    }

    public Player CreatePlayer()
    {
        Player ret;
        string name = txf_playerName.text;

        if (string.IsNullOrEmpty(name))
            ret = new Player(playerID);
        else
            ret = new Player(playerID, name);

        SelectedFighterInfoController fighterInfo = fightersContainer.GetComponentInChildren<SelectedFighterInfoController>();

        ret.Fighters = new FighterController[1];

        ret.Fighters[0] = fighterInfo.getFighter();

        return ret;
    }
}
