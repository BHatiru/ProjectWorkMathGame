using UnityEngine;
using System;

public class Sence : MonoBehaviour
{
    public float checkRadius;
    public LayerMask checkLayers;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, checkRadius, checkLayers);
            Array.Sort(coliders, new DistanceComparer(transform));

            foreach(Collider2D item in coliders)
            {
                Debug.Log(item.name);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}//NOT USED
