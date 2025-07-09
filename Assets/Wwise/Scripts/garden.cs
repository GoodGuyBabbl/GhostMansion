using UnityEngine;

public class garden : MonoBehaviour
{
    public AK.Wwise.Event PlayFrogJump;

    public AK.Wwise.Event PlayFrog;
    public DoorInteraction DoorInteraction;

    private void Start()
    {
        PlayFrog.Post(gameObject);
    }
    public void frogjump()
    {
        PlayFrogJump.Post(gameObject);
    }
    private void Update()
    {
        if (DoorInteraction.m_PlayDoorOpen )
        {
            PlayFrogJump.Stop(gameObject);
            PlayFrog.Stop(gameObject);
        }
    }
}
