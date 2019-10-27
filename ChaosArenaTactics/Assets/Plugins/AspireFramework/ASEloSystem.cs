using UnityEngine;

public class ASEloSystem
{
    #region Properties

    //default values
    public int startingElo; //1500
    public int floorElo;    //100
    public int K;           //20 

    #endregion

    #region Constructors

    /// <summary>
    /// Creates an elo system with the default values:
    /// starting elo = 1500
    /// floor elo = 100
    /// k = 20
    /// </summary>
    public ASEloSystem() : this(1500, 100, 20) { }

    public ASEloSystem(int startingElo, int floorElo, int K)
    {
        this.startingElo = startingElo;
        this.floorElo = floorElo;
        this.K = K;
    }

    #endregion

    #region Methods

    public void SetupNewEloPlayer(ASEloPlayer player)
    {
        player.system = this;
        player.ResetElo();
    }

    public void Calculate(ASEloPlayer winner, ASEloPlayer loser)
    {
        //Expected result:
        //Ea = 1 / (1 + (10 ^ ((Rb-Ra)/400)))
        //New rating:
        //R'a = Ra + K * (1-Ea)

        float Ea = 0; //expected winrate for a
        float Eb = 0; //expected winrate for b
        float Ra = winner.elo;
        float Rb = loser.elo;

        Ea = 1 / (1 + (Mathf.Pow(10, (Rb - Ra) / 400)));
        Eb = 1 / (1 + (Mathf.Pow(10, (Ra - Rb) / 400)));

        Ra += K * Eb;
        Rb -= K * Ea;

        winner.elo = Mathf.RoundToInt(Ra);
        loser.elo = Mathf.RoundToInt(Rb);

        if (loser.elo < floorElo)
            loser.elo = floorElo;
    }

    #endregion
}
