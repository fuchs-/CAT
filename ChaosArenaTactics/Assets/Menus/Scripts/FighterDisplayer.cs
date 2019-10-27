using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FighterDisplayerClickedEvent : UnityEvent<FighterDisplayer> { }

public class FighterDisplayer : MonoBehaviour
{
    public FighterData data;
    private Image charImage;

    public FighterDisplayerClickedEvent onClick;

    private void Awake()
    {
        charImage = GetComponent<Image>();
        onClick = new FighterDisplayerClickedEvent();
    }

    public void DisplayFighter(FighterData data, Sprite charSprite)
    {
        this.data = data;
        this.charImage.sprite = charSprite;
    }

    public void Clicked()
    {
        onClick.Invoke(this);
    }
}
