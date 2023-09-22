using UnityEngine;

public struct TileData
{
    public readonly bool IsSeeded { get { return asscoiatedCrop != null; } }
    public bool IsWatered;
    public bool IsFertilized;
    public bool IsPloughed;
    public bool IsHarvestable;
    public int  CurrentGrowthStage;
    public bool RequiresUpdate;

    public Crop asscoiatedCrop;
    public GameObject TileGameObject;
    public GroundType groundType;

    public TileData(GameObject _gameObject, GroundType _groundType)
    {
        TileGameObject = _gameObject;
        groundType = _groundType;

        IsWatered = false;
        IsFertilized = false;
        IsPloughed = false;
        IsHarvestable = false;
        CurrentGrowthStage = 0;
        RequiresUpdate = true;

        asscoiatedCrop = null;
    }
}
