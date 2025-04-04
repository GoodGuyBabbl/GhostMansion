using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    private Vector3 LastMoveDirection = Vector3.down;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);


        if(movement.magnitude > 0.0f)
        {
            LastMoveDirection = movement;
        }


        Vector3 IdleDirection;

        if (movement.magnitude > 0.0f)
        {
            IdleDirection = movement;
        }
        else
        {
            IdleDirection = LastMoveDirection;
        }


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("XIdleDirection", IdleDirection.x);
        animator.SetFloat("YIdleDirection", IdleDirection.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position +=  movement * Time.deltaTime;
    }
}
