using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_DoorOpen : MonoBehaviour, IBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private Transform _doorTarget;
    [SerializeField] private float _speed;

    [SerializeField] private bool _openDoor;

    public void Behaviour()
    {
        _openDoor = true;
    }


    void Update()
    {
        if(_openDoor)
        {
            _door.position = Vector3.Lerp(_door.position, _doorTarget.position, Time.deltaTime * _speed);
        }
    }
}
