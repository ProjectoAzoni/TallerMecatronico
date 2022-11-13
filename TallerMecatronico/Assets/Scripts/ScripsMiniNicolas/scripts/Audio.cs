using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioSource music;
    
    public void Offaudio()
    {
        audio.Stop();
    }
    public void ONaudio()
    {
        audio.Play();
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
