using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f; // zmienna szybkosci

    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal"); //zmienne odpowiedzialne za poruszanie sie wsad i strzalkami
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //poruszanie sie po x i po z, po y zablokowane,
                                                                            //normalized - szybkosc poruszania sie na ukos poodwaja sie

        if(direction.magnitude>=0.1f){ //jezeli dlugosc wektora jest wieksza lub rowna 0.1 
            controller.Move(direction*speed*Time.deltaTime); //poruszaj sie
        }
    }
}
