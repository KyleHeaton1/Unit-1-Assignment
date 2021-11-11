using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [Header("Raycasts or Prefabs")]
    public bool usingRaycasts;
    public bool usingPrefabs;
    [Space(5)]
    [Header("General Assingment")]
    public GameObject firePoint;
    public int damage;
    private int shot;
    public bool canShoot;
    public float delayBetweenShots;
    [Space(5)]
    [Header("Prefab Settings")] 
    public GameObject prefabBullet;
    public int timeToDestroy;
    [Space(5)]
    [Header("Raycasts Settings")]
    public float range = 100f; 
    public TrailRenderer trailEffect;
    void Start() {
        canShoot = true;
    }
    void Update()
    {
        if(shot == 1){
            shot = 0;
        }
        if(usingRaycasts){
        Color hitColor = Color.blue;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetButtonDown("Fire1")){
            if(shot == 0 && canShoot == true){
            RaycastHit hit;
            if(Physics.Raycast(firePoint.transform.position, transform.TransformDirection(Vector3.up), out hit, range)){
                Debug.Log(hit.transform.name);
                var effect = Instantiate(trailEffect, firePoint.transform.position, Quaternion.identity);
                effect.AddPosition(firePoint.transform.position);
                effect.transform.position = hit.point;
                Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(Vector3.up)* 50, hitColor);
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                shot = 1;
                canShoot = false;
                StartCoroutine(ShootDelay());
                if (enemyHealth != null)
                {
                    enemyHealth.takeDamage(damage);
                    Debug.Log("DAMAGE ENEMY");
                }
            }
            }
        }
        }
        if(usingPrefabs){
            if(Input.GetButtonDown("Fire1")){
                if(shot == 0 && canShoot == true){
                var bulletInstance = Instantiate(prefabBullet, firePoint.transform.position, firePoint.transform.rotation);
                Destroy(bulletInstance, timeToDestroy);
                shot = 1;
                canShoot = false;
                Debug.Log("shooting");
                StartCoroutine(ShootDelay());
                }
            }
        }
        IEnumerator ShootDelay(){
            yield return new WaitForSeconds(delayBetweenShots);
            canShoot = true;
        }
    }
    void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));    
        Vector3 newScale = transform.localScale;
        newScale *= 1f;
        transform.localScale = newScale;
    }
}