using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_respawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private HP playerhealth;
    private UIManager uiManager;


    private void Awake()
    {
        playerhealth = GetComponent<HP>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        if(currentCheckpoint == null)
        {
            uiManager.GameOver();

            return;
        }


        playerhealth.Respawn();
        transform.position = currentCheckpoint.position;

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("save");
        }
       
    }
}
