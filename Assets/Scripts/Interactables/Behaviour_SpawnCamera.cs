using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_SpawnCamera : MonoBehaviour, IBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _camera;
    public void Behaviour()
    {
        _camera.transform.position = _spawnPoint.transform.position;
        _camera.transform.rotation = _spawnPoint.transform.rotation;
    }
}
