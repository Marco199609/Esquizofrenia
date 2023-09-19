using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIconUpdate : MonoBehaviour
{
    public void UpdateIcons(int iconIndex, Sprite icon, bool hasItem)
    {
        if(hasItem)
        {
            UIManager.Instance.InventoryIcons[iconIndex].sprite = icon;
            UIManager.Instance.InventoryIconBackgrounds[iconIndex].sprite = UIManager.Instance.InventoryFilledBackground;
        }
        else
        {
            UIManager.Instance.InventoryIcons[iconIndex].sprite = null;
            UIManager.Instance.InventoryIconBackgrounds[iconIndex].sprite = UIManager.Instance.InventoryEmptyBackground;
        }
    }
}
