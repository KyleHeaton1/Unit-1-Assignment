using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public BoxCollider boxCollider;
    public int startingHealth;
    public int currentHealth;
    public GameObject theEnemy;
     public healthBar healthBar;
     public bool isWall;
     public GameObject notBrokeWall, BrokeWall;
     public bool isBoss;

    void Start() {
    currentHealth = startingHealth;
    healthBar.SetMaxHealth(startingHealth);
    boxCollider = GetComponent<BoxCollider>();
    }

    void Update() {
        if(isWall == false){
            healthBar.SetHealth(currentHealth);  
        } 
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        if(isWall){
            notBrokeWall.SetActive(false);
            BrokeWall.SetActive(true);
            boxCollider.enabled = false;
        }else{
            theEnemy.SetActive(false);
        }

        if(isBoss){
            SceneManager.LoadScene("Finish");
        }
    }
}

