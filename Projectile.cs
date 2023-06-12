using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int DamageValue=1;

    void Awake()    //在Start之前调用
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction,float force)
    {
        rigidbody2d.AddForce(direction*force);
    }

    private void Update()
    {
        if (transform.position.magnitude > 250)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

        if(enemyController!=null)
        {
            if(GameObject.Find(" 齿轮增强器").GetComponent<GearEnhance>().enabled)
            {
                DamageValue += 9;
            }
            else
            {
                DamageValue = 1;
            }
            collision.gameObject.GetComponentInChildren<EnemyBar>().Change(-DamageValue);
            enemyController.hp= enemyController.hp-DamageValue;
            if(enemyController.hp<=0)
            {
                enemyController.Fix();
            }           
        }

        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find(" 齿轮增强器").GetComponent<GearEnhance>().enabled)
        {
            DamageValue += 9;
        }
        else
        {
            DamageValue = 1;
        }


        Boss boss = collision.gameObject.transform.parent.GetComponentInParent<Boss>();
        var name = collision.gameObject.name;

        if (name == "collider_leg")
        {
            collision.gameObject.transform.parent.parent.GetComponentInChildren<BossBar>().Change(-DamageValue);
            boss.HP = boss.HP - DamageValue;
        }
        if (name == "collider_body")
        {
            collision.gameObject.transform.parent.parent.GetComponentInChildren<BossBar>().Change(-(DamageValue + 4));
            boss.HP = boss.HP - (DamageValue + 4);
        }
        if (name == "collider_head")
        {
            collision.gameObject.transform.parent.parent.GetComponentInChildren<BossBar>().Change(-(DamageValue + 8));
            boss.HP = boss.HP - (DamageValue + 8);
        }


        if (boss.HP <= 0)
        {
            Destroy(boss.gameObject);
        }

        Destroy(gameObject);
    }
}
 