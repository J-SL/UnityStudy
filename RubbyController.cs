using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubbyController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rigidbody2d;
 
    public int MaxHealth = 5;
    public float CurrentHealth = 5;
    public int speed = 5;
    public float Health { get { return CurrentHealth; }  }

    public float timeInvincible=2.0f;
    private bool isInvincible;
    private float invincibleTimer;//��ʱ��

    [HideInInspector]
    public Vector2 lookDirection = new Vector2(1, 0);
    private Animator animator;

    public GameObject projiectilePrefab;

    public AudioSource audioSource;
    public AudioSource walkAudioSource;

    public AudioClip PlayerHit;
    public AudioClip throwCog;
    public AudioClip walkSound;

    private Vector3 respawnPosition;

    public GoodsItem goodsItem;
    //����һ���
    public Text Warning;
    public GameObject warn;

    [HideInInspector]
    public Vector2 position;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //Application.targetFrameRate=90;  //�ı�֡��Ϊ90
        CurrentHealth = MaxHealth;
        animator = GetComponent<Animator>();
        // audioSource = GetComponent<AudioSource>();

        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {    
        if(BigMapControl.open==false)  //�����ͼ�ر�ʱִ���ƶ�
        {
            float horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontal, Vertical);
            //��ǰ��������ĳ������ֵ��Ϊ0
            if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
            {
                lookDirection.Set(move.x, move.y);  //�൱��lookDirection=move��
                lookDirection.Normalize();
                //�����Чû���ţ��򲥷ţ�����Update�ж�ʱ���ظ����ţ�
                if (!walkAudioSource.isPlaying)
                {
                    walkAudioSource.clip = walkSound;
                    walkAudioSource.Play();
                }
            }
            else
            {
                walkAudioSource.Stop();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            position = transform.position;
            //position.x = position.x + 0.2f*speed*horizontal;
            //position.y = position.y + 0.2f*speed* Vertical;//Ҳ�����ø�������0.07f * Vertical
            position = position + speed * move * Time.deltaTime;

            //transform.position = position;
            rigidbody2d.MovePosition(position);
        }
        else { return; }

        
        
        if(isInvincible)
        {
            invincibleTimer = invincibleTimer - Time.deltaTime;
            if(invincibleTimer<=0)
            {
                isInvincible = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (goodsItem.itemHeld > 0)
            {
               
                //if(UIHealth.instance.hasTask)
                //{
                Launch();
                goodsItem.itemHeld--;  //*
                                       //}             

                InventoryManage.RefreshItem(); //*
            }
            else { Warning.text = "û���ӵ��ˣ�"; warn.SetActive(true); }         
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection,1.5f, LayerMask.GetMask("NPC"));
            if(hit.collider!=null)
            {              
                Npcmanage npcDialog = hit.collider.GetComponent<Npcmanage>();
                if (npcDialog != null)
                {
                    npcDialog.DisplayDialog();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Skill>().skill();

            GetComponent<Skill>().usedCount = Mathf.Clamp(GetComponent<Skill>().usedCount-1, 0, 2);
            //Debug.Log("GetComponent<Skill>().usedCount" + GetComponent<Skill>().usedCount);
        }

        OpenMyBag();
    }

    public void ChangeHealth(float amount)
    {
        //ArmorЧ��
        if (GameObject.Find("����").GetComponent<Armor>().enabled)
        {
            amount = amount * 0.3f;
        }

        if(amount<0)
        {
            if(isInvincible)
            {
                return;
            } 
            isInvincible = true;
            invincibleTimer = timeInvincible;
            animator.SetTrigger("Hit");
            PlaySound(PlayerHit);    
        }

        CurrentHealth = Mathf.Clamp(Health + amount, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Respawn();
            //Warning.text = "Game Over"; warn.SetActive(true);
            //Time.timeScale = 0;
        }
        //Debug.Log(Health+"/"+MaxHealth);
        UIHealth.instance.SetValue(CurrentHealth / (float)MaxHealth);
    }

    private void Launch()
    {       
        GameObject projectileObject = Instantiate(projiectilePrefab, rigidbody2d.position+Vector2.up*0.5f,
            Quaternion.identity);//Instantiateʵ������ע�������Projectile�е�Start������Ҫ�ĳ�Awake
        Projectile projectlie = projectileObject.GetComponent<Projectile>();
        projectlie.Launch(lookDirection, 300); 
        animator.SetTrigger("Launch");
        PlaySound(throwCog); 
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    } 

    private void Respawn()
    {
        CurrentHealth = MaxHealth;
        UIHealth.instance.SetValue(CurrentHealth / (float)MaxHealth);
        transform.position = respawnPosition;
    }

    private bool isOpen;
    public GameObject MyBag;
    void OpenMyBag()
    {
        isOpen = MyBag.activeSelf;//��MyBag��active״̬����isOPen
        if (Input.GetKeyDown("b"))
        {
            isOpen = !isOpen;
            MyBag.SetActive(isOpen);
        }
    }
}
