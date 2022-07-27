using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlatformFather : MonoBehaviour
{
    
   
    public Light2D Light;//灯光
    public AudioSource Music;//音效
  
    public bool Touched;//判断是否触发
    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponent<Light2D>();
    }

    public void IsTouch()//
    {
        Touched = true;
    }

    private void OnBecameInvisible()//一旦超出屏幕进行销毁
    {
        Destroy(gameObject);
    }

  

    public void FlashLight()//灯光闪烁
    {
        
        Light.intensity = 1.5f;
        Light.pointLightOuterRadius = 1.5f;
        StartCoroutine("CloseFlash");
    }

    IEnumerator CloseFlash()
    {
        yield return new WaitForSeconds(0.2f);
        Light.intensity = 1;
        Light.pointLightOuterRadius = 1;
    }

   public void PlatMove(float speed)
    {
        transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));

    }
}


