using System.Collections;
using UnityEngine;

public class EnemyBar : MonoBehaviour
{

    private int MaxValue;
    private int Value;

    [SerializeField]
    private RectTransform white;

    [SerializeField]
    private RectTransform red;

    [SerializeField]
    private float _animationSpeed = 10f;

    private float _fullWidth;
    private float TargetWidth => Value * _fullWidth / MaxValue;

    private Coroutine _adjustBarWidthCoroutine;

    private void Start()
    {
        MaxValue = GetComponentInParent<EnemyController>().hp;
        Value = MaxValue;
        _fullWidth = red.rect.width;
    }



    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);
        if (_adjustBarWidthCoroutine != null)
        {
            StopCoroutine(_adjustBarWidthCoroutine);  //关闭上一次的协程
        }

        _adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount)); 
    }

   

    private IEnumerator AdjustBarWidth(int amount)
    {
        var suddenChangeBar = amount >= 0 ? white : red;
        var slowChangeBar = amount >= 0 ? red : white;

        suddenChangeBar.setWidth(TargetWidth);

        while(Mathf.Abs(suddenChangeBar.rect.width-slowChangeBar.rect.width)>0.1f)
        {
            slowChangeBar.setWidth(Mathf.Lerp(slowChangeBar.rect.width, TargetWidth,
                Time.deltaTime * _animationSpeed));
            yield return null;  //下一帧再执行下一次循环，直到循环结束
        }
        slowChangeBar.setWidth(TargetWidth);
    }
}



public static class RectTransformExtension
{
    public static void setWidth(this RectTransform t,float width)
    {
        t.sizeDelta = new Vector2(width, t.rect.height);
    }
}
