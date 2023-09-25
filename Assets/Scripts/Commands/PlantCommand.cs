public class PlantCommand : TileCommand
{
    private readonly Crop crop;

    public PlantCommand(TileData _tileData, Crop _crop) : base(_tileData) 
    {
        crop = _crop; 
    }

    public override bool Check()
    {
        return tileData.groundType == GameManager.Instance.availableGroundTypes[1] && !tileData.IsSeeded;
    }

    public override void OnExecute()
    {
        tileData.asscoiatedCrop = crop;
    }
}

