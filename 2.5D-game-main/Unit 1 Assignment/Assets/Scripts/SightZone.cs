using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightZone : MonoBehaviour
{
    public bool IsSight;
    public Enemy enemy;
    public GameObject theEnemy;
    void Start()
    {
        enemy = theEnemy.GetComponent<Enemy>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "thePlayer"){
           if(IsSight){
            Debug.Log("InSight");
            enemy.inSight = true;
            enemy.isWalking = false;
           }else{
               Debug.Log("ATTACK");
                enemy.inAttack = true;
                enemy.isWalking = false;
           }
           if(enemy.inAttack == true){
               Debug.Log("sex");
           }
        }
    }

        private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "thePlayer"){
            if(IsSight){
            Debug.Log("Still in sight");
            enemy.inSight = true;
            }else{
                Debug.Log("IS ATTACKING");
                enemy.inAttack = true;
            }
 
        }
    }

        private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "thePlayer"){
            if(IsSight){
            Debug.Log("Left SIGHT");
            enemy.inSight = false;
            enemy.isWalking = true;
            }else{
                Debug.Log("stop attacking");
                enemy.inAttack = false;
                enemy.isWalking = true;
            }
        }
    }
}
