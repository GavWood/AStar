using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class BWRandom
{
    private static System.Random randSingleton = new System.Random(1234);

    public static void Reset()
    {
        randSingleton = new System.Random(1234);
    }

    private static int RandomChance(System.Random rng, int min, int max)
    {
        return rng.Next(min, max);
    }

    public static int RandomInt(int minInclusive, int maxExclusive)
    {
        return RandomChance(BWRandom.randSingleton, minInclusive, maxExclusive);
    }
    public static bool IsHeads()
    {
        return RandomChance(BWRandom.randSingleton, 0, 2) == 0;
    }
}
