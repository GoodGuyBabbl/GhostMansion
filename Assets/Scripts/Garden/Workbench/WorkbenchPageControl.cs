using UnityEngine;
using UnityEngine.UI;

public class WorkbenchPageControl : MonoBehaviour
{
    public GameObject NextPage;
    public GameObject PreviousPage;
    public CraftButton FirstActiveButtonNext;
    public CraftButton FirstActiveButtonPrevious;

    private void Update()
    {
        if (Input.GetButtonDown("ToolbarRight"))
        {
            NextPage.SetActive(true);
            if(FirstActiveButtonNext)
            {
                FirstActiveButtonNext.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("ToolbarLeft"))
        {
            PreviousPage.SetActive(true);
            if(FirstActiveButtonPrevious)
            {
                FirstActiveButtonPrevious.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
    }
}
