
public abstract class ASEloPlayer
{
    public ASEloSystem system;
    public int elo;

    public virtual void ResetElo()
    {
        this.elo = system.startingElo;
    }
}
