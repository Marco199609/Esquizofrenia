using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _requiredObject;

    private List<GameObject> _inventory;

    public void Interact()
    {
        _inventory = PlayerController.Instance.Inventory.Objects;

        if (_requiredObject == null || _inventory.Count > 0 &&  _inventory[0] == _requiredObject)
        {
            GetComponent<IBehaviour>().Behaviour();
        }
        else
        {
            print("Need " + _requiredObject.name + "!");
        }
    }
}
