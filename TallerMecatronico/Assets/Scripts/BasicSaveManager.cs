using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSaveManager : MonoBehaviour
{
    //set the stars per level
    public void SetLevelData(int level, int numEstrellas) {
            // if the higest score is less than the new score
            if (GetLevelData(level) < numEstrellas)
            {
                //Save the new score in the level
                PlayerPrefs.SetInt("level" + level, numEstrellas);
            }
            else
            {
                //The higest score is already saved
            }
    }
    public void SetMiniGameData(int miniGame, int numEstrellas) {
            // if the higest score is less than the new score
            if (GetLevelData(miniGame) < numEstrellas)
            {
                //Save the new score in the level
                PlayerPrefs.SetInt("MG" + miniGame, numEstrellas);
            }
            else
            {
                //The higest score is already saved
            }
    }
    //Save the volume value of the MainVolume/MusicVolume/EffectsVolume
    public void SetVolumeData(string volumeParameter, float value) {
        PlayerPrefs.SetFloat(volumeParameter, value);
    }


    //Get the number of stars per level if any
    public int GetLevelData(int level) {
        return PlayerPrefs.GetInt("level"+level);
    }
    //Get the saved volume value of the MainVolume/MusicVolume/EffectsVolume
    public float GetVolumeData(string volumeParameter) {
        return PlayerPrefs.GetFloat(volumeParameter);
    }
    //Delete the info in the level named keyName
    public void DeleteKey(string keyName) {
        PlayerPrefs.DeleteKey(keyName);
    }
    //Delete the info of all levels
    public void DeleteAllLevelData() {
        PlayerPrefs.DeleteAll();
    }
    //Save the points gained
    public void SetPointsData(int point) {
        PlayerPrefs.SetInt("Points", point);
    }
    //Get the points saved
    public int GetPointsData()
    {
        return PlayerPrefs.GetInt("Points");
    }
    public int GetMiniGameData(int miniGame)
    {
        return PlayerPrefs.GetInt("MG"+miniGame);
    }
    public string GetPointsDataString()
    {
        return PlayerPrefs.GetInt("Points").ToString();
    }

    public void SetStartHistory(){
        PlayerPrefs.SetInt("History", 1);
    }
    public void SetStopHistory(){
        PlayerPrefs.SetInt("History", 0);
    }

    public int GetHistorySate(){
        return PlayerPrefs.GetInt("History");
    }
}
