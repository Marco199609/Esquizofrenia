using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _requiredObject;

    private PlayerInventory _inventory;

    public void Interact()
    {
        _inventory = PlayerController.Instance.Inventory;

        if (_requiredObject == null)
        {
            GetComponent<IBehaviour>().Behaviour();
        }
        else if (_inventory.SelectedObject() == _requiredObject)
        {
            _inventory.Use(_requiredObject);
            _requiredObject = null;

            GetComponent<IBehaviour>().Behaviour();
        }
        else
        {
            SoundManager.Instance.PlayError();
            string message = "Need " + _requiredObject.name + "!";
            UIManager.Instance.Message(message);
        }
    }


}
