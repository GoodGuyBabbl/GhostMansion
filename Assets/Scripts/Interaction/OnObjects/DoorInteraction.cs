using UnityEngine;

public class DoorInteraction : TriggerInteraction
{

    public GameObject DoorIcon;
    public AK.Wwise.Event PlayDoorOpen;

    public enum Doors
    {
        None,
        MainRoomPorch,
        MainRoomHippie,
        HippieMainRoom,
        PorchMainRoom,
        GardenPorch,
        PorchGarden,
        MainRoomBasement,
        BasementMainRoom,
        MainRoomMuscleman,
        MusclemanMainRoom

    }


    [Header("Go To")]
    [Space(2f)]
    [SerializeField] private Doors SpawnPlayerToDoor;
    [SerializeField] private SceneField _SceneToLoad;

    public Doors CurrentDoor;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        
        DoorIcon.SetActive(true);
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if(DoorIcon != null)
        {
            DoorIcon.SetActive(false);
        }
        

    }

    public override void Interact()
    {
        PlayDoorOpen.Post(gameObject);
        SceneSwapManager.SwapSceneFromDoorUse(_SceneToLoad, SpawnPlayerToDoor);
        
    }
}
