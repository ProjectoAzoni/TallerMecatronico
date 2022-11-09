using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerDefense : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Image [] imageStars;
    [SerializeField] Image [] starsBg;
    [SerializeField] ItemsManager im;
    [SerializeField] ItemTimerHandeler ith;
    [SerializeField] BasicSaveManager bsm;

    List<GameObject> items = new List<GameObject>();

    float score, maxTime, spawnRate, itemMaxConut;

    [SerializeField] int maxScore = 500;

    int itemCount, itemMax, stars;
    private void Awake() {
        
    }
    void Start()
    {
        stars = bsm.GetLevelData(1); // change to make it automatic
        maxTime = im.timeRemaining;
        itemMax = im.itemNum;
        spawnRate = im.ItemSpawnRepeatRate;
        items = im.ItemsObjStatic;
        itemMaxConut = (float)(maxTime/((40+15+spawnRate) ))*2.5f + (itemMax*0.1f);

        InvokeRepeating("CheckItems", 0, 2);
    }

    void CheckItems(){
        int count = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if(!items[i].activeInHierarchy){
                count++;
            }
        }
        itemCount = count;
        CheckScore();
        ShowScore();
    }

    void CheckScore(){
        score = itemCount <= itemMaxConut ? (float) maxScore * (itemCount / itemMaxConut) : (float)maxScore;
        stars = itemCount < itemMaxConut * 0.2f && stars + 0 <= 3? stars + 0 : itemCount >= itemMaxConut * 0.2f && itemCount < itemMaxConut*0.7f && stars + 1 <= 3 ? stars + 1: itemCount >= itemMaxConut * 0.7f && itemCount <= itemMaxConut && stars + 2 <= 3? stars + 2: itemCount > itemMaxConut && stars + 2 <= 3? stars + 2 : 0;
    }

    public void ShowScore(){
        scoreText.text = Mathf.RoundToInt(score).ToString();
        switch(stars){
            case 1:
                imageStars[0].color = new Color(0,255,90,255);
                imageStars[1].color = new Color(255,255,255,255);
                imageStars[2].color = new Color(255,255,255,255);

                starsBg[0].color = new Color(0,255,90,255);
                starsBg[1].color = new Color(255,255,255,255);
                starsBg[2].color = new Color(255,255,255,255);

                return;
            case 2:
                imageStars[0].color = new Color(0,255,90,255);
                imageStars[1].color = new Color(0,255,90,255);
                imageStars[2].color = new Color(255,255,255,255);

                starsBg[0].color = new Color(0,255,90,255);
                starsBg[1].color = new Color(0,255,90,255);
                starsBg[2].color = new Color(255,255,255,255);
                return;
            case 3:
                imageStars[0].color = new Color(0,255,90,255);
                imageStars[1].color = new Color(0,255,90,255);
                imageStars[2].color = new Color(0,255,90,255);

                starsBg[0].color = new Color(0,255,90,255);
                starsBg[1].color = new Color(0,255,90,255);
                starsBg[2].color = new Color(0,255,90,255);
                return;
        }
    }
    public void SaveData(){
        bsm.SetLevelData(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex, stars);
        int sc = Mathf.RoundToInt(score) + bsm.GetPointsData();
        bsm.SetPointsData(sc);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
