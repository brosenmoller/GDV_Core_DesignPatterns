using UnityEngine;

public class InputManager
{
    public void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.InvokeEvent(EventType.ON_SELECT);
        }
    }
}

