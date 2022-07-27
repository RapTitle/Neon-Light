using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

  
    public GameManager instance;


    [Header("生成设置")]
    public float CreatH;
    public float CreatL;

    [Header("平台设置")]
    public float PlatSpeed;

    [Header("角色设置")]
    public float PlayerHeigh;
    public float PlayerSpeed;
    public float PlayerGr;
    public float PlayerAddEnergy;
    public float PlayerReduceEnergy;


    [Header("系统设置")]
    public Image GamingUi;
    public Image DeathUi;
    public Slider MusicNum;
    public Slider SpeedNum;
    public Slider PlayerSpeedNum;
    public AudioSource Music;

    private bool isSet;



    public GameObject Creat;
    public GameObject Plat;
    public GameObject Player;
    //public GameObject System;

    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
       

    }
    private void Start()
    {
        CreatStart();
        PlayerCon();
    }

    private void Update()
    {
        BroadPlatMove();
        StopTime();
        ChangeSet();
        JudgeDeath();
        PlayerCon();
    }

    void CreatStart()//生成设置函数
    {
        CretaPlatforms cretaPlatforms = Creat.GetComponent<CretaPlatforms>();
        cretaPlatforms.SetData(CreatH, CreatL);
    }

    void BroadPlatMove()//平台移动函数
    {
        Plat.BroadcastMessage("PlatMove", PlatSpeed);
    }

    void PlayerCon()
    {
        Player.GetComponent<PlayerUp>().SetData(PlayerHeigh, PlayerSpeedNum.value, PlayerGr, PlayerAddEnergy, PlayerReduceEnergy);
    }


   void StopTime()
    {
        if (GamingUi.IsActive())
        {
            Time.timeScale = 0;
            isSet = true;
        }

        else
        {
            Time.timeScale = SpeedNum.value;
            isSet = false;
        }
        
    }

    void ChangeSet()
    {
        if (isSet == true) 
        Music.volume = MusicNum.value;
    }

    void JudgeDeath()
    {
        bool judge = Player.GetComponent<PlayerUp>().IsDeath();
        if (judge)
            DeathUi.gameObject.SetActive(true);       
    }

    public void NewGame()
    {
        string SceneName;
        SceneName = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(SceneName);
    }

    public void BUTQuit()
    {
        Application.Quit();
    }




   
    
    


    
}
