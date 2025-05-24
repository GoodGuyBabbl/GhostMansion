using UnityEngine;

public class DoorInteraction : TriggerInteraction
{

    public GameObject DoorIcon;


    public enum Doors
    {
        None,
        MainRoomGarden,
        MainRoomHippie,

        HippieMainRoom,

        GardenMainRoom,

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
        SceneSwapManager.SwapSceneFromDoorUse(_SceneToLoad, SpawnPlayerToDoor);
    }
}
