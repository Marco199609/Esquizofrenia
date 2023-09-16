using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<GameObject> Objects;

    public void Add(GameObject inventoryObject)
    {
        Objects.Add(inventoryObject);
    }
}
