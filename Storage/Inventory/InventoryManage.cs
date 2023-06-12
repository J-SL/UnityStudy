using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManage : MonoBehaviour
{
    public static InventoryManage instance;
    public Inventory MyBag;
    public GameObject slotGrids;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text ItemInfo;

    public List<GameObject> slots = new List<GameObject>();

    private void OnEnable()
    {
        RefreshItem();
        instance.ItemInfo.text = "";
    }

    public static void UpdateItemInfo(string ItemDescription)
    {
        instance.ItemInfo.text = ItemDescription;
    }

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;                //保证单例的唯一性
    }

    /*public static void CreatNewItem(GoodsItem goodsItem)
    {
        Slot newItem =
            Instantiate(instance.slotPrefab, instance.slotGrids.transform.position,
            Quaternion.identity);
        //将newItem的位置创建在slotGrids的子级位置上，SetParent：设为父级
        newItem.gameObject.transform.SetParent(instance.slotGrids.transform);
        //将实例化出来的newItem的物品及其图片替换为传入参数goodsItem的物品及其图片
        newItem.slotItem = goodsItem;
        newItem.slotImage.sprite = goodsItem.itemSprite;
        newItem.slotNum.text = goodsItem.itemHeld.ToString();
    }*/

    public static void RefreshItem ()
    {
        for (int i = 0; i < instance.slotGrids.transform.childCount; i++)
        {
            if (instance.slotGrids.transform.childCount == 0) break;
            Destroy(instance.slotGrids.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.MyBag.GoodsItems.Count; i++)//在Ruby与物品碰撞时已经在列表中添加了
        {
            //CreatNewItem(instance.MyBag.GoodsItems[i]);//把列表GoodsItems的物品创造在slot上
            instance.slots.Add(Instantiate(instance.emptySlot));  //Instantiate实例化出来的物体类型为GameObject
            instance.slots[i].transform.SetParent(instance.slotGrids.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;  
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.MyBag.GoodsItems[i],i);    
        }
    }
}
