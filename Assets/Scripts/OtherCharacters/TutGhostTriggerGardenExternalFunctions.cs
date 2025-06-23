using UnityEngine;
using Ink.Runtime;

public class TutGhostTriggerGardenExternalFunctions : MonoBehaviour
{
    private Stories StoryManager;
    private Story Story;
    private SaveStateManager SaveStateManager;
    private UniqueID UniqueID;

    public TriggerOnGround TriggerTutGhostGarden;

    private void Awake()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        StoryManager = FindFirstObjectByType<Stories>();
        UniqueID = GetComponent<UniqueID>();
    }
    private void Start()
    {
        if (SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            this.gameObject.SetActive(false);
        }

        Story = StoryManager.GetStory("TutGhostTriggerGardenStory");
        Bind();
    }

    public void Bind()
    {
        if (this.gameObject.activeSelf)
        {
            Story.BindExternalFunction("Disappear", () =>
            {
                this.gameObject.GetComponent<Animator>().SetBool("Disappearing", true);
                SaveStateManager.MarkObjectAsChanged(UniqueID.ID);
                SaveStateManager.SetStoryTriggerDone(TriggerTutGhostGarden.UniqueID.ID);
                SaveStateManager.SetCurrentStory("HippieStory", "RoomNotRepaired");
                TriggerTutGhostGarden.gameObject.SetActive(false);

            });
        }

    }

    public void Unbind()
    {
        if (this.gameObject.activeSelf)
        {
            Story.UnbindExternalFunction("Disappear");
        }
    }

    private void OnDisable()
    {
        Unbind();
    }


}
