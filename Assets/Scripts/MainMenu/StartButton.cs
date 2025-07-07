using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    [SerializeField] private Button Button;
    public EventSystem ESys;
    public Transform menuCamTarget;
    public CinemachineCamera CinemachineCam;
    public CinemachineConfiner2D CinemachineConfiner2D;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject CamHeader;

    public AK.Wwise.Event PlayClick;
    public AK.Wwise.Event PlayButton;

    private void Awake()
    {
        CinemachineCam.Follow = menuCamTarget;
        //CinemachineCam.LookAt = menuCamTarget;
        Renderer = GetComponent<Image>();

    }
    public void OnEnable()
    {
        Button.Select();
    }
    public void OnSelect(BaseEventData eventData)
    {
        PlayButton.Post(gameObject);
        Renderer.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Renderer.enabled = false;
    }

    public void OnClick()
    {
        PlayClick.Post(gameObject);
        if (Renderer.enabled)
        {
            ESys.enabled = false;

            var persistObj = Instantiate(Resources.Load("Persist")) as GameObject;
            DontDestroyOnLoad(persistObj);
            DontDestroyOnLoad(Cam1);
            DontDestroyOnLoad(Cam2);
            DontDestroyOnLoad(CamHeader);
            SceneManager.LoadScene("MainRoom");
            CinemachineCam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
            

        }
    }

    public void SelectButton()
    {
        Button.Select();
    }
}
