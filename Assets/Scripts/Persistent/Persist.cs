using UnityEngine;

public class Persist : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Execute()
    {
        Debug.Log("Persist Script on Persist Prefab in AlwaysActive Folder");
        Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Persist")));
    }
}

//public static Persist Instance;

//private void Awake()
//{
//    if (Instance == null)
//    {
//        Instance = this;
//        DontDestroyOnLoad(this.gameObject);
//    }
//    else
//    {
//        DontDestroyOnLoad(this.gameObject);
//    }
//}
