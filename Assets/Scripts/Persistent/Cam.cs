using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour
{
    CinemachineConfiner2D CinemachineConfiner;
    void Start()
    {

        Application.targetFrameRate = 120;
        CinemachineConfiner = GetComponent<CinemachineConfiner2D>();
    }
    private void Update()
    {
        if((SceneManager.GetActiveScene().name != "MainMenu"))
        {
            CinemachineConfiner.BoundingShape2D = GameObject.FindGameObjectWithTag("CameraConfiner").GetComponent<Collider2D>();
        }

    }


}
