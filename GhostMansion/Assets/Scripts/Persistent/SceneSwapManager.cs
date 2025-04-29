using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{
    public static SceneSwapManager instance;

    private static bool LoadFromRoom;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public static void SwapSceneFromDoorUse(SceneField Scene)
    {
        LoadFromRoom = true;
        instance.StartCoroutine(instance.FadeOutSceneChange(Scene));
        Debug.Log("geht");
    }
    private IEnumerator FadeOutSceneChange(SceneField Scene)
    {
        SceneFadeManager.instance.StartFadeOut();

        while (SceneFadeManager.instance.IsFadingOut)
        {
            yield return null;
        }
        SceneManager.LoadScene(Scene);
    }

    //Wenn Szene geladen wird, dann das hier 
    private void OnSceneLoaded(Scene Scene, LoadSceneMode mode)
    {
        SceneFadeManager.instance.StartFadeIn();

        if(LoadFromRoom)
        {
            //Spieler an richtigen Exit teleportieren
        }
    }
}
