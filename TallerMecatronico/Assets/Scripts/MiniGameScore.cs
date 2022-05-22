using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameScore : MonoBehaviour
{
    [SerializeField] MniGame mg;
    [SerializeField] Text scoreText;
    [SerializeField] Text total, restantes;
    int minScore = 0, currentScore = 0;
    int rema;
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
        rema --;
        restantes.text = rema.ToString();
    }
}
