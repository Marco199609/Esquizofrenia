using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UIHandManager : MonoBehaviour
{
    public bool ShowHand;

    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _handOrigin;
    [SerializeField] private Transform _handOnScreen;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _showHandDelay;
    [SerializeField] private GameObject[] _itemSprites;

    void Update()
    {
        if(ShowHand)
        {
            _hand.position = Vector3.Lerp(_hand.position, _handOnScreen.position, Time.deltaTime * _moveSpeed);
        }
        else
        {
            _hand.position = Vector3.Lerp(_hand.position, _handOrigin.position, Time.deltaTime * _moveSpeed * 2);
        }
    }

    public void ActivateItemSprite(GameObject item)
    {
        if(ShowHand == false) 
        {
            _showHandDelay = 0;
        }
        else if (ShowHand == true)
        {
            _showHandDelay = 0.5f;
            ShowHand = false;
        }

        StartCoroutine(ShowHandDelay(_showHandDelay, item));
    }

    private IEnumerator ShowHandDelay(float delay, GameObject item)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < _itemSprites.Length; i++)
        {
            if (_itemSprites[i] == item)
            {
                _itemSprites[i].SetActive(true);
            }
            else
            {
                _itemSprites[i].SetActive(false);
            }
        }
        ShowHand = true;
    }
}
