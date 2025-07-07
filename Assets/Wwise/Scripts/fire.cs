using UnityEngine;

public class fire : MonoBehaviour
{
    public AK.Wwise.Event PlayFire;
    public DoorInteraction DoorInteraction;
    public DoorInteraction DoorInteraction1;
    public DoorInteraction DoorInteraction2;
    public DoorInteraction DoorInteraction3;
    private void Start()
    {
        PlayFire.Post(gameObject);
    }

    private void Update()
    {
        if (DoorInteraction.m_PlayDoorOpen || DoorInteraction1.m_PlayDoorOpen || DoorInteraction2.m_PlayDoorOpen || DoorInteraction3.m_PlayDoorOpen)
        {
            PlayFire.Stop(gameObject);
        }
        
    }

}
