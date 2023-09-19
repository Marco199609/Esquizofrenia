using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    private UIHandManager _UIHandManager;

    [SerializeField] private TextMeshProUGUI _messageText;

    [Header("Inventory UI")]
    [SerializeField] private List<GameObject> _inventoryButtons;
    [field: SerializeField] public SpriteRenderer[] InventoryIcons;
    [SerializeField] public SpriteRenderer[] InventoryIconBackgrounds;
    [SerializeField] public Sprite InventoryEmptyBackground;
    [SerializeField] public Sprite InventoryFilledBackground;

    [Header("Cursor")]
    [SerializeField] private Texture2D _genericCursor;
    [SerializeField] private Texture2D _interactableCursor;



    public static UIManager Instance { get; private set; }

    private RaycastHit mouseRaycastHit;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        _UIHandManager = GetComponent<UIHandManager>();
    }

    private void Update()
    {
        ManageCursor();
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

        if(_inventoryButtons.Contains(button))
        {
            for (int i = 0; i < _inventoryButtons.Count; i++)
            {
                if (button == _inventoryButtons[i].gameObject)
                {
                    InventoryIconBackgrounds[i].color = new Color(0, 1, 0, 1f);

                    if (PlayerController.Instance.Inventory.SelectedObject(i) == null)
                    {
                        _UIHandManager.ShowHand = false;
                    }
                    else
                    {
                        _UIHandManager.ActivateItemSprite(PlayerController.Instance.Inventory.SelectedObject(i));
                    }
                }
                else
                {
                    InventoryIconBackgrounds[i].color = new Color(1, 1, 1, 1f);
                }
            }
        }
        else
        {
            _UIHandManager.ShowHand = false;

            for (int i = 0; i < _inventoryButtons.Count; i++)
            {
                InventoryIconBackgrounds[i].color = new Color(1, 1, 1, 1f);
            }
        }
    }

    private void ManageCursor()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseRaycastHit))
        {
            if (mouseRaycastHit.collider.GetComponent<Interactable>() == null)
            {
                Cursor.SetCursor(_genericCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(_interactableCursor, Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(_genericCursor, Vector2.zero, CursorMode.Auto);
        }  
    }
}
