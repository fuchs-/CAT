using UnityEngine;

public class NotificationSystem : MonoBehaviour {

    #region Properties

    public Notification notificationPrefab;

    public int delayTime;
    public int fadeTime;

    #endregion

    #region Methods

    public void PushWithDelayAndFadeTime(string text, int delay, int fade)
    {
        Notification n = Instantiate<Notification>(notificationPrefab);

        n.transform.SetParent(this.transform);
        n.transform.localScale = Vector3.one;
        n.Show(text, delay, fade);
    }

    public void Push(string text)
    {
        this.PushWithDelayAndFadeTime(text, delayTime, fadeTime);
    }

    #endregion
}
