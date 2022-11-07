using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Get the objects and scripst form the editor
    [SerializeField] AudioMixer mainVolume;
    [SerializeField] BasicSaveManager bsm;
    [SerializeField] Dropdown qualityDrop;
    [SerializeField] Toggle history;
    [SerializeField] Slider GeneralSlider, MusicSlider, efxSlider;
    // this one is public because it is accessed from other script 
    public string[] volumeParameter = { "GeneralVolume", "MusicVolume", "efxVolume" };

    //when the game launch, set the volume sliders to the saved value 
    private void Awake()
    {
        SetStartData();
    }
    
    //Set and save the value of the Main volume and slider when it changes
    public void SetGeneralVolume(float volume) {
        float num = Mathf.Log10(volume) * 20;
        mainVolume.SetFloat(volumeParameter[0], num);
        bsm.SetVolumeData(volumeParameter[0], num);
    }

    //Set and save the value of the effects volume and slider when it changes
    public void SetEffectsVolume(float volume)
    {
        float num = Mathf.Log10(volume) * 20;
        mainVolume.SetFloat(volumeParameter[2], num);
        bsm.SetVolumeData(volumeParameter[2], num);
    }

    //Set and save the value of the Music voulme and slider when it changes
    public void SetMusiclVolume(float volume)
    {
        float num = Mathf.Log10(volume) * 20;
        mainVolume.SetFloat(volumeParameter[1],num);
        bsm.SetVolumeData(volumeParameter[1], num);
    }

    //set the value of the 3 slaiders when nedded
    public void SetSliderValue(float value, string slider) {
        switch (slider) {
            case "GeneralVolume":
                GeneralSlider.value = value;
                return;
            case "MusicVolume":
                MusicSlider.value = value;
                return;
            case "efxVolume":
                efxSlider.value = value;
                return;
        }
    }
    //set the quality with a dropdown box
    public void SetQuality(int quality) {
        qualityDrop.value = quality;
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetHistory(bool ison){
        if (ison){
            bsm.SetStartHistory();
        }else {
            bsm.SetStopHistory();
        }
    }

    public void StartStopGame(){
        if(Time.timeScale == 1){
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0){
            Time.timeScale = 1;
        }
    }
    public void DefaultStart(){
        Time.timeScale=1;
    }

    public void SetStartData(){
        if(bsm.GetHistorySate() == 1){
            history.isOn = true;
        }else if (bsm.GetHistorySate() == 0){
            history.isOn = false;
        }
        for (int i=0; i < volumeParameter.Length; i++) {
            SetSliderValue(Mathf.Pow(10f,(bsm.GetVolumeData(volumeParameter[i]))/(20f)), volumeParameter[i]);
           
        }
        SetQuality(QualitySettings.GetQualityLevel());
    }
}
