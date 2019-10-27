using UnityEngine;

public class TNG_MMImageController : MonoBehaviour
{
    void Start()
    {
        if (!Settings.Instance.theNameGameModeActive)
            Destroy(this.gameObject);

        foreach (Transform t in this.transform) t.gameObject.SetActive(true);
    }
}
