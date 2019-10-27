using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class uses UnityEngine.Random
/// </summary>
public static class AS_RNG
{
    //Initializes the generator
    static AS_RNG()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    #region Dice Rolls

    public static int d4 { get { return AS_RNG.RollDie(4); } }
    public static int d6 { get { return AS_RNG.RollDie(6); } }
    public static int d8 { get { return AS_RNG.RollDie(8); } }
    public static int d10 { get { return AS_RNG.RollDie(10); } }
    public static int d12 { get { return AS_RNG.RollDie(12); } }
    public static int d20 { get { return AS_RNG.RollDie(20); } }
    public static int d100 { get { return AS_RNG.RollDie(100); } }

    public static int RollDie(int sides)
    {
        if (sides < 1)
            return -1;
        if (sides == 1)
            return 1;

        return AS_RNG.Next(1, sides + 1);
    }

    #endregion

    #region Integers

    /// <summary>
    /// returns a random integer between lower (inclusive) and upper (exclusive)
    /// </summary>
    public static int Next(int lower, int upper)
    {
        return Random.Range(lower, upper);
    }

    /// <summary>
    /// returns a random integer between 0 (inclusive) and upper (exclusive)
    /// identical to: AS_RNG.Next(0, upper)
    /// </summary>
    public static int Next(int upper)
    {
        return AS_RNG.Next(0, upper);
    }

    /// <summary>
    /// returns a random integer between 0 and 100 (inclusive)
    /// identical to AS_RNG.Next(1, 101)
    /// </summary>
    /// <returns></returns>
    public static int Next()
    {
        return AS_RNG.Next(0, 101);
    }

    #endregion

    #region Others

    public static TItem NextItem<TItem>(IEnumerable<TItem> collection)
    {
        List<TItem> list = new List<TItem>();

        foreach (TItem item in collection)
            list.Add(item);

        return list[AS_RNG.Next(list.Count)];
    }

    /// <summary>
    /// returns a float between lower (inclusive) and upper (inclusive)
    /// </summary>
    public static float NextFloat(float lower, float upper)
    {
        return Random.Range(lower, upper);
    }

    public static bool NextBool()
    {
        return AS_RNG.Next(0, 2) == 1;
    }

    #endregion
}
