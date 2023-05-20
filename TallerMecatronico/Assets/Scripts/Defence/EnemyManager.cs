using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] NotificationsHandeler nh;
    [SerializeField] ItemTimerHandeler ith;
    [SerializeField] ItemsManager im;
    [SerializeField] public Transform enemySpawnStartPos;
    [SerializeField] GameObject [] enemysDefencePrefab;
    [SerializeField] Transform enemyHolderManager;
    [SerializeField] Vector3 [] spawnPos;
    [SerializeField] Vector3 [] spawnScale;
    [SerializeField] int numEnemies;
    [SerializeField] int difficultyTime;
    [SerializeField] int roundTime;
    List<GameObject> enemies = new List<GameObject>();
    float [] timeSpawn;
    float timer;
    //[HideInInspector]
     public bool isMoved = false;
    
    // Start is called before the first frame update
    void Awake() {
        SetEnemies();
    }
    void Start()
    {
        InvokeRepeating("TimeMoveEnemy", 0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        roundTime= Mathf.RoundToInt(im.timeRemaining);      
    }
    void TimeMoveEnemy(){
        for (int g = 0; g < timeSpawn.Length; g++)
        {
            if(roundTime == Mathf.RoundToInt(timeSpawn[g]) && !isMoved){
                if(roundTime <= difficultyTime){
                    isMoved = true;
                    MoveEnemy(true);
                }
                else{
                    isMoved = true;
                    MoveEnemy();
                }
                
            }   
        }
    }
    void SetEnemies(){
        timer = im.timeRemaining;
        timeSpawn = new float[numEnemies];
        for (int l = 0; l < numEnemies; l++)
        {
            float num2 = UnityEngine.Random.Range(timer*0.1f, timer*0.95f);
            timeSpawn[l] = num2;

            int num3 = UnityEngine.Random.Range(0, enemysDefencePrefab.Length-1 > 0? enemysDefencePrefab.Length : 0);
            GameObject obj = Instantiate(enemysDefencePrefab[num3], enemySpawnStartPos.position, Quaternion.identity, enemyHolderManager);
            enemies.Add(obj);
        }
    }
    void MoveEnemy(){
        if(ith.items.Count > 0){
            int num = UnityEngine.Random.Range(0, enemies.Count-1);
            int numb = UnityEngine.Random.Range(0, spawnPos.Length-1);
            int num1 = UnityEngine.Random.Range(0, ith.items.Count-1);
            Vector3 newPos = spawnPos[numb] + new Vector3(UnityEngine.Random.Range(-spawnScale[numb].x/2,spawnScale[numb].x/2),0f,UnityEngine.Random.Range(-spawnScale[numb].z/2,spawnScale[numb].z/2));
            enemies[num].transform.position = newPos;
            enemies[num].GetComponent<EnemyActionHandeler>().SetEnemy(soundManager, nh);
            enemies[num].GetComponent<EnemyActionHandeler>().MoveEnemy(newPos, ith.items[num1], ith);
            // enemies[num].GetComponent<Animator>().SetTrigger("Idle");        
            for (int g = 0; g < enemies.Count; g++)
            {
                if(enemies[g] == enemies[num]){
                    enemies.RemoveAt(g);
                    break;
                }       
            }
        }
           
    }
    void MoveEnemy(bool diff){
        if(ith.items.Count > 0){
            int num = UnityEngine.Random.Range(0, enemies.Count-1);
            int numb = UnityEngine.Random.Range(0, spawnPos.Length-1);
            int num1 = UnityEngine.Random.Range(0, ith.items.Count-1);
            Vector3 newPos = spawnPos[numb] + new Vector3(UnityEngine.Random.Range(-spawnScale[numb].x/2,spawnScale[numb].x/2),0f,UnityEngine.Random.Range(-spawnScale[numb].z/2,spawnScale[numb].z/2));
            enemies[num].transform.position = newPos;
            enemies[num].GetComponent<EnemyActionHandeler>().diff = true;
            enemies[num].GetComponent<NavMeshAgent>().speed = enemies[num].GetComponent<NavMeshAgent>().speed * 2.5f;
            enemies[num].GetComponent<NavMeshAgent>().acceleration = enemies[num].GetComponent<NavMeshAgent>().acceleration * 2.5f;
            enemies[num].GetComponent<EnemyActionHandeler>().SetEnemy(soundManager, nh);
            enemies[num].GetComponent<EnemyActionHandeler>().MoveEnemy(newPos, ith.items[num1], ith);
            // enemies[num].GetComponent<Animator>().SetTrigger("Idle");        
            for (int g = 0; g < enemies.Count; g++)
            {
                if(enemies[g] == enemies[num]){
                    enemies.RemoveAt(g);
                    break;
                }       
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        for (int o = 0; o < spawnPos.Length; o++)
        {
            Gizmos.DrawCube(spawnPos[o], spawnScale[o]);
        }
    }
}
