using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadHandeler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SceneController sc;

    bool isDead;
    private void Awake() {

    }
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!player.gameObject.activeInHierarchy && !isDead){
            isDead = true;
            sc.ReloadCurrentSceneAs();
        }
        
    }
}
