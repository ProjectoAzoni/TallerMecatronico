using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botella : MonoBehaviour
{

    public int valor = 1;
    public GameManager gameManager;
    public AudioManager audioManager;
    public AudioClip coinSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
            audioManager.ReproducirSonido(coinSFX);
        }

    }
}