using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam; //zmiana kamery
    public Rigidbody rb;
    public bool isGround = true;

    private Vector3 playerVelocity;
    
    private float jumpHeight = 1.0f;
    private float gravityValue = -20f;

    public float speed = 5f; // zmienna szybkosci
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start(){       
       controller = GetComponent<CharacterController>();
    }

    void Update(){
        
        if (isGround && playerVelocity.y < 0){
            playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal"); //zmienne odpowiedzialne za poruszanie sie wsad i strzalkami
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //poruszanie sie po x i po z, po y zablokowane,
                                                                            //normalized - szybkosc poruszania sie na ukos poodwaja sie

        if(direction.magnitude>=0.1f){ //jezeli dlugosc wektora jest wieksza lub rowna 0.1 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //gladkie przechodzenie

            transform.rotation = Quaternion.Euler(0f, angle, 0f); //obrot gracza w te strone, w ktora idzie

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized *speed*Time.deltaTime); //poruszaj się
        }        

        if (Input.GetButtonDown("Jump") && isGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            isGround = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ground") {
            isGround = true;
        }
    }
}
