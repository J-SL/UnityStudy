using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public GoodsItem armor;
    bool IsCountiue;
    private float span=30;

    public void ArmorEffect()
    {
        armor.itemHeld--;
        InventoryManage.RefreshItem();
        IsCountiue = true;       
    }

    private void Update()
    {
        if (IsCountiue)
        {
            span = span - Time.deltaTime;

            if (span <= 0)
            {
                IsCountiue = false;
                span = 30;
                GameObject.Find("ошјЧ").GetComponent<Armor>().enabled = false;
            }
        }
    }
}
