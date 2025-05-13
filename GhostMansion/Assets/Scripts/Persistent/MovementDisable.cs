using UnityEngine;

public class MovementDisable : MonoBehaviour
{
    private GameObject Player;
    private Movement Movement;

    private void Start()
    {
        Movement = FindFirstObjectByType<Movement>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Movement = Player.GetComponent<Movement>();
    }
    public void DisableMovement()
    {
        Movement.enabled = false;
    }
    public void EnableMovement()
    {
        Movement.enabled = true;
    }
}
