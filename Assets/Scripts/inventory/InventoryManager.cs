using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
public class InventoryManager : MonoBehaviour
{
    [Header("Slots")]
    public GameObject slotPrefab;
    public Transform slotParent;
    public int addSlots = 3;
    public Sprite emptySlotSprite;

    [Header("UI")]
    public GameObject inventoryScreen;
    public GameObject statusUI;

    public TextMeshProUGUI descriptionText;
    
    private Color normalColor = Color.white;
    private Color highlightColor = Color.yellow;
    private Image currentSlot;

    [Header("Items")]
    public Item[] slotItems; // logical storage

    private List<Image> inventorySlots = new List<Image>();
    public bool isOpen = false;
    public static InventoryManager instance;
    
    [Header("SFX")]
    public AudioClip openSound;
    public AudioClip selectSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        slotItems = new Item[addSlots];
        inventorySlots = new List<Image>();
        inventoryScreen.SetActive(isOpen);
        statusUI.SetActive(false);
        descriptionText.gameObject.SetActive(false);
        

        for (int i = 0; i < addSlots; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            Image slotImage = newSlot.GetComponent<Image>();
            if (slotImage == null) slotImage = newSlot.AddComponent<Image>();
            slotImage.sprite = emptySlotSprite;
            slotImage.color = Color.white;
            inventorySlots.Add(slotImage);

            int capturedIndex = i;
            Button slotButton = newSlot.GetComponent<Button>();
            if (slotButton != null)
            {
                slotButton.onClick.AddListener(() => UseItem(capturedIndex));
            }
        }
        
    }

    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.iKey.wasPressedThisFrame)
        {
            isOpen = !isOpen;
            inventoryScreen.SetActive(isOpen);
            statusUI.SetActive(isOpen);
            audioSource.PlayOneShot(openSound);
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (slotItems[i] == null)
            {
                slotItems[i] = item;
                inventorySlots[i].sprite = item.icon;
                inventorySlots[i].color = Color.white;
                //Debug.Log($"Placed {item.name} in slot {i}");
                return;
            }
        }
        //Debug.Log("Inventory Full! Cannot add item: " + item.name);
        MessageManager.instance.ShowMessage("Inventory Full! Cannot add item: " + item.name);
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= inventorySlots.Count) return;

        Item item = slotItems[slotIndex];
        if (item == null) return;

        bool success = item.Use(slotIndex); // polymorphic call
        
        if (success)
        {
            DiscardItem(slotIndex);
            inventoryScreen.SetActive(false);
            statusUI.SetActive(false);
            isOpen = false;
        }
        
        
    }

    public void DiscardItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slotItems.Length) return;

        slotItems[slotIndex] = null;
        inventorySlots[slotIndex].sprite = emptySlotSprite;
        descriptionText.gameObject.SetActive(false);
        //Debug.Log($"Discarded item in slot {slotIndex}");
    }

    public void Close()
    {
        descriptionText.gameObject.SetActive(false);
    }
    

    public void OnSlotClicked(int slotIndex)
    { 
        if(slotItems[slotIndex] != null)
        {
            descriptionText.gameObject.SetActive(true);
            descriptionText.text = slotItems[slotIndex].itemName;
            audioSource.PlayOneShot(selectSound);
        }
        else
        {
            //Debug.Log("Description Text is not assigned in InventoryManager.");
            descriptionText.gameObject.SetActive(false);
        }
    }

    public void ClearInventory()
    {
        for (int i = 0; i < slotItems.Length; i++)
        {
            DiscardItem(i);
        }
    }


    public bool IsInventoryFull()
    { 
        for(int i =0; i < slotItems.Length; i++)
        {
            if (slotItems[i] == null)
                return false;
        
        }
        return true;
    }
}
