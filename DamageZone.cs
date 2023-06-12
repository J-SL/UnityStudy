using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        RubbyController rubbyController = collision.GetComponent<RubbyController>();
        if (rubbyController != null)
        {
            rubbyController.ChangeHealth(-1);
        }
    }
}
