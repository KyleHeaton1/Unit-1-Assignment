using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject part;
    public float force;
    public float radius;
    private float upforce;
    private float RandNum;
    void Start() {
    rb = GetComponent<Rigidbody>();    
    }
    void Awake() {
    Vector3 explosionPos = part.transform.position;
    rb.AddExplosionForce(force, explosionPos, radius, upforce, ForceMode.Impulse);
    RandNum = Random.Range(2.5f,7.5f);
    Destroy();
    }

    void Destroy(){
        Destroy(part, RandNum);
    }
}
