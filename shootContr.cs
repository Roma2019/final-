using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shootContr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneys;
    int money = 0;
    public Camera cam;
    public float range = 100f;
    public ParticleSystem partic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 100f, Color.green);
        RaycastHit hit;
        
        if(Input.GetButtonDown("Fire1")){

             partic.Play();
             if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100)){
                if(hit.transform.gameObject.tag=="animal"){
                     Destroy(hit.transform.gameObject);
                     money = money + 500;
                     moneys.text = money + "";
                     FindObjectOfType<MoneyBar>().decreaseValue(money);
                }
               
             }     

        }
    }
}
