using System.Collections.Generic;
using UnityEngine;

public class FighterSelectionMenu : MonoBehaviour
{
    public Transform fightersPanel;
    public Transform player1Panel;
    public Transform player2Panel;

    public FighterDisplayer fighterDisplayerPrefab;

    private bool player1HasFighter { get { return player1Panel.GetComponentInChildren<FighterDisplayer>() != null; } }
    private bool player2HasFighter { get { return player2Panel.GetComponentInChildren<FighterDisplayer>() != null; } }

    void Start()
    {
        Dictionary<string, Sprite> chars = DataController.Sprites.LoadAllChars();

        foreach (FighterData data in DataController.Fighters.getFighterData())
        {
            FighterDisplayer fd = Instantiate(fighterDisplayerPrefab);
            fd.DisplayFighter(data, chars[data.id]);
            fd.onClick.AddListener(FighterDisplayerClicked);

            addDisplayerToPanel(fd, fightersPanel);
        }
    }

    public void FighterDisplayerClicked(FighterDisplayer displayer)
    {
        if (displayer.transform.parent == fightersPanel)
        {
            if (player1HasFighter)
            {
                addDisplayerToPanel(displayer, player2Panel);
            }
            else
            {
                addDisplayerToPanel(displayer, player1Panel);
            }
        }
        else
        {
            addDisplayerToPanel(displayer, fightersPanel);
        }
    }

    private void addDisplayerToPanel(FighterDisplayer displayer, Transform panel)
    {
        displayer.transform.SetParent(panel);
        displayer.transform.localScale = Vector3.one;
    }

    //button
    public void Play()
    {
        if (!player1HasFighter || !player2HasFighter)
            return;

        Debug.Log("Launching Game");
    }
}
