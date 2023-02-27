using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        
        /*
        Vector3.Lerp hareketin yavaş(smooth) olmasi icin kullanilir.
        Vector3 Vector3.Lerp(Vector3 a, Vector3 b, float t)
        a --> hareketin baslangici
        b --> hedef pozisyon
        t --> hareketin nekadar surede gerceklesecegi 
        */
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(player);
    }


}
