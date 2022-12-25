using UnityEngine;
using UnityEngine.SceneManagement;

public class Arco : MonoBehaviour
{
    public int nextLvl;
    public GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.transform.tag=="Player")
        {
            Debug.Log("GOLAZO");
            // hud.HUDLvlFinished();
            // CargaLvl(nextLvl);
        }
    }
}
