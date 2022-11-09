using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTrigger : MonoBehaviour
{
    [SerializeField] SceneController sc;
    [SerializeField] ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            sc.GoToSceneAsSave(sc.GetCurrentSceneName()+"-2",Mathf.RoundToInt(sm.score),sm.stars);
            
        }
    }
}
