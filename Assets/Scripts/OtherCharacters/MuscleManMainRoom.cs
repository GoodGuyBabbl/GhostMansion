using UnityEngine;

public class MuscleManMainRoom : MonoBehaviour
{
    private SaveStateManager SaveStateManager;

    void Start()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        if(SaveStateManager.GetCurrentStory("HippieStory") == "Over")
        {
            this.gameObject.SetActive(false);
        }
    }


}
