using UnityEngine;

public class OreVein : MonoBehaviour
{
    private UniqueID UniqueID;
    private SaveStateManager SaveStateManager;
    private void Awake()
    {

        UniqueID = GetComponent<UniqueID>();
    }
    void Start()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        if (SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            this.gameObject.GetComponent<PermanentResource>().enabled = true;
        }
    }


}
