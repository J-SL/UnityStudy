using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearEnhance : MonoBehaviour
{
    public GoodsItem gearEnhance;
    bool IsCountiue;
    private float span = 5;

    public void Enhance()
    {
        gearEnhance.itemHeld--;
        InventoryManage.RefreshItem();
        IsCountiue = true;               
    }

    public void Update()
    {
        if (IsCountiue)
        {
            span = span - Time.deltaTime;

            if (span <= 0)
            {
                IsCountiue = false;
                span = 5;
                GetComponent<GearEnhance>().enabled = false;
            }
        }
    }

}
