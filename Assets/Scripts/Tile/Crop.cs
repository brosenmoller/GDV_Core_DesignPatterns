using UnityEngine;

[CreateAssetMenu(menuName = "Crop", fileName = "New Crop")]
public class Crop : ScriptableObject
{
    public string CropName;
    public int GrowthChancePerTick;
    public GameObject[] cropPrefabs;
}

