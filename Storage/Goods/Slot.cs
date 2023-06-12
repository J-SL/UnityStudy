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
        InventoryManage.UpdateItemInfo(slotInfo); //当click按钮后，调用的是自身的父类slot，会传入自身slot的slotInfo
    }

    public void SetupSlot(GoodsItem item,int i)
    {
        if (item == null || item.itemHeld <= 0)  //如果Slot里的item为空或者item的数量为0
        {
            
            itemInSlot.SetActive(false);
            //将列表元素替换为空
            inventory.GoodsItems[i] = null;
            return;
            /*当子弹在0号位而子弹包在1号位，当子弹用完后，子弹包页随着消失
             经过我艰苦的思考两个半小时后，终于发现了问题，当子弹用完后，子弹占instance.MyBag.GoodsItems[0]位置，此时运行SetupSlot
             必然判空，而在判空后，由于列表把子弹移除了，子弹包则占用了instance.MyBag.GoodsItems[0]，但是RefreshItem（）函数已经在执行
            instance.MyBag.GoodsItems[1]了，所以，slotImage.sprite = item.itemSprite;
                                                 slotNum.text = item.itemHeld.ToString();
                                                 slotInfo = item.itemInfo;都不会执行，即子弹一用完，子弹包也随之消失
            而当子弹包放在0号位，而子弹在1号位，则正常显示，也可以解释了*/
        }
        slotImage.sprite = item.itemSprite;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}
