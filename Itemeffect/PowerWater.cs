using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWater : MonoBehaviour
{
    public GoodsItem powerWater;
    bool IsCountiue;
    private float span=12;

    
    public void RaiseSpeed()
    {
        powerWater.itemHeld--;
        InventoryManage.RefreshItem();
        IsCountiue = true;

        GameObject.Find("Ruby").GetComponent<RubbyController>().speed = 25;     
    }

    private void Update()
    {        
        if (IsCountiue)
        {
            span = span - Time.deltaTime;

            if (span <= 0)
            {
                IsCountiue = false;
                GameObject.Find("Ruby").GetComponent<RubbyController>().speed = 5;
                span = 12;
                GetComponent<PowerWater>().enabled = false; 
            }
        }
    }
}
