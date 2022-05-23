using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuLoadData : MonoBehaviour
{
    [SerializeField] BasicSaveManager bsm;
    [SerializeField] int levels = 0;
    [SerializeField] Image [] imageStarsLvL;
    [SerializeField] Image [] starsBgLvl;
    [SerializeField] int MiniGames = 0;
    [SerializeField] Image [] imageStarsMG;
    [SerializeField] Image [] starsBgMG;

    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = bsm.GetPointsData().ToString();
        levels = bsm.GetLevelData(1);
        MiniGames = bsm.GetMiniGameData(0);
        ShowPoints();
        ShowStars();
        
        

    }

    private void ShowStars()
    {
        switch(MiniGames){
            case 1:
                imageStarsMG[0].color = new Color(0,255,90,255);
                imageStarsMG[1].color = new Color(255,255,255,255);
                imageStarsMG[2].color = new Color(255,255,255,255);

                starsBgMG[0].color = new Color(0,255,90,255);
                starsBgMG[1].color = new Color(255,255,255,255);
                starsBgMG[2].color = new Color(255,255,255,255);

                return;
            case 2:
                imageStarsMG[0].color = new Color(0,255,90,255);
                imageStarsMG[1].color = new Color(0,255,90,255);
                imageStarsMG[2].color = new Color(255,255,255,255);

                starsBgMG[0].color = new Color(0,255,90,255);
                starsBgMG[1].color = new Color(0,255,90,255);
                starsBgMG[2].color = new Color(255,255,255,255);
                return;
            case 3:
                imageStarsMG[0].color = new Color(0,255,90,255);
                imageStarsMG[1].color = new Color(0,255,90,255);
                imageStarsMG[2].color = new Color(0,255,90,255);

                starsBgMG[0].color = new Color(0,255,90,255);
                starsBgMG[1].color = new Color(0,255,90,255);
                starsBgMG[2].color = new Color(0,255,90,255);
                return;
        }
    }

    private void ShowPoints()
    {
        switch(levels){
            case 1:
                imageStarsLvL[0].color = new Color(0,255,90,255);
                imageStarsLvL[1].color = new Color(255,255,255,255);
                imageStarsLvL[2].color = new Color(255,255,255,255);

                starsBgLvl[0].color = new Color(0,255,90,255);
                starsBgLvl[1].color = new Color(255,255,255,255);
                starsBgLvl[2].color = new Color(255,255,255,255);

                return;
            case 2:
                imageStarsLvL[0].color = new Color(0,255,90,255);
                imageStarsLvL[1].color = new Color(0,255,90,255);
                imageStarsLvL[2].color = new Color(255,255,255,255);

                starsBgLvl[0].color = new Color(0,255,90,255);
                starsBgLvl[1].color = new Color(0,255,90,255);
                starsBgLvl[2].color = new Color(255,255,255,255);
                return;
            case 3:
                imageStarsLvL[0].color = new Color(0,255,90,255);
                imageStarsLvL[1].color = new Color(0,255,90,255);
                imageStarsLvL[2].color = new Color(0,255,90,255);

                starsBgLvl[0].color = new Color(0,255,90,255);
                starsBgLvl[1].color = new Color(0,255,90,255);
                starsBgLvl[2].color = new Color(0,255,90,255);
                return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
