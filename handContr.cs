using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handContr : MonoBehaviour
{
    public Camera cam;
    GameObject PressE;
    GameObject PressQ;
    GameObject hand;
    GameObject gun;
    Transform handTr;
    Transform gunTr;
    // Start is called before the first frame update
    void Start()
    {
        PressE = GameObject.Find("PressE");
        PressE.SetActive(false);

        PressQ = GameObject.Find("PressQ");
        PressQ.SetActive(false);

        hand = GameObject.Find("hand");
        gun= GameObject.Find("gun");

        handTr = hand.GetComponent<Transform>();
        gunTr = gun.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 4f, Color.red);
        RaycastHit touch;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out touch, 4)){
            if(touch.transform.gameObject.tag=="gun"){
                PressE.SetActive(true);
                if(Input.GetKeyDown("e")){
                    if(gun.GetComponent<Rigidbody>()){
                        Destroy(gun.GetComponent<Rigidbody>());
                    }
                    gunTr.position = handTr.position;
                    gunTr.rotation = handTr.rotation;
                    gunTr.SetParent(handTr);
                }              
            } else {
                PressE.SetActive(false);
            }

            if(touch.transform.gameObject.tag=="door"){
                PressQ.SetActive(true);
                if(Input.GetKeyDown("q")){
                    SceneManager.LoadScene("Game1");
                }              
            } else {
                PressQ.SetActive(false);
            }
        } 
        
        if(Input.GetKeyUp("f")){
            gunTr.parent = null;
            gun.AddComponent<Rigidbody>();
            gun.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 100f);
        }
    }
}
