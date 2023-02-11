using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBagFix : MonoBehaviour
{
    public float distance;
    public float rotationSpeed;
    public GameObject firebutton;
   
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        RaycastHit2D hitInfo1 = Physics2D.Raycast(transform.position, transform.right, distance);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, -transform.right, distance);
        /*RaycastHit2D hitInfo3 = Physics2D.Raycast(transform.position, -transform.right, distance);
       RaycastHit2D hitInfo4 = Physics2D.Raycast(transform.position, -transform.up, distance);*/       
        Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
        if (hitInfo1.collider.CompareTag("Enemy") || hitInfo2.collider.CompareTag("Enemy") /*|| hitInfo3.collider.CompareTag("Enemy") || hitInfo4.collider.CompareTag("Enemy")*/)
        {
            firebutton.SetActive(true);
            Debug.DrawLine(transform.position, hitInfo1.point, Color.red);
            Debug.DrawLine(transform.position, hitInfo2.point, Color.red);

            /* 
             Debug.DrawLine(transform.position, hitInfo3.point, Color.red);
             Debug.DrawLine(transform.position, hitInfo4.point, Color.red); */
        }
        StartCoroutine(falsing());

    }
    IEnumerator falsing()
    {
        yield return new WaitForSeconds(3f);
        firebutton.SetActive(false);
    }


}/*fix designed to solve the problem when auto-aiming worked through walls.
Not used because it causes a different problem and breaks the auto aim system*/
