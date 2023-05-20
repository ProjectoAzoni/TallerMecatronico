using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    //este se explica solo :v
    public string [] types = {"Plastic","Carton","Metal","Glass","Paper","Organic", "Other"};
    public string myType;   
    public string [] throwPlaces;
    public string myThrowPlace;
     public string [] characteristics;
     //Binned must always be the last item on the array "states"
    public string [] states = {"Grabbed","Dropped","Process","Taken","Binned"};
    public bool show = false;
    public string currentState;

    public float myTimer=0f;  
    // Start is called before the first frame update
    void Start()
    {
        currentState = states[1];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
