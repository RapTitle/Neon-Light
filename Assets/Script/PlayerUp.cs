using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Experimental.Rendering.Universal;


public class PlayerUp : MonoBehaviour
{
    
    private float Heigh;//跳跃高度
    private float Speed;//移动速度
    private float Gr;//跳跃后所受重力
    private float AddEnergy;//每块Plat提供的能量
    private float ReduceEnergy;//每秒能量减少量
    public Slider EnergySlider;
    public ParticleSystem Ps;
    private Rigidbody2D rg;

   



    private bool isHave;
    private bool isEnegry;

    public void SetData(float H,float S,float G,float AddE,float ReduE)
    {
        Heigh = H;
        Speed = S;
        Gr = G;
        AddEnergy = AddE;
        ReduceEnergy = ReduE;
    }

    // Start is called before the first frame update
    void Start()
    {

        
        rg = GetComponent<Rigidbody2D>();
        isHave = SystemInfo.supportsGyroscope;
        isEnegry = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GravityCon();
        LTP();
    }

    private void FixedUpdate()
    {
        StopEnergyM();
    }

    void GravityCon()
    {
        if (rg.velocity.y < 0)
            rg.gravityScale = Gr;
        else
            rg.gravityScale = 1;
    }

    void Move()//行动
    {
       
            if (isHave == true)
            {
                float X = Input.acceleration.x;
                rg.velocity = new Vector2(X * Speed, rg.velocity.y);
            }
            else
            {
                float X = Input.GetAxis("Horizontal");
                rg.velocity = new Vector2(X * Speed, rg.velocity.y);
            }
        
       

    }


    void MoveUp()//向上跳跃
    {
        if(isEnegry==true)
        {
            rg.velocity = new Vector2(rg.velocity.x, Heigh);

        }   
        else if (rg.velocity.y<=0)
            rg.velocity = new Vector2(rg.velocity.x, Heigh);
    }

    void StopEnergyM()
    {
       
        if(isEnegry==true)
        {
            EnergySlider.value -= 0.2f;
            if (EnergySlider.value <= 0)
                isEnegry = false;
        }
        
    }

    void LTP()
    {
        if (transform.position.x < -2.7)
            transform.position = new Vector3(2.6f, transform.position.y, transform.position.z);
        if (transform.position.x > 2.7)
            transform.position = new Vector3(-2.6f,transform.position.y, transform.position.z);
        
    }

    public bool IsDeath()
    {
        if (transform.position.y - Camera.main.transform.position.y <= -5.5)
            return true;
        else
            return false;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)//触发器
    {
        MoveUp();
        PlatformFather p = collision.transform.GetComponent<PlatformFather>();
        p.IsTouch(); 
        p.FlashLight();
        ParticleSystem.MainModule mainModule = Ps.main;
        mainModule.startColor = collision.transform.GetComponent<Light2D>().color;
        if (isEnegry == false)
            EnergySlider.value += AddEnergy;   
        if (EnergySlider.value >= 100)
            isEnegry = true;
    }

    
}
