using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent pierdeVida;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("COLISIONO CON " + col.transform.gameObject.tag);
        if (col.transform.gameObject.tag=="Abyss" || col.transform.gameObject.tag=="Spike")
        {
            pierdeVida.Invoke();
        }
    }

    [SerializeField] KeyCode _jumpKey;
    [SerializeField] KeyCode _basketBallKey ;
    [SerializeField] KeyCode _tenisBallKey;
    [SerializeField] KeyCode _bowlingBallKey;

    [SerializeField] private UnityEvent playerJumpAction;

    [SerializeField] private UnityEvent playerTransformAction;
        

    void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            playerJumpAction.Invoke();
        }
        if (Input.GetKeyDown(_basketBallKey)||Input.GetKeyDown(_tenisBallKey)||Input.GetKeyDown(_bowlingBallKey))
        {
            playerTransformAction.Invoke();
        }   
        if(Input.GetKeyUp(_basketBallKey)||Input.GetKeyUp(_tenisBallKey)||Input.GetKeyUp(_bowlingBallKey))
        {
            playerTransformAction.Invoke();
        }
    }
}
