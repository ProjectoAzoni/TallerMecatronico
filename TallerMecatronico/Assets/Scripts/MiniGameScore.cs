using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameScore : MonoBehaviour
{
     [SerializeField] Image [] imageStars;
    [SerializeField] Image [] starsBg;
    [SerializeField] MniGame mg;
    [SerializeField] Text scoreText, menuScoreText;
    [SerializeField] Text total, restantes;
    int minScore = 0, currentScore = 0;
    int rema, stars;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null){
            scoreText.text = minScore.ToString();
        }
        if (total != null){
            rema = mg.itemsBox.transform.childCount;
            total.text = mg.itemsBox.transform.childCount.ToString();
        }
        if (restantes != null){
            restantes.text = mg.itemsBox.transform.childCount.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int score){
        currentScore = currentScore + score;
        ShowScore();
    }
    public void RestScore(int score){
        if (currentScore- score >= 0)
        {
            currentScore = currentScore - score;
            ShowScore();
        }
    }

    void ShowScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void ShowRemaning(){
        if (rema >= 0)
        {
            rema --;
        }else 
        {
            rema = 0;
        }
        
        restantes.text = rema.ToString();
    }

    public void CalcMiniGameScore()
    {
        if(mg.itemcount > 0.1*mg.maxItemcount && mg.itemcount <= 0.3333*mg.maxItemcount){
            stars = 1;
        }else if (mg.itemcount > 0.3333*mg.maxItemcount && mg.itemcount <= 0.6666*mg.maxItemcount)
        {
            stars = 2;
        }else if (mg.itemcount > 0.6666*mg.maxItemcount && mg.itemcount <= mg.maxItemcount)
        {
            stars = 3;
        }
        menuScoreText.text = currentScore.ToString();
        ShowStars();
    }

    public void ShowStars(){
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
}
