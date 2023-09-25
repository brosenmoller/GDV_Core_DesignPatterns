public abstract class TileCommand : ICommand
{
    protected TileData tileData;

    public TileCommand(TileData _tileData)
    {
        tileData = _tileData;
    }

    public void Execute()
    {
        if (Check())
        {
            tileData.RequiresUpdate = true;
            OnExecute();
        }
    }

    public abstract bool Check();
    public abstract void OnExecute();
}


