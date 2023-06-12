using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameMnue : MonoBehaviour
{
    public Image gameMenuImage;

    public Toggle BGMToggle;
    public AudioSource BGMSource;

    public GoodsItem projectile;

    public RubbyController rubby;

    public Vector2 position;

    public EnemyController enemyObj;

    public void Start() {
        gameMenuImage.gameObject.SetActive(false);

        rubby=FindObjectOfType<RubbyController>();
    }

    public void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManage.instance.IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        BGMManage();
    }

    public void Resume()
    {
        gameMenuImage.gameObject.SetActive(false);
        Time.timeScale=1;
        GameManage.instance.IsPaused=false;
    }
    private void Pause()
    {
        gameMenuImage.gameObject.SetActive(true);
        Time.timeScale=0.0f;
        GameManage.instance.IsPaused=true;
    }

    public void BGMToggleBUtton()
    {
        if(BGMToggle.isOn)
        {
            PlayerPrefs.SetInt("BGM",1);           
        }
        else{
            PlayerPrefs.SetInt("BGM",0);          
        }
    }

    private void BGMManage()
    {
        if(PlayerPrefs.GetInt("BGM")==1)
        {
            BGMToggle.isOn=true;
            BGMSource.enabled=true;
        }else if(PlayerPrefs.GetInt("BGM")==0)
        {
            BGMToggle.isOn=false;
            BGMSource.enabled=false;
        }
    }

    public void SaveButton()
    {
        SaveByPlayerprefs();
        SaveBySerialization();
    }
    public void LoadButton()
    {
        LoadByPlayerprefs();
        LoadByDeSerialization();
    }

//创建一个类，用来存放信息
    private Save createSaveGameObject()
    {
        Save save=new Save();
        foreach(EnemyController enemy in GameManage.instance.enemies)
        {
            save.broken.Add(enemy.broken);
            save.positionX.Add(enemy.PositionX);
            save.positionY.Add(enemy.PositionY);
        }
        
        return save;
    }
//把类里的信息写入文件
    private void SaveBySerialization()
    {
        Save save=createSaveGameObject();
        BinaryFormatter bf=new BinaryFormatter();
        FileStream fileStream=File.Create(@"F:\unity games\learning\My project\Assets\scripts\LoadGame\Data.text");
        bf.Serialize(fileStream,save); //将save以二进制存入fileStream
        fileStream.Close();
    }
//将二进制文件反编译为类，配合链表遍历读取
    private void LoadByDeSerialization()
    {
        if(File.Exists(@"F:\unity games\learning\My project\Assets\scripts\LoadGame\Data.text"))
        {
            BinaryFormatter bf=new BinaryFormatter();
            FileStream fileStream=File.Open(@"F:\unity games\learning\My project\Assets\scripts\LoadGame\Data.text",FileMode.Open);

            Save save=bf.Deserialize(fileStream) as Save;
            fileStream.Close();

            for(int i=0;i<save.broken.Count;i++)
            {
                if(save.broken[i])
                {
                    Destroy(GameManage.instance.enemies[i].gameObject);
                    var PosX=save.positionX[i];
                    var PosY=save.positionY[i];
                    EnemyController newEnemy=Instantiate(enemyObj,new Vector2(PosX,PosY),Quaternion.identity);
                    GameManage.instance.enemies[i]=newEnemy;  
                    GameManage.instance.enemies[i].broken=save.broken[i];
                    
                }else{
                    var PosX=save.positionX[i];
                    var PosY=save.positionY[i];
                    GameManage.instance.enemies[i].transform.position=new Vector2(PosX,PosY);
                    GameManage.instance.enemies[i].broken=save.broken[i];
                    GameManage.instance.enemies[i].Fix();
                }                                  
            }
        }

    }
    public void SaveByPlayerprefs()
    {
        PlayerPrefs.SetInt("projectile",projectile.itemHeld);

        PlayerPrefs.SetFloat("PlayerPosX",rubby.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY",rubby.transform.position.y);
        //save ruby's hp infomation
        PlayerPrefs.SetFloat("hp",rubby.CurrentHealth);
    }
    public void LoadByPlayerprefs()
    {
        projectile.itemHeld=PlayerPrefs.GetInt("projectile");
        InventoryManage.RefreshItem();

        position.x=PlayerPrefs.GetFloat("PlayerPosX");
        position.y=PlayerPrefs.GetFloat("PlayerPosY");
        rubby.transform.position=new Vector2(position.x,position.y);
        rubby.CurrentHealth=PlayerPrefs.GetFloat("hp");
        UIHealth.instance.SetValue( rubby.CurrentHealth/ rubby.MaxHealth);
    }
}
