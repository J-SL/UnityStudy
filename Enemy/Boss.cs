using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int HP = 55;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubbyController rubbyController = collision.gameObject.GetComponent<RubbyController>();
        if (rubbyController != null)
        {
            rubbyController.ChangeHealth(-3);
        }
    }
}
