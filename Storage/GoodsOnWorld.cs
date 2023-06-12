using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsOnWorld : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ruby"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public GoodsItem thisItem;
    public Inventory thisInventory;
    public void AddNewItem()
    {
        if (!thisInventory.GoodsItems.Contains(thisItem))
        {
            thisItem.itemHeld=1;
            //thisInventory.GoodsItems.Add(thisItem);
            //thisItem.equip = true;
            for (int i=0;i<thisInventory.GoodsItems.Count;i++)
            {
                if(thisInventory.GoodsItems[i]==null)
                {
                    thisInventory.GoodsItems[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld++;
        }
        InventoryManage.RefreshItem();
    }
}
