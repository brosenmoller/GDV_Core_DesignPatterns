using UnityEngine;

public class TileData
{
    public bool IsSeeded { get { return asscoiatedCrop != null; } }
    public bool IsWatered;
    public bool IsFertilized;
    public bool IsPloughed;
    public bool IsHarvestable;
    public int  CurrentGrowthStage;
    public bool RequiresUpdate;

    public Crop asscoiatedCrop;
    public GroundType groundType;

    public TileData(GroundType _groundType)
    {
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
