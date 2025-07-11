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
    public TextAsset TutGhostWorkbenchTextFile;
    public TextAsset TutGhostTriggerGardenTextFile;
    public TextAsset MuscleManInMainRoomTextFile;
    public Story MuscleManStory;
    public Story HippieStory;
    public Story TutorialGhostStory;
    public Story DrunkenGhostStory;
    public Story TutGhostWorkbenchStory;
    public Story TutGhostTriggerGardenStory;
    public Story MuscleManInMainRoomStory;

    private void Awake()
    {
        StoryStorage["HippieStory"] = new Story(HippieTextFile.text);
        StoryStorage["TutorialGhostStory"] = new Story(TutorialGhostTextFile.text);
        StoryStorage["MuscleManStory"] = new Story(MuscleManTextFile.text);
        StoryStorage["DrunkenGhostStory"] = new Story(DrunkenGhostTextFile.text);
        StoryStorage["TutGhostWorkbenchStory"] = new Story(TutGhostWorkbenchTextFile.text);
        StoryStorage["TutGhostTriggerGardenStory"] = new Story(TutGhostTriggerGardenTextFile.text);
        StoryStorage["MuscleManInMainRoomStory"] = new Story(MuscleManInMainRoomTextFile.text);
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
