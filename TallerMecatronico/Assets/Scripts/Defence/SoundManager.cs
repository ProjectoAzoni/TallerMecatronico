using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip Music;
    [SerializeField] AudioMixerGroup audioManager;
    [SerializeField] AudioClip [] audios;
    List<AudioSource> sources = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = Music;
        gameObject.GetComponent<AudioSource>().Play();
        foreach (var audio in audios)
        {
            AudioSource component = gameObject.AddComponent<AudioSource>();
            component.playOnAwake = false;
            component.clip = audio;
            component.outputAudioMixerGroup = audioManager;
            sources.Add(component);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string filename){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == filename && !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayWashing(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "Wash" && !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayWarning(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "warning" && !sources[i].isPlaying){
                sources[i].loop = true;
                sources[i].Play();
            }
        }
    }
    public void StopWarning(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "warning" && sources[i].isPlaying){
                sources[i].Pause();
                sources[i].Stop();
            }
        }
    }
    public void PlayFalling(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "falling"&& !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayGrabing(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "grabbing"&& !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayDropping(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "dropping"&& !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayDanger(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "danger"&& !sources[i].isPlaying){
                sources[i].Play();
            }
        }
    }
    public void PlayStation(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "Station"&& !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayDrying(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "Dry"&& !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayBinned(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "binned" && !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayError(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "error" && !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
    public void PlayTimer(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "cronometro" && !sources[i].isPlaying){
                sources[i].loop = true;
                sources[i].Play();
            }
        }
    }
    public void StopTimer(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "cronometro" && !sources[i].isPlaying){
                sources[i].Stop();
            }
        }
    }
    public void PlayBlob(){
        for (int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == "blob" && !sources[i].isPlaying){
                sources[i].PlayOneShot(audios[i]);
            }
        }
    }
}
