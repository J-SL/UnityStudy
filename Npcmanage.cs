using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npcmanage: MonoBehaviour
{
    public GameObject dialogBox;
    public float displayTime = 4.0f;
    private float timeDisplay;
    public Text dialogText;
    public AudioSource audioSource;
    public AudioClip completeSound;
    public bool hasPlayed;

    // Start is called before the first frame update
    public void Start()
    {
        dialogBox.SetActive(false);
        timeDisplay = -1;
    }

    // Update is called once per frame 
    public void Update()
    {
        if (timeDisplay >= 0)
        {
            timeDisplay -= Time.deltaTime;
            if(timeDisplay<0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timeDisplay = displayTime;
        dialogBox.SetActive(true);
        UIHealth.instance.hasTask = true;
        if(UIHealth.instance.fixedNum>=4)
        {
            dialogText.text = "哦，伟大的Ruby，你真的太棒了！";
            if(!hasPlayed)
            {
                audioSource.PlayOneShot(completeSound);
                hasPlayed = true;
            }
             
        }
    }
}
