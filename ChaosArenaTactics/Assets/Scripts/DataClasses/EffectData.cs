using System.Collections.Generic;

[System.Serializable]
public class EffectData
{
    public string id;
    public string name;
    public string type;
    public string duration;
    public EffectDispellable dispellableType;
    public Dictionary<string, string> attributes;
}
