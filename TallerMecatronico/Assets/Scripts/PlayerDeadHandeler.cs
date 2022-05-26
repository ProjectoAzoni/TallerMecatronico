using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadHandeler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SceneController sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.gameObject.activeInHierarchy){
            sc.ReloadCurrentScene();
        }
        
    }
}
