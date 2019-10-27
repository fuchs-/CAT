using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Notification : MonoBehaviour
{
    #region Properties

    private Text text;
    private float delayTime;
    private float fadingTime;

    #endregion

    #region Methods

    void Awake()
    {
        text = GetComponent<Text>();
        gameObject.SetActive(false);
    }

    public void AutoDestruct()
    {
        Destroy(gameObject);
    }

    public void LaunchFade()
    {
        Hashtable hash = iTween.Hash();

        hash.Add("alpha", 0);
        hash.Add("delay", delayTime);
        hash.Add("time", fadingTime);
        hash.Add("onCompleteTarget", this.gameObject);
        hash.Add("onComplete", "AutoDestruct");

        iTween.FadeTo(this.gameObject, hash);
    }

    public void Show(string text, int delayTime, int fadingTime)
    {
        this.text.text = text;
        this.delayTime = delayTime;
        this.fadingTime = fadingTime;

        gameObject.SetActive(true);

        LaunchFade();
    }

    #endregion
}
