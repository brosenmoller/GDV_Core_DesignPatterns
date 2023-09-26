public class PloughCommand : TileCommand, ICommand
{
    public PloughCommand(TileData _tileData) : base(_tileData) { }

    public override bool Check()
    {
        return tileData.groundType == GameManager.Instance.availableGroundTypes[0];
    }

    public override void OnExecute()
    {
        tileData.groundType = GameManager.Instance.availableGroundTypes[1];
    }
}

