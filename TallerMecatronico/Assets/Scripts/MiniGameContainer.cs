using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameContainer : MonoBehaviour
{
    [SerializeField] MniGame mg;
    [SerializeField] MiniGameScore mgs;
    void Start(){

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            StartCoroutine(DisableBullet(collision));
        }
        if(collision.gameObject.tag == "Bullet" && mg.shooted && gameObject.tag == "White")
        {
            if (mg.itemsBox.gameObject.transform.GetChild(mg.itemcount).GetComponent<Image>().color == new Color32(255,255,255,1)){
                mgs.AddScore(10);
                mg.MoveItems();
                mgs.ShowRemaning();
            }else {
                mgs.RestScore(5);
            }
        }
        if(collision.gameObject.tag == "Bullet" && mg.shooted && gameObject.tag == "Green")
        {
            if (mg.itemsBox.transform.GetChild(mg.itemcount).GetComponent<Image>().color == new Color32(0,212,0,1)){
                mgs.AddScore(10);                
                mg.MoveItems();
                mgs.ShowRemaning();
            }else {
                mgs.RestScore(5);
            }
        }
        if(collision.gameObject.tag == "Bullet" && mg.shooted && gameObject.tag == "Black")
        {
            if (mg.itemsBox.gameObject.transform.GetChild(mg.itemcount).GetComponent<Image>().color == new Color32(0,0,0,1)){
                mgs.AddScore(10);
                mg.MoveItems();
                mgs.ShowRemaning();
            }else {
                mgs.RestScore(5);
            }
        }     
    }

    IEnumerator DisableBullet(Collision collision){
        yield return new WaitForSeconds(0.5F);
        collision.gameObject.SetActive(false);
    }
}
