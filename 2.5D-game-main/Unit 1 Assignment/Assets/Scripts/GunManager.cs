using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public gun gunScript;
    public gun lazergunScript;
    public gun fastgunScript;
    void Start() {
        gun1.SetActive(true);
        gunScript = gun1.GetComponent<gun>();
        lazergunScript = gun2.GetComponent<gun>();
        fastgunScript = gun3.GetComponent<gun>();
        // gunScript = gun2.GetComponent<gun>();
        // gunScript = gun3.GetComponent<gun>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            gun1.SetActive(true);    
            gun2.SetActive(false);   
            gun3.SetActive(false);
            gunScript.canShoot = true;
            lazergunScript.canShoot = true;
            fastgunScript.canShoot = true;
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            gun1.SetActive(false);    
            gun2.SetActive(true);   
            gun3.SetActive(false); 
            gunScript.canShoot = true;
            lazergunScript.canShoot = true;
            fastgunScript.canShoot = true;
        }
        if(Input.GetKey(KeyCode.Alpha3)){
            gun1.SetActive(false);    
            gun2.SetActive(false);   
            gun3.SetActive(true); 
            gunScript.canShoot = true;
            lazergunScript.canShoot = true;
            fastgunScript.canShoot = true;
        }
    }
}
