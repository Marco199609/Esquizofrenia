using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_AddToInventory : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _objectToAdd;
    [field:SerializeField] public Sprite Icon {  get; private set; }
    public void Behaviour()
    {
        PlayerController.Instance.Inventory.Add(_objectToAdd);
    }
}
