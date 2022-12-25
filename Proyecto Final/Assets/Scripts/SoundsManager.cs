using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource sonidoHumo;
    public AudioSource sonidoGameOver;
    public AudioSource pierdeVida;
    public AudioSource lvlMusic;
    public AudioSource sonidoHielo;
    public AudioSource sonidoGol;

    public void Start()
    {
        lvlMusic.Play();
    }

    public void transformacionPlayer()
    {
        sonidoHumo.Play();
    }

    public void PlayGameOver()
    {
        sonidoGameOver.Play();
    }

    public void PlayPierdeVida()
    {
        pierdeVida.Play();
    }

    public void PlayHielo()
    {
        sonidoHielo.Play();
    }

    public void PlayGol()
{
    sonidoGol.Play();
}
}
