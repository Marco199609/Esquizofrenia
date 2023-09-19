using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICursorManager : MonoBehaviour
{
    private RaycastHit mouseRaycastHit;

    public void ManageCursor(Texture2D genericCursor, Texture2D interactableCursor)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseRaycastHit))
        {
            if (mouseRaycastHit.collider.GetComponent<Interactable>() == null)
            {
                Cursor.SetCursor(genericCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(interactableCursor, Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(genericCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
