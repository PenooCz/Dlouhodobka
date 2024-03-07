using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_game : MonoBehaviour
{
    [Header("End")]
    [SerializeField] private GameObject endScreen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hrac")
        {
            endScreen.SetActive(true);
        }
    }
}
