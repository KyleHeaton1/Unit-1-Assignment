using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float waitTime;
    [Header("Random Position Assignment")]
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot, shot;
    private float oldPosition = 0.0f;
    [Space(5)]
    [Header("Enemy Mechanics")]
    public Animator anim;
    public GameObject model;
    public Transform thePlayer;
    public Rigidbody myRB;
    public float moveSpeed;
    [Space(5)]
    private bool canChase, canShoot;
    [Header("Attacking and Chasing")]
    public float delayBetweenShots;
    public float timeToDestroy;
    public GameObject firePoint, enemyBulletPrefab;
    [Space(10)]
    [Header("BOOLEAN")]
    public bool inSight, inAttack, isWalking;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        anim = model.GetComponent<Animator>();
        inSight = false;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        isWalking = true;
        oldPosition = transform.position.x;
        canChase = true;
        canShoot = true;
    }
    void Update()
    {
        if(shot == 1){
            shot = 0;
        }
        if(inAttack == true){
            canChase = false;
        }else{
            canChase = true;
        }
        if(isWalking){
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed* Time.deltaTime);
        anim.SetBool("isWalking", true);
        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position)<0.2){
            if(waitTime<=0){
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                anim.SetBool("isWalking", true);
            }else{
                waitTime -= Time.deltaTime;
                anim.SetBool("isWalking", false);
            }
        }
        if(transform.position.x > oldPosition){
            transform.localRotation = Quaternion.Euler(0,90,0);
        }
        if(transform.position.x < oldPosition){
            transform.localRotation = Quaternion.Euler(0,270,0);
        }
        oldPosition = transform.position.x;
        }
        if (inSight && canChase)
        {
            chasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
        if(inAttack){
            AttackPlayer();
        }
        else{
            inAttack = false;
            anim.SetBool("isShooting", false);
        }
    }
    private void chasePlayer()
    {
        if (transform.position.x < thePlayer.position.x && canChase){
            myRB.velocity = new Vector3(moveSpeed, 0);
        }
        else if(canChase){
            myRB.velocity = new Vector3(-moveSpeed, 0);
        }
        anim.SetBool("isWalking", true);
    }
    private void StopChasePlayer(){
        myRB.velocity = Vector3.zero;
    }
    private void AttackPlayer(){
        canChase = false;
        if(canShoot && shot == 0){
            var bulletInstance = Instantiate(enemyBulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            Destroy(bulletInstance, timeToDestroy);
            shot = 1;
            canShoot = false;
            StartCoroutine((ShootDelay()));
        }
        anim.SetBool("isWalking", false);
        anim.SetBool("isShooting", true);
    }   
    IEnumerator ShootDelay(){
    yield return new WaitForSeconds(delayBetweenShots);
    canShoot = true;
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            canChase = true;
        }
    }
    void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "ground"){
            canChase = false;
        }    
    }
}