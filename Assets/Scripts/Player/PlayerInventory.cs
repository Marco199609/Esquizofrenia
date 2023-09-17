using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<GameObject> Objects;
    [SerializeField] private int _inventoryCapacity = 4;

    private GameObject _selectedObject;

    public void Add(GameObject inventoryObject)
    {
        if(Objects.Count < _inventoryCapacity)
        {
            Objects.Add(inventoryObject);
            string message = "Added " + inventoryObject.name + " to inventory!";
            UIManager.Instance.Message(message);

            inventoryObject.SetActive(false);
        }
        else
        {
            string message = "Inventory full!";
            UIManager.Instance.Message(message);
            SoundManager.Instance.PlayError();
        }

        UpdateUI();
    }

    public void Use(GameObject inventoryObject)
    {
        if(Objects.Contains(inventoryObject))
        {
            Objects.Remove(inventoryObject);
            Destroy(inventoryObject);
        }

        UpdateUI();
        UIManager.Instance.SelectInventoryItem();
    }

    public void UISelectedObject(int index)
    {
        if(index < Objects.Count)
            _selectedObject = Objects[index];
        else
            _selectedObject = null;
    }

    public GameObject SelectedObject()
    {
        return _selectedObject;
    }

    private void UpdateUI()
    {
        for(int i = 0; i < _inventoryCapacity; i++)
        {
            if(i < Objects.Count && Objects[i] != null)
            {
                UIManager.Instance.InventoryIcons[i].sprite = Objects[i].GetComponent<Behaviour_AddToInventory>().Icon;
                UIManager.Instance.InventoryIcons[i].color = Color.white;
            }
            else
            {
                UIManager.Instance.InventoryIcons[i].sprite = null;
                UIManager.Instance.InventoryIcons[i].color = new Color(1, 1, 1, 0);
            }
        }
    }
}