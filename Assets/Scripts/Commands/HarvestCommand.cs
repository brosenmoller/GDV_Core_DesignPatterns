public class HarvestCommand : TileCommand
{
    public HarvestCommand(TileData _tileData) : base(_tileData) { }

    public override bool Check()
    {
        return tileData.IsSeeded && tileData.CurrentGrowthStage >= tileData.MaxGrowthStage;
    }

    public override void OnExecute()
    {
        tileData.IsHarvested = true;
    }
}

