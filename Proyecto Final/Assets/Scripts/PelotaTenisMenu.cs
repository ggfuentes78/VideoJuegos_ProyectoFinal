using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaTenisMenu : MonoBehaviour
{
    public float timer;
    public float movZ;
    // public float movY;
    public float speed;
    public float limitePosZ;
    public float limiteNegZ;
    public bool derecha;


    public Rigidbody rb;
 
    void Start()
    {
        timer=1f;
        derecha=true;
        speed=5f;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer-=Time.deltaTime;
        if(timer<=0)
        {
            if(derecha){
                Vector3 mov = new Vector3(movZ, 0, 0);
                rb.AddForce(mov * speed * Time.fixedDeltaTime); 
                // transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
                if(transform.position.x<=limiteNegZ)
                {
                    timer=3f;
                    derecha=false;
                }
            }else{
                Vector3 mov = new Vector3(-movZ, 0, 0);
                rb.AddForce(mov * speed * Time.fixedDeltaTime);
                // transform.Translate(Vector3.up * Time.deltaTime * speed , Space.World);
                if(transform.position.z>=limitePosZ)
                {
                    timer=3f;
                    derecha=true;
                }   
            }
        }
        // rb.AddForce((circleCenterPosition - transform.position).normalized * force);
        // Vector3 inputJugador = new Vector3(-movX, 0, -movY);
        // rb.AddForce(inputJugador * speed * Time.fixedDeltaTime); 
    }
}
