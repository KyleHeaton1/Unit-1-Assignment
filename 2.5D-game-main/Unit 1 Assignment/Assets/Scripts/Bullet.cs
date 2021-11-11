using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public bool isEnemyBullet;
    void Update()
    {
        if(isEnemyBullet){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }else{
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
    }
    void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
        if(other.collider.tag == "Ground"){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Ground")){
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "thePlayer"){
            if(isEnemyBullet){
                other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
                Destroy(gameObject);
            }
        }
    }
}