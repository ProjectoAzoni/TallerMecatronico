using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationsHandeler : MonoBehaviour
{
    [SerializeField] Canvas notificationsCanvas;
    TMP_Text notificationText;

    [System.NonSerialized]public string [] actionList = {
        "Empty player Empty wash",              //0
        "Empty player Empty dry",               //1
        "Empty player Empty shred",             //2
        "Empty player Empty melt",              //3
        "Empty player Empty compress",          //4
        "Empty player Empty station",           //5
        "Player Holding trash try grab trash",  //6
        "Item characteristic not station",      //7
        "Item time 0",                          //8
        "Enemy taken"                           //9
    }; 
    
    string [] notificationMesseges  = {
        "Debes tomar un desecho y colocarlo en la estación de lavado",                  //0
        "Debes tomar un desecho y colocarlo en la estación de secado",                  //1
        "Debes tomar un desecho y colocarlo en la estación de cortado",                 //2
        "Debes tomar un desecho y colocarlo en la estación de derretimiento",           //3
        "Debes tomar un desecho y colocarlo en la estación de compresión",              //4
        "Debes tomar un desecho y colocarlo en la mesa",                                //5
        "No puedes tomar mas de un desecho a la vez",                                   //6
        "El desecho so se puede colocar en esta estación",                              //7
        "¡Ten cuidado! los desechos desaparecen y se convierten en nuevos enemigos",    //8
        "¡Ten cuidado! si los enemigos toman los desechos no ganaras puntos"            //9
    };
    // Start is called before the first frame update
    void Start()
    {
        notificationText = notificationsCanvas.GetComponentInChildren<TMP_Text>();
        notificationText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNotificationsCanvas (){
        notificationsCanvas.gameObject.SetActive(true);
    }
    public void HideNotificationsCanvas (){
        notificationsCanvas.gameObject.SetActive(false);
    }
    public void SetNotificationsText (string text){
        notificationText.text = text;
    }
    public void ActionNotification(string action){
        for (int i = 0; i < actionList.Length; i++)
        {
            if(action == actionList[i]){
                SetNotificationsText(notificationMesseges[i]);
                ShowNotificationsCanvas();
            }
        }
    }
    // public void CreateNotification (string text){
    //     SetNotificationsText(text);

    // }
}
