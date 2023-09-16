using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_ChangeObject : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _objectToDeactivate, _objectToActivate;

    public void Behaviour()
    {
        _objectToDeactivate.SetActive(false);
        _objectToActivate.SetActive(true);
    }
}
