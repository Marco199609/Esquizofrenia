using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private GameObject[] _inventoryButtons;
    [SerializeField] private SpriteRenderer[] _inventoryIconBackgrounds;
    [field: SerializeField] public SpriteRenderer[] InventoryIcons;

    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public void Message(string message)
    {
        StartCoroutine(DisplayMessage(message, 2));
    }

    private IEnumerator DisplayMessage(string message, float delay)
    {
        _messageText.gameObject.SetActive(true);
        _messageText.text = message;

        yield return new WaitForSeconds(delay);

        _messageText.text = "";
        _messageText.gameObject.SetActive(false);
    }

    public void SelectInventoryItem()
    {
        SoundManager.Instance.PlayClick();
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        for(int i = 0; i < _inventoryButtons.Length; i++)
        {
            if(button == _inventoryButtons[i].gameObject)
            {
                _inventoryIconBackgrounds[i].color = Color.green;
                PlayerController.Instance.Inventory.UISelectedObject(i);
            }
            else
            {
                _inventoryIconBackgrounds[i].color = Color.white;
            }
        }
    }
}
