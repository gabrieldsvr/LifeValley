using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Collectable;

public class SeedManager : MonoBehaviour
{
    public Seed[] seeds;


    public Dictionary<string, Seed> seedSelected =
        new Dictionary<string, Seed>();

    private void Awake()
    {
        foreach (Seed seed in seeds)
        {
            AddSeed(seed);
        }
        Debug.Log("seeds");
    }

    private void AddSeed(Seed seed)
    {
        if (!seedSelected.ContainsKey(seed.GetName()))
        {
            seedSelected.Add(seed.GetName(),seed);
        }
    }

    public Seed GetSeedByName(string key)
    {
        if (seedSelected.ContainsKey(key))
        {
            return seedSelected[key];
        }

        return null;
    }
    public  Dictionary<string,Seed> GetAllSeeds()
    {
        return seedSelected;
    }
}