using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSystem : MonoBehaviour
{
    public Slot slot;

    public static string Info;   //�������static�Ǳ�Ҫ�ģ���Ȼ�����((Info== message))�᲻��

    private string message1 = "��ö�ö�����ӵ�";
    private string message2 = "ʹ�ÿ�����һС��ʱ���ô����ƶ��ٶ�";
    private string message3 = "��һ��ʱ���ڼ���������Դ���˺�";
    private string message4 = "��һС��ʱ���ھ޷����������ӵ����˺�";

    //������ĸ���Ʒ����Ϣ��ʾ��
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
            GameObject.Find("�ӵ���").SendMessage("UsePackage");  //GameObject.Find("�ű����ڵ�������").SendMessage("����õĺ�����");
        }
        if (Info == message2)
        {
            GameObject.Find("����ҩˮ").GetComponent<PowerWater>().enabled = true;   //��PowerWater�ű�
            GameObject.Find("����ҩˮ").SendMessage("RaiseSpeed");
        }
        if(Info==message3)
        {
            GameObject.Find("����").GetComponent<Armor>().enabled = true;
            GameObject.Find("����").SendMessage("ArmorEffect");
        }
        if(Info==message4)
        {
            GameObject.Find(" ������ǿ��").GetComponent<GearEnhance>().enabled = true; //" ������ǿ��"��ע��ǰ����0���ո��Ǳ����Ŷ��������Unity����Ҳ�С�Ķ���ˣ���������������Ӧ
            GameObject.Find(" ������ǿ��").SendMessage("Enhance");
        }
    }
}
