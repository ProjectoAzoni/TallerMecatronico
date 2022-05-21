using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] Image [] stars;
    [SerializeField] Image [] starsBg;
    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckEnemys",0,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckEnemys()
    {
        
    }
}
