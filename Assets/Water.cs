using UnityEngine;

public class Water : MonoBehaviour
{
    public AK.Wwise.Event PlayWater;
    public DoorInteraction DoorInteraction;
    private void Start()
    {
        PlayWater.Post(gameObject);
    }
    private void Update()
    {
        if (DoorInteraction.m_PlayDoorOpen)
        {
            PlayWater.Stop(gameObject);
        }
    }
}
