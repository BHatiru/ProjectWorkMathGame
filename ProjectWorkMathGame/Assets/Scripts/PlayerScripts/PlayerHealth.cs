using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Text HealthNumeric;
    public Text EnemyKillStat1;
    public Text EnemyKillStat2;
    public HealthBar healthBar;
    public GameObject Loss;
    public GameObject ChooseAnswer;

    public bool IsCollided=false;
    private int killCount;
    private bool iterated=false;

    void Start()
    {    
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        HealthNumeric.text = maxHealth + "";
    }
    void Update()
    {
        killCount = GetComponent<Shooting>().KillCount;
        EnemyKillStat2.text = "Enemies killed: " + killCount; 
        if (currentHealth == 0)
        {           
            ChooseAnswer.SetActive(false);
            Loss.SetActive(true);
            if (!PlayerPrefs.HasKey("Loses") && iterated==false)
            {
                PlayerPrefs.SetInt("Loses", 1);
                iterated = true;
            }
            else if(PlayerPrefs.HasKey("Loses") && iterated == false)
            {
                PlayerPrefs.SetInt("Loses", PlayerPrefs.GetInt("Loses") + 1);
                iterated = true;
            }
            EnemyKillStat1.text = "Tasks solved: " + killCount;
            Time.timeScale = 0f;
        }//activation of lose state and increasing lose count 
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            IsCollided = true;
            StartCoroutine(TakeDamage(5));                     
        }
    }// taking damage when colliding with enemies
    void OnCollisionExit2D(Collision2D coll)
    {
        IsCollided = false;
        if (coll.gameObject.tag == "Enemy")
        {
            IsCollided = false;
        }
    }
 
    private IEnumerator TakeDamage(int damage)
    {
        while (IsCollided==true)
        {           
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
                HealthNumeric.text = currentHealth + "";
            }
            yield return new WaitForSeconds(0.5f);
        }
    }//method for taking damage(reducing the number of health indicator)
    public void DamageIfWrongAnswer()
    {

        if (currentHealth > 0)
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
            HealthNumeric.text = currentHealth + "";
        }
    }//taking damage if the player answered incorrectly
}
