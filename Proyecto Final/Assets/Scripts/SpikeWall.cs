using UnityEngine;

public class SpikeWall : MonoBehaviour
{

    public float timer;
    public float topeArriba;
    public float topeAbajo;
    public bool abajo;
    public float speed;


    void Start()
    {
     timer=2f;
     abajo=true;
     speed=5f;   
    }


    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<=0)
        {
            if(abajo){
                transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
                if(transform.position.y<=topeAbajo)
                {
                    timer=2f;
                    abajo=false;
                }
            }else{
                transform.Translate(Vector3.up * Time.deltaTime * speed , Space.World);
                if(transform.position.y>=topeArriba)
                {
                    timer=2f;
                    abajo=true;
                }   
            }
        }
    }
}
