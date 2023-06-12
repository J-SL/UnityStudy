using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTrigger : MonoBehaviour
{
    public float ColdTime = 4;
    private float coldTime;
    private float lessTime;
    private float Value => lessTime / ColdTime;

    public bool available;

    private Image coldMask;
    // Start is called before the first frame update
    void Start()
    {
        coldTime = ColdTime;
        available = true;
        coldMask = transform.Find("Image (1)").GetComponent<Image>();
    }

    // Update is called once per frame 
    void Update()
    {
        if (available == false)
        {
            coldTime = coldTime - Time.deltaTime;
            lessTime = coldTime;          
            coldMask.fillAmount = Value;
            if (lessTime <= 0)
            {
                available = true;
                coldTime = ColdTime;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            available = false;
        }
    }

    public void OnSkillClick()
    {
        available = false;
    }
}
