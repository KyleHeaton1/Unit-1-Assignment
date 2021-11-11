using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [Header("Stats")]
    [Space(5)]
    public int startingHealth;
    public int currentHealth;
    [Space(10)]
    [Header("GameObjects")]
    [Space(5)]
    public GameObject thePlayer;
    public healthBar healthBar;
    public bool dead;
    public Scene mainScene;
    public float timeAfterDeath = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            thePlayer.SetActive(false);
            Invoke("sceneLoad", timeAfterDeath);
        }
        healthBar.SetHealth(currentHealth);
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
    }
    void sceneLoad(){
        SceneManager.LoadScene("SampleScene");
    }
}
