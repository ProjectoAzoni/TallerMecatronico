using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShootManager : MonoBehaviour
{
    
    [SerializeField] string [] bullets;
    [SerializeField] GameObject [] bulletImages;
    public GameObject collisionParticle, shootParticle;
    public int damage = 0;
    public float range = 50f;
    public float fireRate = 4f;
    float fireTime = 0f;
    ParticleSystem shootParticle0;

    string currentBullet = "B00";
    int bulletCount = 0;

   public Dictionary<string, int>  bulletsDic =  new Dictionary<string, int>
    { {"B00", 5}, {"B01", 10}, {"B10", 15}, {"B11", 20}}; 

    // Start is called before the first frame update
    void Start()
    {
        currentBullet = bullets[bulletCount];
        bulletImages[bulletCount].GetComponent<Image>().color = new Color32(93,157,173,255);
        shootParticle0 = shootParticle.GetComponent<ParticleSystem>();
    }

    // Update is not used
    void Update()
    {
        
    }
    public void PlayerShoot(){
        
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range) && Time.time >= fireTime)
        {
            shootParticle0.Play();
            fireTime = Time.time + 1f / fireRate;
            EnemyCollisionHandeler ech = hit.transform.GetComponent<EnemyCollisionHandeler>();
            if (ech != null)
            {
                CheckBullet(ech);
                //ech.TakeDamage(damage);
            }
            GameObject ptle = Instantiate(collisionParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ptle, 0.5f);
        }
    }

    public void CheckBullet(EnemyCollisionHandeler ech){
        foreach (KeyValuePair<string,int> bul in bulletsDic)
        {
            if(currentBullet == bul.Key){
                damage = bul.Value;
                ech.TakeDamageBullet(bul.Key, bul.Value);
            }
        }
    }
    public void SwitchBullet(){
        if (currentBullet != bullets[bullets.Length-1]){
            bulletCount++;
            currentBullet = bullets[bulletCount];
            
            for (int i = 0; i < bulletImages.Length; i++)
            {
                if(bulletCount == i)
                {
                    bulletImages[bulletCount].GetComponent<Image>().color = new Color32(93,157,173,255);
                } else 
                {
                    bulletImages[i].GetComponent<Image>().color = new Color32(136,136,136,136);
                }
            }
        }
        else if (currentBullet == bullets[bullets.Length-1])
        {
            bulletCount = 0;
            currentBullet = bullets[bulletCount];
            for (int i = 0; i < bulletImages.Length; i++)
            {
                if(bulletCount == i)
                {
                    bulletImages[bulletCount].GetComponent<Image>().color = new Color32(93,157,173,255);
                } else 
                {
                    bulletImages[i].GetComponent<Image>().color = new Color32(136,136,136,136);
                }
            }
        }
    }
}
