using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_ChangeObject : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    [SerializeField] private GameObject _objectToDeactivate; 

    public void Behaviour()
    {
        if (_objectToDeactivate != null)
        {
            _objectToDeactivate.SetActive(false);
            _objectToDeactivate = null;
        } 
        if (_objectToActivate != null)
        {
            _objectToActivate.SetActive(true);
            _objectToActivate = null;
        }
    }
}
