using UnityEngine;

public class DoorInteraction : TriggerInteraction
{

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


    public override void Interact()
    {
        SceneSwapManager.SwapSceneFromDoorUse(_SceneToLoad, SpawnPlayerToDoor);
    }
}
