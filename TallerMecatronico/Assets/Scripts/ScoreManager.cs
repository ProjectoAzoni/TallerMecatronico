using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] Image [] imageStars;
    [SerializeField] Image [] starsBg;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject [] enemys, miniBoss;
    [SerializeField] GameObject boss;
    [SerializeField] BasicSaveManager bsm;
    int enemycount = 0, miniBossCount = 0, stars = 0;
    float score = 0;
    float maxScore = 500;
    
    bool bossDied = false;
    bool ecount = true, mbcount = true, c1 = true, c2 = true, c3 = true, c4 = true;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("CheckEnemys",0,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckEnemys()
    {
        if(enemys != null || miniBoss != null || boss != null){
            int counter = 0;
            int counter1 = 0;
            for (int i = 0; i < enemys.Length; i++)
            {            
                if(!enemys[i].activeInHierarchy){        
                    counter++;        
                }
            }
            enemycount = counter;
            for (int i = 0; i< miniBoss.Length; i++)
            {
                if(!miniBoss[i].activeInHierarchy)
                {
                    counter1++;
                }
            }
            miniBossCount = counter1;
            if (!boss.activeInHierarchy){
                bossDied = true;
            }
            else {
                bossDied = false;
            }
            CalcScore();
        }
        
    }

    public void CalcScore()
    { 
        if (enemycount <= (enemys.Length)/3 && enemycount > (enemys.Length)/4 && score < Mathf.Round(maxScore/5.5f) && c1)
        {
            c1 = false;
            score =Mathf.Round(score + maxScore/5.5f);
        }
        else if (enemycount <= (enemys.Length)/2 && enemycount > (enemys.Length)/3 && score < Mathf.Round(maxScore/3.5f) && c2)
        {
            c2 = false;
            score =Mathf.Round(score + maxScore/3.5f);
        }

        stars = 0;
        
        if (enemycount == enemys.Length && ecount)
        {
            ecount = false;
            stars++;
            score = score + Mathf.Round(maxScore/3f);
        }
        if (miniBossCount == miniBoss.Length && mbcount)
        {
            mbcount = false;
            stars++;
            score = Mathf.Round(score + maxScore/3f);
        } 
        else if (miniBossCount <= (miniBoss.Length)/2 && miniBossCount > (miniBoss.Length)/3 && c3)
        {
            c3 = false;
            score =Mathf.Round(score + maxScore/3.5f);
        }
        if (bossDied && c4){
            c4 = false;
            stars ++;
            score = Mathf.Round(score + maxScore/3f);
        }
        ShowScore();
    }

    public void ShowScore(){
        scoreText.text = score.ToString();
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

    public void SaveLevelData(){
        bsm.SetLevelData(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex, stars);
        int sc = Mathf.RoundToInt(score) + bsm.GetPointsData();
        bsm.SetPointsData(sc);
    }

    
}
