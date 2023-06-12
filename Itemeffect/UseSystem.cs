using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSystem : MonoBehaviour
{
    public Slot slot;

    public static string Info;   //这里设成static是必要的，不然下面的((Info== message))会不等

    private string message1 = "获得多枚齿轮子弹";
    private string message2 = "使用可以在一小段时间获得大量移动速度";
    private string message3 = "在一定时间内减少任意来源的伤害";
    private string message4 = "在一小段时间内巨幅提升齿轮子弹的伤害";

    //检测是哪个物品的信息显示了
    public void spyClickInfo()
    {
        //Debug.Log("a");
        Info = slot.slotInfo;
        //Debug.Log(Info);
    }

    public void ClickUse()
    {
        //Debug.Log(Info);
        if (Info== message1)
        {
            GameObject.Find("子弹包").SendMessage("UsePackage");  //GameObject.Find("脚本所在的物体名").SendMessage("需调用的函数名");
        }
        if (Info == message2)
        {
            GameObject.Find("动力药水").GetComponent<PowerWater>().enabled = true;   //打开PowerWater脚本
            GameObject.Find("动力药水").SendMessage("RaiseSpeed");
        }
        if(Info==message3)
        {
            GameObject.Find("铠甲").GetComponent<Armor>().enabled = true;
            GameObject.Find("铠甲").SendMessage("ArmorEffect");
        }
        if(Info==message4)
        {
            GameObject.Find(" 齿轮增强器").GetComponent<GearEnhance>().enabled = true; //" 齿轮增强器"，注意前面这0个空格是必须的哦，这是在Unity面板我不小心多打了，这里必须与那里对应
            GameObject.Find(" 齿轮增强器").SendMessage("Enhance");
        }
    }
}
