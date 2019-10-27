using UnityEngine;

public class HeroPoolController : MonoBehaviour
{
    private GameObject selectedFighterInfoPrefab;

    void Start()
    {
        selectedFighterInfoPrefab = Resources.Load<GameObject>("Prefabs/SelectedFighterInfo");

        GameObject[] fighters = Resources.LoadAll<GameObject>("Prefabs/Fighters/");
        GameObject fighterInfo;

        foreach (GameObject go in fighters)
        {
            fighterInfo = Instantiate<GameObject>(selectedFighterInfoPrefab);
            fighterInfo.GetComponent<SelectedFighterInfoController>().SetFighter(go);

            fighterInfo.transform.SetParent(this.transform);
            fighterInfo.transform.position = Vector3.zero;
            fighterInfo.transform.localScale = Vector3.one;
        }
    }
}
