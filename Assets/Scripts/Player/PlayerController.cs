using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerSelectObject), typeof(PlayerInventory))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;

    //Required Scripts
    private PlayerSelectObject _playerSelect;

    public PlayerInventory Inventory { get; private set; }

    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    void Start()
    {
        _playerSelect = GetComponent<PlayerSelectObject>();
        Inventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerSelect.Select();
    }
}
