using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject fireButton;
    public GameObject ChooseAnswer;

    public float bullerForce = 20f;

    public int KillCount;

    private void Update()
    {
        
    }
    public void Shoot()
    {
        KillCount++; // to count number of solved tasks, therefore, enemies killed
        ChooseAnswer.SetActive(false); // activates the panel with the task
        Time.timeScale = 1f;
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); //creates bullet object at "firepont"(tip of weapon)
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.right * bullerForce, ForceMode2D.Impulse); //fires a bullet with the specified force
    }
}
