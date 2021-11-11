using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTrigger : MonoBehaviour
{
    public bool isTrigger;
    public bool isCollider;
    public GameObject theplayer;
    public bool isLeft;
    public bool isRight;
    /*
    void OnTriggerEnter(Collider other) {
        if(isTrigger){
            if(other.gameObject.tag == "Firepoint"){
                if(isLeft){
                    Helper.FlipPlayer(theplayer, true);
                    Debug.Log("isLeft");
                }
                if(isRight){
                    Helper.FlipPlayer(theplayer, false);
                    Debug.Log("isRight");
                }
                Debug.Log("detect");
            }
        }
    }
    */

        private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Firepoint" && isLeft){
            Debug.Log("balllll");
        }
    }
}