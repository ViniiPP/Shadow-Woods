using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    Dino playerScript;
    Rigidbody2D rb;
    public GroundedCheck groundedCheck;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerScript = GetComponent<Dino>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        /*if (!groundedCheck.IsGrounded() && rb.linearVelocity.y > 0.1f)
        {
           animator.SetTrigger("Jump");
        }*/
        Debug.Log("Y Velocity: " + rb.linearVelocity.y);
        Debug.Log("Is Grounded: " + groundedCheck.IsGrounded());
        animator.SetBool("isGrounded", groundedCheck.IsGrounded());
        animator.SetFloat("yVelocity", rb.linearVelocity.y);


    }


}
