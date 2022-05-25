using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class LvL1AnimController : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject DialogCanvas;
    void Awake(){
        director = director.GetComponent<PlayableDirector>();
        director.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state == PlayState.Paused && DialogCanvas.gameObject.activeInHierarchy){
            director.Stop();
            DialogCanvas.gameObject.SetActive(false);
        }

    }

}
