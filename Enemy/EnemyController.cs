using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 3;
    public float speed;
    private Rigidbody2D rigidbody2d;
    public bool vertical;
    private int direction = 1;
    public float changeTime = 3;
    private float timer;

    private Animator animator;
    //当前机器人是否故障
    public bool broken;

    public ParticleSystem smokeEffect;

    private AudioSource audioSource;
    public AudioClip fixedSound;
    public AudioClip[] hitSounds;

    public GameObject hitEffectParticle;

    public GameObject Bar;

    public float PositionX,PositionY;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        //animator.SetFloat("MoveX", direction);
        PlayMoveAnimation();
        broken = true;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PositionX=transform.position.x;
        PositionY=transform.position.y;
    
        if(!broken)
        {
            return;
        }
        timer -= Time.deltaTime;
        if(timer<0)
        {
            direction = -direction;
            //animator.SetFloat("MoveX", direction);
            PlayMoveAnimation();
            timer = changeTime;
        }

        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else { position.x = position.x + Time.deltaTime * speed * direction; }

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubbyController rubbyController = collision.gameObject.GetComponent<RubbyController>();
        if(rubbyController!=null)
        {
            rubbyController.ChangeHealth(-1);
        }
    }

    private void PlayMoveAnimation()
    {
        if (vertical)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
    }

    public void Fix()
    {
        Instantiate(hitEffectParticle, transform.position, Quaternion.identity);
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();

        int randomNum = Random.Range(0,2);
        audioSource.PlayOneShot(hitSounds[randomNum]);
        Invoke("PlayFixedSound", 0.5f);

        Bar.SetActive(false);

        UIHealth.instance.fixedNum++;
    }

    public void PlayFixedSound()
    {
        audioSource.PlayOneShot(fixedSound);
        Invoke("StopPlayFixedSound", 1f);
    }

    public void StopPlayFixedSound()
    {
        audioSource.Stop();
    }
}
