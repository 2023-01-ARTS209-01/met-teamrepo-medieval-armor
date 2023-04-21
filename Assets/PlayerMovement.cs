using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioClip walkingSound;

    private AudioSource audioSource;
    [SerializeField] AudioSource[] footsteps;
    private bool isWalking;

    Vector2 movement;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.magnitude > 0 && !isWalking)
        {
            audioSource.clip = walkingSound;
            audioSource.loop = true;
            audioSource.Play();
            isWalking = true;
        }
        else if (movement.magnitude == 0)
        {
            audioSource.Stop();
            isWalking = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
