using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour{
    public float speed = 2f; //predkosc chodzenia do ustawienia w inspektorze
    public Transform[] spots; //tablica waypointów w których enemy chodzi od jednego do drugiego
    private int spotIndex; //index waypointu od ktorego enemy idzie   
    public PlayerMovement player; //bedziemy korzystac z innego pliku cs
    private float dist;
    
    void Start(){        
        spotIndex=0;
        transform.LookAt(spots[spotIndex].position); //ustaw pozycje enemy na pozycji 1. waypointu
        player = FindObjectOfType<PlayerMovement> ();
    } 
       
    void Update(){        
       dist = Vector3.Distance(transform.position, spots[spotIndex].position); //liczenie dystansu miedzy postaci a waypointem
       
       if(dist < 0.1f){ //jesli odleglasc jest mniejsza nmiz 0.1, dodaj waypoint
           AddIndex();
       }
       Move();
    }

   void Move(){
       transform.Translate(Vector3.forward * speed * Time.deltaTime); //poruszanie sie
   }

   void AddIndex(){ //dodawanie indexu
       spotIndex++;
       if(spotIndex ==spots.Length){ //jesli dojdzie do ostatniego indexu 
           spotIndex=0; //wroc do indexu 0
       }
       transform.LookAt(spots[spotIndex].position);   //zwroc sie do punktow
    }  

    void OnTriggerEnter(Collider col){ // jesli trigger jest aktywowany
        if(col.name == "Player"){ // jesli colizja jest z Playerem
            player.energy (-1); // wywolaj funkcje dodajaca energie z wartoscia -1 (odejmuje)
        }
    }
}
