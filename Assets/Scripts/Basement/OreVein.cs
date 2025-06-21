using UnityEngine;

public class OreVein : MonoBehaviour
{
    private UniqueID UniqueID;
    private SaveStateManager SaveStateManager;
    private void Awake()
    {
        SaveStateManager = GetComponent<SaveStateManager>();
        UniqueID = GetComponent<UniqueID>();
    }
    void Start()
    {
        if(SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            this.gameObject.GetComponent<PermanentResource>().enabled = true;
        }
    }


}
