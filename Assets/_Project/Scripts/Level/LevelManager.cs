using System;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData currentLevel;
    [SerializeField] private Bottle[] bottles;

    public event Action LevelCompleted;
    public bool IsLevelComplete { get; private set; }

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        if(currentLevel == null)
        {
            Debug.LogError("LevelManager: No level assigned.", this);
            return;
        }

        IReadOnlyList<LevelData.BottleContent> contents = currentLevel.Bottles;

        for(int i = 0; i < bottles.Length; i++)
        {
            if (i < contents.Count)
            {
                bottles[i].LoadLayers(contents[i].layers);
            }
            else
            {
                bottles[i].LoadLayers(new List<Color>());
            }
        }
    }

    public void CheckWin()
    {
        foreach (Bottle bottle in bottles)
        {
            if (!bottle.IsComplete)
            {
                return;
            }
        }

        IsLevelComplete = true;
        LevelCompleted?.Invoke();
    }
}