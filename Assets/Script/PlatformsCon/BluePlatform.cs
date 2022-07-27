using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class BluePlatform : PlatformFather
{
    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponent<Light2D>();
        Music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlatMove(1f);
    }
}
