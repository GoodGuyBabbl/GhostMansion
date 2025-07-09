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

    public AK.Wwise.Event PlayConstructionPlanOpen;

    private void Update()
    {


        //Pages

        if (Input.GetButtonDown("ToolbarRight") && NextPage)
        {
            PlayConstructionPlanOpen.Post(gameObject);
            NextPage.SetActive(true);
            if(FirstActiveButtonNext)
            {
                FirstActiveButtonNext.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("ToolbarLeft") && NextPage)
        {
            PlayConstructionPlanOpen.Post(gameObject);
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
            PlayConstructionPlanOpen.Post(gameObject);
            NextTab.SetActive(true);
            if (FirstActiveButtonNextTab)
            {
                FirstActiveButtonNextTab.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("WorkbenchTabLeft"))
        {
            PlayConstructionPlanOpen.Post(gameObject);
            PreviousTab.SetActive(true);
            if (FirstActiveButtonPreviousTab)
            {
                FirstActiveButtonPreviousTab.SelectButton();
            }
            this.gameObject.SetActive(false);
        }
    }
}
