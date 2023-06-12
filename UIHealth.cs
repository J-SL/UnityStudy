using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image mask;  //需引入using UnityEngine.UI;
    float originalSize;

    public static UIHealth instance { get; private set; }

    public bool hasTask;
    //public bool ifCompleteTask;

    public int fixedNum;

    private void Awake()
    {
        instance = this; //初始化实例
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    //移动血条的mask
    public void SetValue(float fillvalue)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
            originalSize * fillvalue);
    }
}
