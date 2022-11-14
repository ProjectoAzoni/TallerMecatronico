using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource audios;
    [SerializeField] AudioSource music;
    
    public void Offaudio()
    {
        audios.Stop();
    }
    public void ONaudio()
    {
        audios.Play();
    }
    
    
    public void Offmusic()
    {
        music.Stop();
    }
    public void ONmusic()
    {
        music.Play();
    }


}
