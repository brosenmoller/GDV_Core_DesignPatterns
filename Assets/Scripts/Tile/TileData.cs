public class TileData
{
    public bool IsSeeded { get { return asscoiatedCrop != null; } }
    public int MaxGrowthStage { get { if (IsSeeded) { return asscoiatedCrop.cropPrefabs.Length - 1; } return 0; } }
    public bool IsWatered;
    public bool IsFertilized;
    public bool IsHarvestable;
    public int  CurrentGrowthStage;
    public bool RequiresUpdate;
    public bool IsHarvested;

    public Crop asscoiatedCrop;
    public GroundType groundType;

    public TileData(GroundType _groundType)
    {
        groundType = _groundType;

        IsWatered = false;
        IsHarvested = false;
        IsFertilized = false;
        IsHarvestable = false;
        CurrentGrowthStage = 0;
        RequiresUpdate = true;

        asscoiatedCrop = null;
    }
}
