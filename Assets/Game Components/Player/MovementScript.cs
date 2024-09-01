using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementScript : MonoBehaviour
{
    int x;
    Vector3 move;
    float velocity;
    CharacterController controler;
    AudioSource audioSource;



    public float steadySpeed = 14f;
    public float accleration = 10f;
    public float deccleration = 14f;
    public float gravity = 10f;


    public static float volume;


    private void Start()
    {
        controler = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }



    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            x = 1;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            x = 0;
        }


        
        if (x != 0)
        {
            if (x * velocity >= 0 && x!=0)
            {
                velocity += x * accleration * Time.deltaTime;
                velocity = Mathf.Clamp(velocity, -steadySpeed, steadySpeed);
            }
            else
            {
                velocity = Mathf.Sign(velocity) * (Mathf.Clamp((Mathf.Abs(velocity) - deccleration * Time.deltaTime), 0, steadySpeed));
            }
            
        }
        
        else
        {
            velocity = Mathf.Sign(velocity)*(Mathf.Clamp((Mathf.Abs(velocity) - deccleration*Time.deltaTime),0,steadySpeed));
            
        }
        
        
        move = transform.forward*velocity;
        move.y -= gravity;

        controler.Move(move*Time.deltaTime);
        
    }


}
