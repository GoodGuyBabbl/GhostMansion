using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    private Vector3 LastMoveDirection = Vector3.down;
    private Vector3 IdleDirection;
    private float LastMagnitude = 1f;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("GhostMansionHorizontal"), Input.GetAxis("GhostMansionVertical"), 0.0f);


        
        if (movement.magnitude > 0.01f && LastMagnitude <= movement.magnitude)
        {
            LastMagnitude = movement.magnitude;
            LastMoveDirection = movement;
        } 
        if (movement.magnitude <= 0.01f)
        {
            LastMagnitude = 0f;
        }

        if (movement.magnitude > 0.1f)
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

        transform.position +=  movement.normalized * Time.deltaTime;
    }
}
