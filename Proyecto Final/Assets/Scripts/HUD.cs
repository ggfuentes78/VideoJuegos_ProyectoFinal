using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class HUD : MonoBehaviour
{
    [Header ("Menu Pausa")]
    public GameObject menuPausa;
    public bool pausaActiva;

    [Header ("Menu Lvl Finished")]
    public GameObject menuLvlFinished;

    [Header ("Game Over")]
    public GameObject menuGameOver;

    
    [Header ("HUD")]
    public GameObject HUDGame;
    public TMP_Text cantVidas;
    public TMP_Text tiempo;

    [SerializeField] public UnityEvent gameOver;

    void Start()
    {
        Time.timeScale=1;
        cantVidas.text=Player.vidas.ToString();
        tiempo.text=Player.timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        cantVidas.text=Player.vidas.ToString();
        tiempo.text=Player.timer.ToString();
        if (Player.vidas>0)
        {
            TogglePausa();
        }else{
            gameOver.Invoke();
        }

    }

    public void TogglePausa()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausaActiva)
            {
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        menuPausa.SetActive(true);
        pausaActiva=true;
        Time.timeScale=0;
    }

    public void ResumeGame()
    {
        menuPausa.SetActive(false);
        pausaActiva=false;
        Time.timeScale=1;
    }

    public void HUDGameOver()
    {
        HUDGame.SetActive(false);
        Time.timeScale=0;
        menuGameOver.SetActive(true);
    }

    public void HUDLvlFinished()
    {
        HUDGame.SetActive(false);
        menuLvlFinished.SetActive(true);
        Time.timeScale=0;
        
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void CargaLvl(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
