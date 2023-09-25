using UnityEngine;

public class SelectionManager
{
    private readonly Camera mainCamera;
    private readonly Material hoverMaterial;

    private TileObject currentHover;

    public SelectionManager(Material _hoverMaterial)
    {
        mainCamera = Camera.main;
        hoverMaterial = _hoverMaterial;
    }

    public void OnTick()
    {
        if (TryGetTileObjectFromMouseRay(out TileObject tileObject))
        {
            if (currentHover != null) 
            { 
                currentHover.MeshRenderer.materials = currentHover.TileData.groundType.Model.materials; 
            }
            currentHover = tileObject;

            currentHover.MeshRenderer.material = hoverMaterial;
        }
        else 
        {
            if (currentHover != null)
            {
                currentHover.MeshRenderer.materials = currentHover.TileData.groundType.Model.materials;
            }

            currentHover = null;
        }
    }

    public void OnSelect()
    {
        if (currentHover == null) { return; }
        ExecuteCurrentCommand();
    }
    private void ExecuteCurrentCommand()
    {
        switch (GameManager.Instance.currentCommandType)
        {
            case TileCommandType.HARVEST:
                new HarvestCommand(currentHover.TileData).Execute();
                break;
            case TileCommandType.PLANT_BEET:
                new PlantCommand(currentHover.TileData, GameManager.Instance.availableCrops[0]).Execute();
                break;
            case TileCommandType.PLANT_TOMATO:
                new PlantCommand(currentHover.TileData, GameManager.Instance.availableCrops[1]).Execute();
                break;
            case TileCommandType.PLOUGH:
                new PloughCommand(currentHover.TileData).Execute();
                break;
        }
    }

    private bool TryGetTileObjectFromMouseRay(out TileObject tileObject)
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, 1000))
        {
            foreach (TileObject tile in GameManager.Instance.land)
            {
                if (tile.Transform == hit.transform)
                {
                    tileObject = tile;
                    return true;
                }
            }
        }

        tileObject = null; 
        return false;
    }
}

