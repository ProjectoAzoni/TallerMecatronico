using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvL1AnimationController : MonoBehaviour
{
    [SerializeField] GameObject [] dialogs;
    Animator [] dialogAnimator;
    int dialogCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogs != null) {
            for(int i = 0; i < dialogs.Length; i++){
                dialogAnimator[i] = dialogs[i].gameObject.GetComponent<Animator>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDialog(){
        dialogCount++;
        
    }
}
