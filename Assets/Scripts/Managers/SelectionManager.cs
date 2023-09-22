using UnityEngine;

public class SelectionManager
{
    private readonly Camera mainCamera;

    public SelectionManager()
    {
        mainCamera = Camera.main;
    }

    public void OnTick()
    {

    }

    public void OnSelect()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, 1000))
        {
            
        }
    }
}

