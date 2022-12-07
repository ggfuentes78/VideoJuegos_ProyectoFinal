using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource sonidoHumo;
    public AudioSource sonidoGameOver;
    public AudioSource pierdeVida;

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
}
