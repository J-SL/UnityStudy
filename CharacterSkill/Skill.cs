using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    static Vector2 currentLookDir;
    Vector2 up = new Vector2(0, 1);
    Vector2 down = new Vector2(0, -1);
    Vector2 left = new Vector2(-1, 0);
    Vector2 right = new Vector2(1, 0);
    static Vector2 position;

    private int skillAbility = 3;
    [HideInInspector]
    public int usedCount = 2;

    bool IsCountiue;
    private float span = 7;

    public Text Warning;
    public GameObject warn;

    public GameObject ui;
    public GameObject ui1;

    private void Update()
    {
        uiShow();
        if(usedCount<2)
        {
            IsCountiue = true;         
        }
        if (IsCountiue)
        {
            span = span - Time.deltaTime;

            if (span <= 0)
            {
                IsCountiue = false;
                usedCount++;
                warn.SetActive(false);
                span = 7;
            }
        }

        currentLookDir = GetComponent<RubbyController>().lookDirection;
        position = GetComponent<RubbyController>().position;
    }

    public void skill()
    {
        if(usedCount<=0)
        {
            Warning.text = "¼¼ÄÜÀäÈ´ÖÐ...";
            warn.SetActive(true);
            return;
        }

        if (currentLookDir == up)
        {
            position.y += skillAbility;
        }
        if (currentLookDir == down)
        {
            position.y -= skillAbility;
        }
        if (currentLookDir == left)
        {
            position.x -= skillAbility;
        }
        if (currentLookDir == right)
        {
            position.x += skillAbility;
        }


        GetComponent<RubbyController>().rigidbody2d.MovePosition(position);
    }

    public void uiShow()
    {
        if(usedCount==2)
        {
            ui.SetActive(true);
            ui1.SetActive(true);
        }else if(usedCount==1)
        {
            ui.SetActive(true);
            ui1.SetActive(false);
        }
        else
        {
            ui.SetActive(false);
            ui1.SetActive(false);
        }
    }
}
