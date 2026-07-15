using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData", menuName = "Potion Academy/Level Data")]

public class LevelData : ScriptableObject
{
    [System.Serializable]
    public class BottleContent
    {
        public List<Color> layers = new List<Color>();
    }

    [SerializeField] private List<BottleContent> bottles = new List<BottleContent>();
    public IReadOnlyList<BottleContent> Bottles => bottles;
}
