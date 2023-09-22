public class PloughCommand : TileCommand, ICommand
{
    public PloughCommand(TileData _tileData) : base(_tileData) { }

    public void Execute()
    {
        tileData.IsPloughed = true;
    }
}

