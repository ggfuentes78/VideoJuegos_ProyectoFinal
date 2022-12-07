using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Pelota
{
    public Rigidbody rb2;
    public bool isInGround;

    public SphereCollider playerCollider;

    public GameObject pelotaFutbol;
    public GameObject pelotaTenis;
    public GameObject pelotaBasket;
    public GameObject pelotaBowling;
    public ParticleSystem humo;
    public static int vidas;
    public static float timer;
 

    void Start()
    {
        startPoint= transform.position;
        spawnPoint=transform.position;
        tipoPelota=(TipoPelota)0;
        vidas=3;
        timer=0;
    }

    void Update()
    {
        timer+=Time.deltaTime;
            // if (Input.GetKeyDown(KeyCode.Space)&&isInGround)
            // {
                // Saltar();
            // }
            if (Input.GetKeyDown(KeyCode.X))
            {
                spawnPoint=pelotaFutbol.transform.position;
                tipoPelota=(TipoPelota)1;
                // humo.Play();
            }else{
                if(Input.GetKeyDown(KeyCode.C))
                {
                    spawnPoint=pelotaFutbol.transform.position;
                    tipoPelota=(TipoPelota)2;
                    // humo.Play();
                }else{
                    if(Input.GetKeyDown(KeyCode.Z))
                    {
                        spawnPoint=pelotaFutbol.transform.position;
                        tipoPelota=(TipoPelota)3;
                        // humo.Play();
                    }
                }
            }
 
            if(Input.GetKeyUp(KeyCode.Z))
            {
                spawnPoint=pelotaBasket.transform.position;
                tipoPelota=(TipoPelota)0;
                // humo.Play();
            }else{
                if(Input.GetKeyUp(KeyCode.X))
                {
                    spawnPoint=pelotaTenis.transform.position;
                    tipoPelota=(TipoPelota)0;
                    // humo.Play();
                }else{
                    if(Input.GetKeyUp(KeyCode.C))
                    {
                        spawnPoint=pelotaBowling.transform.position;
                        tipoPelota=(TipoPelota)0;
                        // humo.Play();
                    }
                }
            }
// 
            TipoPlayer(tipoPelota);
            // humo.Play();
       }

    void FixedUpdate()
    {
        MovimientoJugador();
    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(this.transform.name+ "COLISIONO CON " + col.transform.gameObject.tag);
        if (col.transform.gameObject.tag=="Ground")
        {
            isInGround=true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log(this.transform.name + "SALGO DE COLISIONAR CON " + col.transform.gameObject.tag);
        if (col.transform.gameObject.tag=="Ground")
        {
            isInGround=false;
        }
    }

       
    public void PierdeVida()
    {
        Debug.Log("Pierde Vida!");
        vidas--;
        spawnPoint=startPoint;
        tipoPelota=(TipoPelota)0;
        pelotaFutbol.transform.position=startPoint;
    }

    public void TipoPlayer(TipoPelota tipoPelota)
    {
        switch(tipoPelota)
        {
            case TipoPelota.Futbol:
                pelotaBasket.SetActive(false);
                pelotaTenis.SetActive(false);
                pelotaBowling.SetActive(false);
                if (!pelotaFutbol.activeInHierarchy){
                     pelotaFutbol.transform.position=spawnPoint;
                }
                pelotaFutbol.SetActive(true);
                rb=pelotaFutbol.GetComponent<Rigidbody>();
                playerCollider=pelotaFutbol.GetComponent<SphereCollider>();
                break;
            case TipoPelota.Tenis:
                pelotaFutbol.SetActive(false);
                pelotaBasket.SetActive(false);
                pelotaBowling.SetActive(false);
                if (!pelotaTenis.activeInHierarchy){
                     pelotaTenis.transform.position=spawnPoint;
                }                
                pelotaTenis.SetActive(true);
                rb=pelotaTenis.GetComponent<Rigidbody>();
                playerCollider=pelotaTenis.GetComponent<SphereCollider>();
                break;
            case TipoPelota.Bowling:
                pelotaFutbol.SetActive(false);
                pelotaBasket.SetActive(false);
                pelotaTenis.SetActive(false);
                if (!pelotaBowling.activeInHierarchy){
                     pelotaBowling.transform.position=spawnPoint;
                }
                pelotaBowling.SetActive(true);
                rb=pelotaBowling.GetComponent<Rigidbody>();
                playerCollider=pelotaBowling.GetComponent<SphereCollider>();
                break;
            case TipoPelota.Basket:
                pelotaFutbol.SetActive(false);
                pelotaTenis.SetActive(false);
                pelotaBowling.SetActive(false);
                if (!pelotaBasket.activeInHierarchy){
                     pelotaBasket.transform.position=spawnPoint;
                }
                pelotaBasket.SetActive(true);
                rb=pelotaBasket.GetComponent<Rigidbody>();
                playerCollider=pelotaBasket.GetComponent<SphereCollider>();
                break;            
        }
        Debug.Log("HUMO"+ humo.transform.position);
        humo.transform.position=spawnPoint;
        }
}
