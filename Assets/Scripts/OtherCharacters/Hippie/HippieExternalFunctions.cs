using UnityEngine;
using Ink.Runtime;
using Ink;

public class HippieExternalFunctions : MonoBehaviour
{
    private Stories StoryManager;
    private Story Story;
    private UIManager UIManager;
    private SaveStateManager SaveStateManager;
    private string TriggerTutorialGhostToGarden = "-1,167_0_GhostStoryToGardenTrigger"; //From UniqueID of GhostStoryToGardenTrigger in MainRoom
    private string TriggerTutGhostInGarden = "5,583_-0,009393839_TriggerColliderTutGhost"; // "" of TriggerColliderTutGhost in Garden
    private void Awake()
    {
        UIManager = FindFirstObjectByType<UIManager>();
        StoryManager = FindFirstObjectByType<Stories>();
    }
    private void Start()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        Story = StoryManager.GetStory("HippieStory");
        Bind();
    }
    public void Bind()
    {
        Story.BindExternalFunction("GiveAxe", () =>
        {
            UIManager.CollectAxe();
        });
        Story.BindExternalFunction("GoingToGarden", () =>
        {
            SaveStateManager.SetCurrentStory("TutorialGhostStory", "GoingToGarden");
            SaveStateManager.MarkObjectAsChanged(TriggerTutorialGhostToGarden);
            SaveStateManager.MarkObjectAsChanged(TriggerTutGhostInGarden);
        });
    }
    public void Unbind()
    {
        Story.UnbindExternalFunction("GiveAxe");
        Story.UnbindExternalFunction("GoingToGarden");
    }

    private void OnDisable()
    {
        Unbind();
    }
}
