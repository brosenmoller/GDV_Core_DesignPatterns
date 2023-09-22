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
        new PloughCommand(currentHover.TileData).Execute();
        Debug.Log("Plough: " + currentHover.TileData.groundType.name);
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

