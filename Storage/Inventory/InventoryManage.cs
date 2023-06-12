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
        instance = this;                //��֤������Ψһ��
    }

    /*public static void CreatNewItem(GoodsItem goodsItem)
    {
        Slot newItem =
            Instantiate(instance.slotPrefab, instance.slotGrids.transform.position,
            Quaternion.identity);
        //��newItem��λ�ô�����slotGrids���Ӽ�λ���ϣ�SetParent����Ϊ����
        newItem.gameObject.transform.SetParent(instance.slotGrids.transform);
        //��ʵ����������newItem����Ʒ����ͼƬ�滻Ϊ�������goodsItem����Ʒ����ͼƬ
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
        for (int i = 0; i < instance.MyBag.GoodsItems.Count; i++)//��Ruby����Ʒ��ײʱ�Ѿ����б��������
        {
            //CreatNewItem(instance.MyBag.GoodsItems[i]);//���б�GoodsItems����Ʒ������slot��
            instance.slots.Add(Instantiate(instance.emptySlot));  //Instantiateʵ������������������ΪGameObject
            instance.slots[i].transform.SetParent(instance.slotGrids.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;  
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.MyBag.GoodsItems[i],i);    
        }
    }
}
