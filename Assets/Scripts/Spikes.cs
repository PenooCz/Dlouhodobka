using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapy : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "hrac")
        {
            collision.GetComponent<HP>().TakeDamage(damage);
        }
    }
}
