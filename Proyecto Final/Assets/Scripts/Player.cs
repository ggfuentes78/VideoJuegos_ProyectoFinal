using UnityEngine;

public class Player : MonoBehaviour
{
    private float movX;
    private float movY;

    public float speed = 8f;
    public float jumpForce = 7f;

    public Rigidbody rb;
    public Rigidbody rb2;
    public bool isInGround;

    public GameObject pelotaFutbol;
    public GameObject pelotaTenis;
    public GameObject pelotaBasket;
    public GameObject pelotaBowling;
    public ParticleSystem humo;
    private GameObject vcam;
    public Vector3 spawnPoint;
    public int vidas;
    public Vector3 startPoint;
 

    public enum TipoPelota
    {
        Futbol,
        Tenis,
        Bowling,
        Basket
    };

    public TipoPelota tipoPelota;


    // Start is called before the first frame update
    void Start()
    {
        startPoint= transform.position;
        spawnPoint=transform.position;
        tipoPelota=(TipoPelota)0;
        vidas=3;
    }

    // Update is called once per frame
    void Update()
    {
        if(vidas>0){
            if (Input.GetKeyDown(KeyCode.Space)&&isInGround)
            {
                rb.AddForce(new Vector3(0f, 1f, 0f) * jumpForce, ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                spawnPoint=pelotaFutbol.transform.position;
                humo.Play();
                tipoPelota=(TipoPelota)1;
            }else{
                if(Input.GetKeyDown(KeyCode.C))
                {
                    spawnPoint=pelotaFutbol.transform.position;
                    humo.Play();
                    tipoPelota=(TipoPelota)2;
                }else{
                    if(Input.GetKeyDown(KeyCode.Z))
                    {
                        spawnPoint=pelotaFutbol.transform.position;
                        humo.Play();
                        tipoPelota=(TipoPelota)3;
                    }
                }
            }

            if(Input.GetKeyUp(KeyCode.Z))
            {
                spawnPoint=pelotaBasket.transform.position;
                humo.Play();
                tipoPelota=(TipoPelota)0;
            }else{
                if(Input.GetKeyUp(KeyCode.X))
                {
                    spawnPoint=pelotaTenis.transform.position;
                    humo.Play();
                    tipoPelota=(TipoPelota)0;
                }else{
                    if(Input.GetKeyUp(KeyCode.C))
                    {
                        spawnPoint=pelotaBowling.transform.position;
                        humo.Play();
                        tipoPelota=(TipoPelota)0;
                    }
                }
            }

            TipoPlayer(tipoPelota);
        }else{
            Debug.Log("GAME OVER");
        }
    }

    void FixedUpdate()
    {
        MovimientoJugador();
    }


    void MovimientoJugador()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector3 inputJugador = new Vector3(-movX, 0, -movY);
        rb.AddForce(inputJugador * speed * Time.fixedDeltaTime);
        // rb2.AddForce(inputJugador * speed * Time.fixedDeltaTime);
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("COLISIONO CON " + col.transform.gameObject.tag);
        if (col.transform.gameObject.tag=="Ground")
        {
            isInGround=true;
        }
        if (col.transform.gameObject.tag=="Abyss" || col.transform.gameObject.tag=="Spike")
        {
            // PierdeVida();
           Debug.Log("Pierde Vida!");
           vidas--;
           spawnPoint=startPoint;
           tipoPelota=(TipoPelota)0;
           pelotaFutbol.transform.position=startPoint;
        }
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("SALGO DE COLISIONAR CON " + col.transform.gameObject.tag);
        if (col.transform.gameObject.tag=="Ground")
        {
            isInGround=false;
        }
    }

    // void OnTriggerEnter(Collider col) 
    // {
        // if (col.CompareTag("Abyss"))
        // {
            // PierdeVida();
        // }
    // }

    void PierdeVida()
    {
        Debug.Log("Pierde Vida!");
        vidas--;
        spawnPoint=startPoint;
        tipoPelota=(TipoPelota)0;
        // TipoPlayer(tipoPelota);
        
    }

    void TipoPlayer(TipoPelota tipoPelota)
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
                break;            
        }
        humo.transform.position=spawnPoint;
        // pelotaFutbol.transform.position=new Vector3(0,0,0);
        // pelotaTenis.transform.position=new Vector3(0,0,0);
        // pelotaBowling.transform.position=new Vector3(0,0,0);
        // pelotaBasket.transform.position=new Vector3(0,0,0);
        // 
    }
}
