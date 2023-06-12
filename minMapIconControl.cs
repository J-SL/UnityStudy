using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minMapIconControl : MonoBehaviour
{

    public Transform rotateIcon;

    public void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            rotateIcon.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetKeyDown("d"))
        {
            rotateIcon.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKeyDown("w"))
        {
            rotateIcon.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKeyDown("s"))
        {
            rotateIcon.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
