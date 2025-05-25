using System.Security.Cryptography;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Toolbar;
    public GameObject Toolbox;
    public void DisableToolbar()
    {
        Toolbar.SetActive(false);
        Toolbox.SetActive(false);
    }
    public void EnableToolbar()
    {
        Toolbar.SetActive(true);
        Toolbox.SetActive(true);    
    }


}
