using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public GameObject slotPrefab;
    public Text itemInformation;
    public List<GameObject> slotsItem = new List<GameObject>();

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        RefreshItems();
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    /*
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/

    public static void RefreshItems()
    {
        for(int i = 0;i < instance.slotGrid.transform.childCount; i++)
        {
            if(instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slotsItem.Clear();
        }

        for(int i = 0; i < instance.myBag.items.Count; i++)
        {
            //CreateNewItem(instance.myBag.items[i]);
            instance.slotsItem.Add(Instantiate(instance.slotPrefab));
            instance.slotsItem[i].transform.SetParent(instance.slotGrid.transform);
            instance.slotsItem[i].GetComponent<Slot>().SetItem(instance.myBag.items[i]);
            instance.slotsItem[i].GetComponent<Slot>().slotID = i;
        }
    }
}
