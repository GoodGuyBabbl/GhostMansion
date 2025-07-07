using TMPro.Examples;
using UnityEngine;

public class RoomSwitchTrigger : MonoBehaviour
{
    public AK.Wwise.Switch roomSwitch; 
    public AK.Wwise.Event ambienceEvent;
    public DoorInteraction DoorInteraction;
    public DoorInteraction DoorInteraction1;
    public DoorInteraction DoorInteraction2;
    public DoorInteraction DoorInteraction3;
    private bool trigger = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (trigger == false)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Tigger Enter");
                roomSwitch.SetValue(gameObject); // Setzt den Switch
                ambienceEvent.Post(gameObject);  // Spielt den Sound ab
                Debug.Log("Play Sound");
                trigger = true;
            }
        }
       
    }
    private void Update()
    {
        Debug.Log("Tigger Exit");
        if (DoorInteraction.m_PlayDoorOpen || DoorInteraction1.m_PlayDoorOpen || DoorInteraction2.m_PlayDoorOpen || DoorInteraction3.m_PlayDoorOpen)
        {
            roomSwitch.SetValue(gameObject); // Setzt den Switch
            ambienceEvent.Stop(gameObject);  // Stopt den Sound ab
            Debug.Log("Stop Sound");
            trigger = false;
        }
    }
    
}
