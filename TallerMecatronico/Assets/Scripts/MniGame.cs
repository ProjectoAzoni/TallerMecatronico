using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MniGame : MonoBehaviour
{
    [SerializeField] public GameObject itemsBox, itemSelecPoint;
    [SerializeField] Slider slider;
    [SerializeField] Transform shootPoint, shootOrigin, azoni;
    [SerializeField] float fireRate = 0.5F, nextFire = 0f;
    [SerializeField] LayerMask layer;
    [SerializeField] Rigidbody bulletPrefab;
    [SerializeField] LineRenderer linevisual;
    [SerializeField] Button shootButton;
    [SerializeField] int lineSegment = 2;
    private Vector3 Vo0;

    Transform firstItem;
    [HideInInspector] public int itemcount = 0, maxItemcount;
    int [] colors = {1,2,3};

    [HideInInspector] public bool shooted = false;
    // Start is called before the first frame update
    void Start()
    {
        maxItemcount = itemsBox.transform.childCount;
        firstItem = itemsBox.gameObject.transform.GetChild(itemcount);
        ItemsBoxColor();
        //InvokeRepeating("launchProyectile", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        launchProyectile();
    }

    void launchProyectile()
    {
        shootPoint.position = new Vector3(15.4f, slider.value, 0);
        Ray camRAy = new Ray( shootOrigin.position, new Vector3(shootPoint.position.x, shootPoint.position.y - 16, shootPoint.position.z));
        RaycastHit hit;
        Debug.DrawRay(shootOrigin.position, new Vector3(shootPoint.position.x,shootPoint.position.y - 16 , shootPoint.position.z),Color.green);
        if (Physics.Raycast(camRAy,out hit,150f,layer)) {
            //print(hit.collider.tag);
            Vector3 Vo = CalculateVelocity(hit.point, shootOrigin.position, 1f);
            visualize(Vo);
            Vo0 = Vo;
            azoni.rotation = Quaternion.LookRotation(Vo);
        }
    }

    Vector3 calcPosTime(Vector3 Vo, float time)
    {
        Vector3 Vxz = Vo;
        Vxz.y = 0f;

        Vector3 result = shootOrigin.position + Vo * time;

        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (Vo.y * time) + shootOrigin.position.y;
        result.y = sY;

        return result;
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
    void visualize(Vector3 Vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = calcPosTime(Vo, i / (float)lineSegment);
            linevisual.SetPosition(i, pos);
        }
    }

    public void shootProjectil() {
        if (shooted && Time.time > nextFire){
            Rigidbody obj = Instantiate(bulletPrefab, shootOrigin.position, Quaternion.identity);    
            obj.velocity = Vo0;
            //MoveItems();
            nextFire = Time.time+fireRate;
            shooted = false;

        }
        shooted = true;
    }
    
    public void ItemsBoxColor()
    {
        foreach(Transform item in itemsBox.transform){
            if (1 == colors[Random.Range(1,colors.Length)]){
                Color imgColor = new Color32(255,255,255,255);
                item.gameObject.GetComponent<Image>().color = imgColor;
            }else
            if (2 == colors[Random.Range(1,colors.Length)]){
                Color imgColor = new Color32(0,212,0,255);
                item.gameObject.GetComponent<Image>().color = imgColor;
            }else
            if (3 == colors[Random.Range(1,colors.Length)]){
                Color imgColor = new Color32(0,0,0,255);
                item.gameObject.GetComponent<Image>().color = imgColor;
            }               
        }
    }
    public void MoveItems(){
        if (itemcount < maxItemcount) {
            itemcount++;
            itemsBox.transform.position = new Vector3 (itemsBox.transform.position.x - itemSelecPoint.transform.position.x - 40,itemsBox.transform.position.y,itemsBox.transform.position.z);
        }else {
            itemcount = 0;
        }
    }

}
