using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MniGame : MonoBehaviour
{
    [SerializeField] Sprite [] whiteIcons, greenIcons, blackIcons;
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
            int color = Random.Range(-1,3);
            
            if (color < 0)
            { 
                color = 0;
            }

            if (color > 2)
            { 
                color = 2;
            }
             
            if (1 == colors[color]){
                Color imgColor = new Color32(255,255,255,1); //White Bin
                Sprite imgSprite = whiteIcons[Random.Range(0,whiteIcons.Length-1)];
                item.GetChild(0).gameObject.GetComponent<Image>().sprite = imgSprite;
                //item.gameObject.GetComponent<Image>().sprite = imgSprite;
                item.gameObject.GetComponent<Image>().color = imgColor;
            }else
            if (2 == colors[color]){
                Color imgColor = new Color32(0,212,0,1);  //Green Bin
                Sprite imgSprite = greenIcons[Random.Range(0,greenIcons.Length-1)];
                item.GetChild(0).gameObject.GetComponent<Image>().sprite = imgSprite;
                //item.gameObject.GetComponent<Image>().sprite = imgSprite;
                item.gameObject.GetComponent<Image>().color = imgColor;
            }else
            if (3 == colors[color]){
                Color imgColor = new Color32(0,0,0,1);    //Black Bin
                Sprite imgSprite = blackIcons[Random.Range(0,blackIcons.Length-1)];
                item.GetChild(0).gameObject.GetComponent<Image>().sprite = imgSprite;
                //item.gameObject.GetComponent<Image>().sprite = imgSprite;
                item.gameObject.GetComponent<Image>().color = imgColor;
            }
            else {
                print(colors[color]);
            }               
        }
    }
    public void MoveItems(){
        if (itemcount < maxItemcount) {
            itemcount++;
            RectTransform itemBoxRect= itemsBox.GetComponent<RectTransform>(); 
            itemBoxRect.localPosition = new Vector3(itemBoxRect.localPosition.x - 200, itemBoxRect.localPosition.y, itemBoxRect.localPosition.z);
        }else {
            itemcount = 0;
        }
    }

}
