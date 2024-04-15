using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        System.Random rng = new();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }
    public static void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        System.Random rng = new();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
