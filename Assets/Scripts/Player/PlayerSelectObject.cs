using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectObject : MonoBehaviour
{
    public void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    hit.collider.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
