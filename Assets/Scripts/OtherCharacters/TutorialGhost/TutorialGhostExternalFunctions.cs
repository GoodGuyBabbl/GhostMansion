using UnityEngine;
using Ink.Runtime;
using Ink;
using System.Runtime.CompilerServices;

public class TutorialGhostExternalFunctions : MonoBehaviour
{
    private Stories StoryManager;
    private Story Story;
    private SaveStateManager SaveStateManager;

    private void Awake()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        StoryManager = FindFirstObjectByType<Stories>();
    }

    private void Start()
    {
        if(SaveStateManager.GetTutorialGhostState() == "Disappeared")
        {
            this.gameObject.SetActive(false);
        }
        else if( SaveStateManager.GetTutorialGhostState() == "Calm")
        {
            this.gameObject.GetComponent<Animator>().SetBool("InstantIdle", true);
        }
            
        Story = StoryManager.GetStory("TutorialGhostStory");
        Bind();
    }

    public void Bind()
    {
        Story.BindExternalFunction("PutGhostInIdle", () =>
        {
            this.gameObject.GetComponent<Animator>().SetBool("Idle", true);
            SaveStateManager.SetTutorialGhostState("Calm");
        });
    }
    public void Unbind()
    {
        Story.UnbindExternalFunction("PutGhostInIdle");
    }

    private void OnDisable()
    {
        Unbind();
    }
}
