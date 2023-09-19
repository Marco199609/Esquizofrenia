using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

[RequireComponent(typeof(UIHandManager), typeof(UICursorManager), typeof(UISelectInventoryItem))]
[RequireComponent (typeof(UIMessageDisplay), typeof(UIIconUpdate))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageText;

    [Header("Inventory UI")]
    [SerializeField] private List<GameObject> _inventoryButtons;
    [SerializeField] public SpriteRenderer[] InventoryIcons;
    [SerializeField] public SpriteRenderer[] InventoryIconBackgrounds;
    [SerializeField] public Sprite InventoryEmptyBackground;
    [SerializeField] public Sprite InventoryFilledBackground;

    [Header("Cursor")]
    [SerializeField] private Texture2D _genericCursor;
    [SerializeField] private Texture2D _interactableCursor;

    public static UIManager Instance { get; private set; }
    private UIHandManager _UIHandManager;
    private UICursorManager _UICursorManager;
    private UISelectInventoryItem _UISelectInventoryItem;
    private UIMessageDisplay _UImessageDisplay;
    private UIIconUpdate _UIiconUpdate;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        _UIHandManager = GetComponent<UIHandManager>();
        _UICursorManager = GetComponent<UICursorManager>();
        _UISelectInventoryItem = GetComponent<UISelectInventoryItem>();
        _UImessageDisplay = GetComponent<UIMessageDisplay>();
        _UIiconUpdate = GetComponent<UIIconUpdate>();
    }

    private void Update()
    {
        _UICursorManager.ManageCursor(_genericCursor, _interactableCursor);
    }

    public void Message(string message)
    {
        _UImessageDisplay.Message(_messageText, message);
    }

    public void UpdateInventoryIcons(int iconIndex, Sprite icon, bool hasItem)
    {
        _UIiconUpdate.UpdateIcons(iconIndex, icon, hasItem);
        SelectInventoryItem();
    }

    public void SelectInventoryItem()
    {
        _UISelectInventoryItem.SelectInventoryItem(_inventoryButtons, InventoryIconBackgrounds, _UIHandManager);
    }
}
