using Ink.Runtime;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Stories : MonoBehaviour
{
    private Dictionary<string, Story> StoryStorage = new Dictionary<string, Story>();

    public TextAsset HippieTextFile;
    public TextAsset TutorialGhostTextFile;
    public TextAsset MuscleManTextFile;
    public TextAsset DrunkenGhostTextFile;
    public Story MuscleManStory;
    public Story HippieStory;
    public Story TutorialGhostStory;
    public Story DrunkenGhostStory;

    private void Awake()
    {
        StoryStorage["HippieStory"] = new Story(HippieTextFile.text);
        StoryStorage["TutorialGhostStory"] = new Story(TutorialGhostTextFile.text);
        StoryStorage["MuscleManStory"] = new Story(MuscleManTextFile.text);
        StoryStorage["DrunkenGhostStory"] = new Story(DrunkenGhostTextFile.text);
    }

    public Story GetStory(string StoryName)
    {
        if (StoryStorage.TryGetValue(StoryName, out Story StoryNeeded))
        {
            return StoryNeeded;
        }
        else
        {
            Debug.LogWarning("There is no story with that name. Check RoomNPC Inspector.");
            return null;
        }
    }

}
