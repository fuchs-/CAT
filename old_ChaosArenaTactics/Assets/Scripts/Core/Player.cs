public class Player
{
    public int Index { get; protected set; }
    public string PlayerName { get; protected set; }

    public FighterController[] Fighters { get; set; }

    public Player(int index, string name)
    {
        this.Index = index;
        this.PlayerName = name;
    }

    public Player(int index) : this(index, "Player" + (index)) { }
}
