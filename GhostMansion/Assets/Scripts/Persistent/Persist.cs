using UnityEngine;

public class Persist : MonoBehaviour
{
    public static Persist Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad (this.gameObject);    
        }
    }
}
