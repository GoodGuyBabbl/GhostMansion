using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D RigidbodyPlayer;

    private Vector3 LastMoveDirection = Vector3.down;
    private Vector3 IdleDirection;
    private float LastMagnitude = 1f;
    private bool XPositiveLastFrame;
    private bool XPositiveThisFrame;
    private bool YPositiveLastFrame;
    private bool YPositiveThisFrame;
    private bool HasFlipped;

    private bool soundplaying;
    public AK.Wwise.Event PlayGhostMovement;



    void Start()
    {
        
    }


    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("GhostMansionHorizontal"), Input.GetAxis("GhostMansionVertical"), 0.0f);

        if (movement.magnitude == 0)
        {
            soundplaying = false;
            PlayGhostMovement.Stop(gameObject);

        }
        else if (!soundplaying && movement.magnitude != 0)
        {
            soundplaying = true;
            PlayGhostMovement.Post(gameObject);
        }

        float MagnitudeConstraint;
        if(movement.magnitude > 1f)
        {
            MagnitudeConstraint = 1f;
        }
        else
        {
            MagnitudeConstraint = movement.magnitude;
        }

        if (Input.GetAxis("GhostMansionHorizontal") > 0f)
        {
            XPositiveThisFrame = true;
        }
        if (Input.GetAxis("GhostMansionHorizontal") < 0f)
        {
            XPositiveThisFrame = false;
        }
        if (Input.GetAxis("GhostMansionVertical") > 0f)
        {
            YPositiveThisFrame = true;
        }
        if (Input.GetAxis("GhostMansionVertical") < 0f)
        {
            YPositiveThisFrame = false;
        }

        if ((XPositiveLastFrame != XPositiveThisFrame) || (YPositiveLastFrame != YPositiveThisFrame))
        {
            HasFlipped = true;
        }

        if(Input.GetAxis("GhostMansionHorizontal") > 0f)
        {
            XPositiveLastFrame = true; 
        }
        if (Input.GetAxis("GhostMansionHorizontal") < 0f)
        {
            XPositiveLastFrame = false; 
        }
        if (Input.GetAxis("GhostMansionVertical") > 0f)
        {
            YPositiveLastFrame = true;
        }
        if (Input.GetAxis("GhostMansionVertical") < 0f)
        {
            YPositiveLastFrame = false;
        }

        //Debug.Log(movement.magnitude);
        if ((MagnitudeConstraint != 0 && LastMagnitude <= MagnitudeConstraint) || HasFlipped)
        { 
            LastMagnitude = MagnitudeConstraint;
            LastMoveDirection = movement.normalized;
            IdleDirection = LastMoveDirection;
            //Debug.Log(LastMagnitude);
            HasFlipped = false;
        } 
        if (MagnitudeConstraint <= 0f)
        {
            LastMagnitude = 0f;
        }

        //if (MagnitudeConstraint < 0.1f)
        //{
        //    //IdleDirection = LastMoveDirection;
        //}
        //else
        //{
        //    //IdleDirection = LastMoveDirection; 
        //}

        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("XIdleDirection", IdleDirection.x);
        animator.SetFloat("YIdleDirection", IdleDirection.y);
        animator.SetFloat("Magnitude", MagnitudeConstraint);

        // transform.position +=  movement.normalized * Time.deltaTime;
        RigidbodyPlayer.linearVelocity = new Vector2(movement.x, movement.y); //Speed

        
    }
}
