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

     
        animator.SetBool("isDead", playerScript.isFreeze);
      
        
        animator.SetBool("isGrounded", groundedCheck.IsGrounded());
        animator.SetFloat("yVelocity", rb.linearVelocity.y);


    }


}
