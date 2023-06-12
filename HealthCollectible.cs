using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip audioClip;
    [HideInInspector]
    public GameObject effectParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("与本体碰撞的是" + collision);
        RubbyController rubbyController = collision.GetComponent<RubbyController>();
        if (rubbyController != null)
        {
            if (rubbyController.Health<rubbyController.MaxHealth)
            {
                rubbyController.ChangeHealth(1);
                rubbyController.PlaySound(audioClip);
                Instantiate(effectParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
