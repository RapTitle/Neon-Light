using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;



public class CretaPlatforms : MonoBehaviour
{
    
    public GameObject[] Platforms;
    private float Heigh;
    private float Long;
    public GameObject PlatFather;
   // private float Left;//-2.35
   // private float Right;//2.35
  
    public GameObject OldG;
    

    // Start is called before the first frame update

    public void SetData(float h,float L)
    {
        Heigh = h;
        Long = L;

    }
    void Start()
    {

       
       // Left = -2.35f;
       // Right = 2.35f;
    }

    // Update is called once per frame
    void Update()
    {
        Creat();
    }

    

    void Creat()
    {
        if(transform.position.y-OldG.transform.position.y>=Heigh)
        {

            Vector3 vector = transform.position;
             int Rx = Random.Range(-1, 1);
            if (Rx < 0)
                vector.x = OldG.transform.position.x - Long;
                // transform.position = new Vector3(OldHeight.x - L, transform.position.y, transform.position.z);
             else
                vector.x = OldG.transform.position.x + Long;
            //  transform.position = new Vector3(OldHeight.x + L, transform.position.y, transform.position.z);
            if (vector.x < -2)
            {
                int m = Random.Range(0, 1);
                if (m == 0)
                    vector.x = -2;
                else
                    vector.x += Long;
            }
            // transform.position = new Vector3(-2, transform.position.y, transform.position.z);
            else if (vector.x > 2)
            {
                int m = Random.Range(0, 1);
                if (m == 0)
                    vector.x = 2;
                else
                    vector.x -= Long;
            }
               //  transform.position = new Vector3(2, transform.position.y, transform.position.z);
          
            int T = Random.Range(0, 3);
            GameObject plat = GameObject.Instantiate(Platforms[T], vector, Quaternion.identity);
            plat.transform.SetParent(PlatFather.transform);
            OldG = plat;
            
         
           
        }
        
    }

  
       

   
    

    

    

}
