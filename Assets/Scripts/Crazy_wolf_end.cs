using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crazy_wolf_end : MonoBehaviour
{
    [Header("Crazy_wolf_end")]
    [SerializeField] private GameObject CrazyWolfScreen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hrac")
        {
            CrazyWolfScreen.SetActive(true);
            HP hp = FindObjectOfType<HP>();
            hp.HideDeathCounter();
        }
    }
}
