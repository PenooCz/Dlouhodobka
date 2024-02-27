using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Pohyb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpColdown;
    private float horizontalInput;


    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Otáèení postavy levá-práva
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2, 2, 2);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 2);

        //Nastavení parametru animamátoru
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());

        //walljump logika
        if (wallJumpColdown > 0.1f)
        {

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;
        }
        else
            wallJumpColdown += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            jump();

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                SoundManager.instance.PlaySound(jumpSound);
        }
           
    }

    private void jump()
    {
        if(IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !IsGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 2, 5);
            wallJumpColdown = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
