using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenuHistory : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject HistoryPanel;

    // Start is called before the first frame update
    void Awake(){
        director = director.GetComponent<PlayableDirector>();
    }
    void Start()
    {
        if(!HistoryPanel.gameObject.activeSelf && director.state == PlayState.Paused){
            director.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HistoryPanel.gameObject.activeInHierarchy && director.state == PlayState.Paused){
            director.Stop();
            HistoryPanel.SetActive(false);
        }
    }
}
