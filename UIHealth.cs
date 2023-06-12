using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image mask;  //������using UnityEngine.UI;
    float originalSize;

    public static UIHealth instance { get; private set; }

    public bool hasTask;
    //public bool ifCompleteTask;

    public int fixedNum;

    private void Awake()
    {
        instance = this; //��ʼ��ʵ��
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    //�ƶ�Ѫ����mask
    public void SetValue(float fillvalue)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
            originalSize * fillvalue);
    }
}
