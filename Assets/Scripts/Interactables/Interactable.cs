using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private List<GameObject> _requiredObjects;

    private PlayerInventory _inventory;

    private IBehaviour[] _behaviours;

    private void Awake()
    {
        _behaviours = GetComponents<IBehaviour>();
    }

    public void Interact()
    {
        _inventory = PlayerController.Instance.Inventory;

        if (_requiredObjects.Contains(_inventory.SelectedObject()))
        {
            _requiredObjects.Remove(_inventory.SelectedObject());
            _inventory.Use(_inventory.SelectedObject());

            if(_requiredObjects.Count > 0)
            {
                return;
            }
        }

        if (_requiredObjects.Count == 0)
        {
            for(int i = 0; i < _behaviours.Length; i++)
            {
                _behaviours[i].Behaviour();
            }
        }
        else
        {
            SoundManager.Instance.PlayError();
            string message = "Need " + _requiredObjects[0].name + "!";
            UIManager.Instance.Message(message);
        }
    }
}
