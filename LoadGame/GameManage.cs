using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public bool IsPaused;

    public List<EnemyController> enemies=new List<EnemyController>(); 
   

    private void Awake() {
        if(instance==null)
        { 
            instance=this;
        }else{
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
