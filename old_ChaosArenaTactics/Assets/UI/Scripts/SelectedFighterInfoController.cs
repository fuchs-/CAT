using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedFighterInfoController : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    public Text text;

    public GameObject Fighter { get; private set; }

    public bool isInFighterPool;

    public void SetFighter(GameObject fighterGO)
    {
        this.Fighter = fighterGO;

        Fighter f = fighterGO.GetComponent<FighterController>().FighterData;

        text.text = f.FighterName;

        string s = "Fighters/" + f.FighterName + "/char";

        Sprite sprite = Resources.Load<Sprite>(s);

        if (!sprite)
            Debug.LogError("Sprite '" + s + "' is null");
        else
            image.sprite = sprite;

        isInFighterPool = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject go = GameObject.FindGameObjectWithTag("ButtonController");
        FighterSelectionButtonController btn_ctrl = go.GetComponent<FighterSelectionButtonController>();

        if (!go) Debug.LogError("Couldn't find go with tag ButtonController");
        if (!btn_ctrl) Debug.LogError("Couldn't find component FighterSelectionButtonController");


        btn_ctrl.FighterClicked(this.gameObject);
    }

    public FighterController getFighter()
    {
        return FighterController.LoadFighterWithName(text.text);
    }
}
