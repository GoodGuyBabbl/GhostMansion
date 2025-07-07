using UnityEngine;
using UnityEngine.UI;

public class WorkbenchPageControl : MonoBehaviour
{
    public GameObject NextPage;
    public GameObject PreviousPage;
    public GameObject NextTab;
    public GameObject PreviousTab;
    public CraftButton FirstActiveButtonNext;
    public CraftButton FirstActiveButtonPrevious;
    public CraftButton FirstActiveButtonNextTab;
    public CraftButton FirstActiveButtonPreviousTab;

    public AK.Wwise.Event PlayButton;
    public AK.Wwise.Event PlayClick;

    private void Update()
    {


        //Pages

        if (Input.GetButtonDown("ToolbarRight") && NextPage)
        {
            NextPage.SetActive(true);
            if(FirstActiveButtonNext)
            {
                FirstActiveButtonNext.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("ToolbarLeft") && NextPage)
        {
            PreviousPage.SetActive(true);
            if(FirstActiveButtonPrevious)
            {
                FirstActiveButtonPrevious.SelectButton();
            }
            this.gameObject.SetActive(false);
        }


        //Tabs

        if (Input.GetButtonDown("WorkbenchTabRight"))
        {
            NextTab.SetActive(true);
            if (FirstActiveButtonNextTab)
            {
                FirstActiveButtonNextTab.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("WorkbenchTabLeft"))
        {
            PreviousTab.SetActive(true);
            if (FirstActiveButtonPreviousTab)
            {
                FirstActiveButtonPreviousTab.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
    }
}
