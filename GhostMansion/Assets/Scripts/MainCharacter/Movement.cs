using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        transform.position +=  movement * Time.deltaTime;
    }
}
