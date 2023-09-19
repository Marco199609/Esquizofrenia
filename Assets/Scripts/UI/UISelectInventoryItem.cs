using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectInventoryItem : MonoBehaviour
{
    public void SelectInventoryItem(List<GameObject> inventoryButtons, SpriteRenderer[] inventoryIconBackgrounds, UIHandManager UIHandManager)
    {
        SoundManager.Instance.PlayClick();
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        if (inventoryButtons.Contains(button))
        {
            for (int i = 0; i < inventoryButtons.Count; i++)
            {
                if (button == inventoryButtons[i].gameObject)
                {
                    inventoryIconBackgrounds[i].color = new Color(0, 1, 0, 1f);

                    if (PlayerController.Instance.Inventory.SelectedObject(i) == null)
                    {
                        UIHandManager.ShowHand = false;
                    }
                    else
                    {
                        UIHandManager.ActivateItemSprite(PlayerController.Instance.Inventory.SelectedObject(i));
                    }
                }
                else
                {
                    inventoryIconBackgrounds[i].color = new Color(1, 1, 1, 1f);
                }
            }
        }
        else
        {
            UIHandManager.ShowHand = false;

            for (int i = 0; i < inventoryButtons.Count; i++)
            {
                inventoryIconBackgrounds[i].color = new Color(1, 1, 1, 1f);
            }
        }
    }
}
