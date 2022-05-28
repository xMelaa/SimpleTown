using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public GameObject coin;
    float speed = 70.0f;

    void Update(){
        coin.transform.Rotate(Vector3.up*speed*Time.deltaTime);
    }
}
