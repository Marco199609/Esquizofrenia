using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_ChangeObject : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    [SerializeField] private GameObject _objectToDeactivate; 

    public void Behaviour()
    {
        _objectToDeactivate.SetActive(false);
        _objectToActivate.SetActive(true);
    }
}
