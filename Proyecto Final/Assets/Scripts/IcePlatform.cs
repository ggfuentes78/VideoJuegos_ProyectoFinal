using UnityEngine;

public class IcePlatform : MonoBehaviour
{

    // public float iceTimer;
             

    void Start()
    {
        // timer=2f;
    }


    void Update()
    {
        // if(iceTimer<=0)
        // {
            // this.
        // }else{
            // transform.Translate(Vector3.up * Time.deltaTime * speed , Space.World);
            // if(transform.position.y>=topeArriba)
            // {
                // timer=2f;
                // abajo=true;
            // }   
        // }
        // }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.gameObject.tag=="Player")
        {
            Destroy(this.gameObject,1f);
            Debug.Log("player piso hielo");
        }
    }
    // private void OnCollisionStay(Collision other) {
        // if (other.CompareTag("Player"))
        // {
            // timer-=Time.deltaTime;
        // }
// 
    // }
        
    // }
}


