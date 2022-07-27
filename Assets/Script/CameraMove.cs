using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerposition;
    public float speed;
    private float MaxY;
    // Start is called before the first frame update
    void Start()
    {
        MaxY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        float Y = GetMaxY();
        Vector3 vector = new Vector3(0, Y, -10);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, vector, speed * Time.deltaTime);
    }

    float GetMaxY()
    {
        float Y = playerposition.position.y;
        if (MaxY < Y)
            MaxY = Y;
        return MaxY;

    }
}
