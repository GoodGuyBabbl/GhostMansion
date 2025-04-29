using UnityEngine;

public class DoorInteraction : TriggerInteraction
{
    [Header("Go To")]
    [SerializeField] private SceneField _SceneToLoad;
    public override void Interact()
    {
        SceneSwapManager.SwapSceneFromDoorUse(_SceneToLoad);
    }
}
