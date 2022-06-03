using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    Transform playerBody;
    int hp = 100;
    
    public float speed = 12f;
    float graValue = -9.81f;
    CharacterController character;
    // Start is called before the first frame update
    void timeHeal(){
        hp= hp + 1;
        FindObjectOfType<HealthBar>().decreaseValue(hp);
    }

    void Start()
    {
        character = GetComponent<CharacterController>();
        playerBody = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        character.Move(transform.forward * vertical * speed * Time.deltaTime);
        character.Move(transform.right * horizontal * speed * Time.deltaTime);
        character.Move(playerBody.up * graValue * Time.deltaTime);
        if(hp<100){
            InvokeRepeating("timeHeal", 1f, 1f);
        } else {
            CancelInvoke();
        }
        
    }
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "animal"){
                hp = hp - 5;
                FindObjectOfType<HealthBar>().decreaseValue(hp);
            }
    }
}
