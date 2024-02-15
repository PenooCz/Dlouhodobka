using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currenthealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currenthealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startingHealth);

        if (currenthealth > 0)
        {

        }
        else
        {
            if (!dead)
            {
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");
                GetComponent<Pohyb>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHP(float _value)
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHP(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        GetComponent<Pohyb>().enabled = true;
        foreach (Behaviour component in components)
            component.enabled = true;

    }
    
}
