public class PloughCommand : TileCommand, ICommand
{
    public PloughCommand(TileData _tileData) : base(_tileData) { }

    public void Execute()
    {
        tileData.RequiresUpdate = true;
        tileData.groundType = GameManager.Instance.availableGroundTypes[1];
    }
}

