using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<GameObject> Objects;
    [SerializeField] private int _inventoryCapacity = 4;
    [SerializeField] private GameObject _selectedObject;

    public void Add(GameObject inventoryObject)
    {
        if(Objects.Count < _inventoryCapacity)
        {
            Objects.Add(inventoryObject);
            string message = "Added " + inventoryObject.name + " to inventory!";
            UIManager.Instance.Message(message);

            UIManager.Instance.SelectInventoryItem();

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
            _selectedObject = null;

            string message = "Used " + inventoryObject.name + "!";
            UIManager.Instance.Message(message);
        }

        UpdateUI();
    }

    public GameObject SelectedObject(int index)
    {
        if(index < Objects.Count)
        {
            _selectedObject = Objects[index];
            return _selectedObject.GetComponent<Behaviour_AddToInventory>().ItemSprite;
        }
        else
        {
            _selectedObject = null;
            return null;
        }
    }

    public GameObject SelectedObject()
    {
        return _selectedObject;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _inventoryCapacity; i++)
        {
            if (i < Objects.Count && Objects[i] != null)
            {
                UIManager.Instance.UpdateInventoryIcons(i, Objects[i].GetComponent<Behaviour_AddToInventory>().Icon, true);
            }
            else
            {
                UIManager.Instance.UpdateInventoryIcons(i, null, false);
            }
        }
    }
}