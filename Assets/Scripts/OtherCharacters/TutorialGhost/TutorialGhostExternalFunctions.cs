using UnityEngine;
using Ink.Runtime;
using Ink;
using System.Runtime.CompilerServices;

public class TutorialGhostExternalFunctions : MonoBehaviour
{
    private Stories StoryManager;
    private Story Story;
    private SaveStateManager SaveStateManager;
    private Carpet Carpet;
    public TriggerOnGround TriggerTutorialGhostToGarden;
    public PolygonCollider2D StonePileInteractionCollider;

    private void Awake()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        StoryManager = FindFirstObjectByType<Stories>();
        Carpet = FindFirstObjectByType<Carpet>();
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
            Carpet.IsCarpetEnabled = true;
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

        Story.BindExternalFunction("EnableCarpet", () =>
        {
            Carpet.IsCarpetEnabled = true;
        });
        Story.BindExternalFunction("Disappear", () =>
        {
            this.gameObject.GetComponent<Animator>().SetBool("Disappearing", true);
            SaveStateManager.SetTutorialGhostState("Disappeared");
            SaveStateManager.SetStoryTriggerDone(TriggerTutorialGhostToGarden.UniqueID.ID);
            TriggerTutorialGhostToGarden.gameObject.SetActive(false);

        });
        Story.BindExternalFunction("EnableStonePile", () =>
        {
            StonePileInteractionCollider.enabled = true;
            SaveStateManager.SetStoryTriggerDone(StonePileInteractionCollider.GetComponent<UniqueID>().ID);
        });

    }
    public void Unbind()
    {
        Story.UnbindExternalFunction("PutGhostInIdle");
        Story.UnbindExternalFunction("EnableCarpet");
        Story.UnbindExternalFunction("Disappear");
        Story.UnbindExternalFunction("EnableStonePile");
    }

    private void OnDisable()
    {
        Unbind();
    }
}
