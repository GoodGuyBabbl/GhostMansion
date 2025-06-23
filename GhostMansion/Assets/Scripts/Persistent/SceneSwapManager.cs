using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{
    public static SceneSwapManager instance;
    public CinemachineConfiner2D CinemachineConfiner2D;
    public Camera Cam;

    private GameObject Player;
    private Collider2D PlayerCollider;
    private Collider2D DoorCollider;
    private Vector3 PlayerSpawnPosition;

    

    private static bool LoadFromRoom;

    private DoorInteraction.Doors DoorToTeleportTo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //Spieler finden, um die Position festlegen zu können, wohin er bei Nutzung der Tür teleportiert werden muss
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = Player.GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public static void SwapSceneFromDoorUse(SceneField Scene,DoorInteraction.Doors DoorToSpawnAt)
    {
        LoadFromRoom = true;
        instance.StartCoroutine(instance.FadeOutSceneChange(Scene, DoorToSpawnAt));
        Debug.Log("geht");
    }
    private IEnumerator FadeOutSceneChange(SceneField Scene, DoorInteraction.Doors DoorToSpawnAt = DoorInteraction.Doors.None)
    {
        SceneFadeManager.instance.StartFadeOut();

        while (SceneFadeManager.instance.IsFadingOut)
        {
            yield return null;
        }
        DoorToTeleportTo = DoorToSpawnAt;
        SceneManager.LoadScene(Scene);
    }

    //Wenn Szene geladen wird, dann das hier 
    private void OnSceneLoaded(Scene Scene, LoadSceneMode mode)
    {
        Cam.transform.position = new Vector3(0, 0, -5);
        CinemachineConfiner2D.BoundingShape2D = GameObject.FindGameObjectWithTag("CameraConfiner").GetComponent<Collider2D>();
        SceneFadeManager.instance.StartFadeIn();

        if(LoadFromRoom)
        {
            //Spieler an richtigen Exit teleportieren
            FindDoor(DoorToTeleportTo);
            Player.transform.position = PlayerSpawnPosition;
            LoadFromRoom = false;
        }
    }

    private void FindDoor(DoorInteraction.Doors DoorToSpawnAt )
    {
        DoorInteraction[] AllDoors = FindObjectsOfType<DoorInteraction>();

        for (int i = 0; i < AllDoors.Length; i++)
        {
            if (AllDoors[i].CurrentDoor == DoorToSpawnAt)
            {
                DoorCollider = AllDoors[i].gameObject.GetComponent<BoxCollider2D>();

                //Spieler an die Stelle des Türcolliders teleportieren
                CalculateTeleportPosition();
                return;
            }
        }
    }

    private void CalculateTeleportPosition()
    {
        PlayerSpawnPosition = DoorCollider.transform.position;
    }
}
