using UnityEngine;

[CreateAssetMenu(menuName = "Crop", fileName = "New Crop")]
public class Crop : ScriptableObject
{
    public string Name;
    public int GrowthChancePerTick;
    public GameObject[] cropPrefabs;
}

