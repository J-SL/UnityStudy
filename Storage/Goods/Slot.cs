using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;
    public GoodsItem slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;


    public GameObject itemInSlot;

    public Inventory inventory;


    public void ItemOnClick()
    {
        InventoryManage.UpdateItemInfo(slotInfo); //��click��ť�󣬵��õ�������ĸ���slot���ᴫ������slot��slotInfo
    }

    public void SetupSlot(GoodsItem item,int i)
    {
        if (item == null || item.itemHeld <= 0)  //���Slot���itemΪ�ջ���item������Ϊ0
        {
            
            itemInSlot.SetActive(false);
            //���б�Ԫ���滻Ϊ��
            inventory.GoodsItems[i] = null;
            return;
            /*���ӵ���0��λ���ӵ�����1��λ�����ӵ�������ӵ���ҳ������ʧ
             �����Ҽ���˼��������Сʱ�����ڷ��������⣬���ӵ�������ӵ�ռinstance.MyBag.GoodsItems[0]λ�ã���ʱ����SetupSlot
             ��Ȼ�пգ������пպ������б���ӵ��Ƴ��ˣ��ӵ�����ռ����instance.MyBag.GoodsItems[0]������RefreshItem���������Ѿ���ִ��
            instance.MyBag.GoodsItems[1]�ˣ����ԣ�slotImage.sprite = item.itemSprite;
                                                 slotNum.text = item.itemHeld.ToString();
                                                 slotInfo = item.itemInfo;������ִ�У����ӵ�һ���꣬�ӵ���Ҳ��֮��ʧ
            �����ӵ�������0��λ�����ӵ���1��λ����������ʾ��Ҳ���Խ�����*/
        }
        slotImage.sprite = item.itemSprite;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}
