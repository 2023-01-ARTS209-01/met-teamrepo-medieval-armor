using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    //public AudioClip walkingSound;

    //private AudioSource audioSource;
    //[SerializeField] AudioSource[] footsteps;
    private bool idle = true;
    private int facing = 0;

    Vector2 movement;

    void Start() {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x > 0) {
            facing = 0;  //facing right
        } else if(movement.x < 0) {
            facing = 1; //facing left
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetInteger("facing", facing);

        if (movement.magnitude > 0 && !idle) {
            //audioSource.clip = walkingSound;
            //audioSource.loop = true;
            //audioSource.Play();
            idle = false;
        }
        else if (movement.magnitude == 0) {
            //audioSource.Stop();
            idle = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
