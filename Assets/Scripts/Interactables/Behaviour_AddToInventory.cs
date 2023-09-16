using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_AddToInventory : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _objectToAdd;
    public void Behaviour()
    {
        PlayerController.Instance.Inventory.Add(_objectToAdd);
        print("Added " + _objectToAdd.name + " to inventory!");
    }
}
