using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorWalk : MonoBehaviour
{
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if(vertical > 0)  //up
        {
            animator.SetInteger("direction", 2);
        } else if (vertical < 0)  //down
        {
            animator.SetInteger("direction", 0);
        } else if (horizontal > 0)
        {
            animator.SetInteger("direction", 3);
        } else if (horizontal < 0)
        {
            animator.SetInteger("direction", 1);
        }

        
    }
}
