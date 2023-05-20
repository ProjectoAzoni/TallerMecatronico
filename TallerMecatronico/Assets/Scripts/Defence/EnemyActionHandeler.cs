using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyActionHandeler : MonoBehaviour
{
    [SerializeField] EnemyManager em;
    [SerializeField] Transform grabPoint;
    //int rayDist = 2;
    NavMeshAgent nm;
    Vector3 currentDes;
    Vector3 startPos;
    [HideInInspector] public GameObject currentitem;
    ItemTimerHandeler ith;
    SoundManager soundManager;
    bool grab = false, completed = false;
    public bool diff = false;

    NotificationsHandeler nh;

    private void Awake() {
        em = FindObjectOfType<EnemyManager>();
        nh = GameObject.Find("Notification_Canvas").GetComponent<NotificationsHandeler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(grab && Vector3.Distance(transform.position, startPos) < 1f){
        //     GetComponent<Animator>().SetTrigger("Exit");
        // }

        if(currentitem != null && !grab && !completed){
            transform.LookAt(new Vector3(currentitem.transform.position.x, 1.8f, currentitem.transform.position.z));
            nm.SetDestination(new Vector3(currentitem.transform.position.x, 1.8f, currentitem.transform.position.z));
        }
        if(grab && currentitem != null && !completed){
                currentitem.transform.position = grabPoint.position;
        }
        if(transform.position.x == startPos.x && transform.position.z == startPos.z && grab && !completed){
            gameObject.SetActive(false);
            currentitem.gameObject.SetActive(false);
            grab = false;
            completed = true;
        }
        
        if(!diff){
            if(currentitem!= null && nm.destination != startPos && transform.position != em.enemySpawnStartPos.position && !completed){
                if(Vector3.Distance(transform.position, new Vector3(currentitem.transform.position.x, 1.8f, currentitem.transform.position.z))<= nm.stoppingDistance + 1.2f){
                    if(currentitem.GetComponent<TrashManager>().currentState != currentitem.GetComponent<TrashManager>().states[1] && !grab){
                        if(ith.GetPanel(currentitem) != null){
                            soundManager.StopWarning();
                            ith.GetPanel(currentitem).GetComponent<Animator>().SetTrigger("Idle");
                        }
                        nm.SetDestination(startPos);
                        currentitem = null;
                        em.isMoved = false;
                        return;
                    }

                    if(currentitem.GetComponent<TrashManager>().currentState == currentitem.GetComponent<TrashManager>().states[1] && !grab){
                        currentitem.transform.position = grabPoint.position;
                        currentitem.GetComponent<TrashManager>().currentState = currentitem.GetComponent<TrashManager>().states[3];
                        soundManager.StopTimer();
                        soundManager.StopWarning();
                        currentitem.GetComponentInChildren<Animator>().SetTrigger("Still");
                        nm.SetDestination(startPos);
                        grab = true;
                        ith.StartCoroutine("RestItem",currentitem);
                        em.isMoved = false;
                        nh.ActionNotification(nh.actionList[9]);
                    }
                }
            }

        }else {
            if(currentitem!= null && nm.destination != startPos && transform.position != em.enemySpawnStartPos.position && !grab && !completed){
                if(Vector3.Distance(transform.position, new Vector3(currentitem.transform.position.x, 1.8f, currentitem.transform.position.z))<= nm.stoppingDistance + 2f){
                    currentitem.transform.position = grabPoint.position;
                    currentitem.GetComponent<TrashManager>().currentState = currentitem.GetComponent<TrashManager>().states[3];
                    soundManager.StopTimer();
                    soundManager.StopWarning();
                    currentitem.GetComponentInChildren<Animator>().SetTrigger("Still");
                    nm.SetDestination(startPos);
                    grab = true;
                    ith.StartCoroutine("RestItem",currentitem);
                    em.isMoved = false;
                }
            }            
        }
    }
    public void MoveEnemy(Vector3 startPos, GameObject item, ItemTimerHandeler ith){
        Vector3 desPos = item.transform.position;
        nm.SetDestination(desPos);
        currentDes = new Vector3(desPos.x,1.8f,desPos.z);
        this.startPos = startPos;
        currentitem = item;
        this.ith = ith;
        if(ith.GetPanel(item) != null){
            ith.GetPanel(item).GetComponent<Animator>().SetTrigger("WarningE");
            soundManager.PlayWarning();
        }
    }
    
    public void SetEnemy(SoundManager soundManager,NotificationsHandeler nh){
        this.soundManager = soundManager;
        this.nh = nh;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*(nm.stoppingDistance+1.2f));
    }
}
