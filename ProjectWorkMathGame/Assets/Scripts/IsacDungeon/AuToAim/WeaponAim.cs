using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponAim : MonoBehaviour
{
    //links to the objects
    public GameObject firebutton;
    public GameObject pivot;   
    public float RotationSpeed = 100;

    public float checkRadius;
    public LayerMask checkLayers;

    
    void Update()
    {

        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, checkRadius, checkLayers); // array of object colliders(enemies) in setted range (sensing enemies)
        Array.Sort(coliders, new DistanceComparer(transform)); //sorts array elements by distance from nearest

        Vector3 direction = coliders[0].transform.position - transform.position; //-->
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * RotationSpeed); //rotates players weapon towards nearest enemy 
        if (coliders.Length==1)
        {
            firebutton.SetActive(false);
        }
        else 
        {
            firebutton.SetActive(true);
        } // just condition so that player cant attack if there is no enemies in a range
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    } // representation of range 
}
