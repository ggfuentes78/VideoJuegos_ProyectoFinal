using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pelota : MonoBehaviour
{
    private float movX;
    private float movY;
    public bool isInGround;

    public float speed = 8f;
    public float jumpForce = 7f;

    public Rigidbody rb;
    // private GameObject vcam;
    public Vector3 spawnPoint;
    public Vector3 startPoint;
 

    public enum TipoPelota
    {
        Futbol,
        Tenis,
        Bowling,
        Basket
    };

    public TipoPelota tipoPelota;


    void Start()
    {

    }
    void Update()
    {
    
    }


    public void MovimientoJugador()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector3 inputJugador = new Vector3(-movX, 0, -movY);
        rb.AddForce(inputJugador * speed * Time.fixedDeltaTime);
       
    }

    public void Saltar()
    {
        if (isInGround)
        {        
            rb.AddForce(new Vector3(0f, 1f, 0f) * jumpForce, ForceMode.Impulse);
        }
    }

}
