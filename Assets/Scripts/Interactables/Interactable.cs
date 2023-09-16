using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _requiredObject;

    public void Interact()
    {
        if(_requiredObject == null || PlayerController.Instance.Inventory.Objects[0] == _requiredObject)
        {
            GetComponent<IBehaviour>().Behaviour();
        }
    }
}
