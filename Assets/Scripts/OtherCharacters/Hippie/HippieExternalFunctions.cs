using UnityEngine;
using Ink.Runtime;
using Ink;

public class HippieExternalFunctions : MonoBehaviour
{
    private Stories StoryManager;
    private Story Story;
    private UIManager UIManager;
    private void Awake()
    {
        UIManager = FindFirstObjectByType<UIManager>();
        StoryManager = FindFirstObjectByType<Stories>();
    }
    private void Start()
    {
        Story = StoryManager.GetStory("HippieStory");
        Bind();
    }
    public void Bind()
    {
        Story.BindExternalFunction("GiveAxe", () =>
        {
            UIManager.CollectAxe();
        });
    }
    public void Unbind()
    {
        Story.UnbindExternalFunction("GiveAxe");
    }

    private void OnDisable()
    {
        Unbind();
    }
}
