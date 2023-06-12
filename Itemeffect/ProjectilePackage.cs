using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePackage : MonoBehaviour
{
    public GoodsItem projectile;
    public GoodsItem projectilePackage;
    public Inventory inventory;

    public void UsePackage()
    {       
        int num = Random.Range(20, 67);
        if (projectile.itemHeld <= 0)
        {
            for (int i = 0; i < inventory.GoodsItems.Count; i++)
            {
                if (inventory.GoodsItems[i] == null)
                {
                    inventory.GoodsItems[i] = projectile;
                    break;
                }
            }
        }
        projectile.itemHeld += num;
        projectilePackage.itemHeld--;
        

        InventoryManage.RefreshItem();
    }
}
