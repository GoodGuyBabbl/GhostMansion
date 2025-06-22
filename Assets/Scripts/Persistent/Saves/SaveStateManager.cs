using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveStateManager : MonoBehaviour
{
    public static SaveStateManager Instance; 

    //Hashsets statt Listen, um Duplikate zu vermeiden
    private HashSet<string> MinedResources = new HashSet<string>();
     
    private HashSet<string> ChangedObject = new HashSet<string>();

    private HashSet<string> BuildPlot = new HashSet<string>();

    private HashSet<string> RepairedFurniture = new HashSet<string>();

    private HashSet<string> IsRepairEnabled = new HashSet<string>();

    private HashSet<string> StoryDone = new HashSet<string>();
    //Dictionaries statt Listen, um Duplikate zu vermeiden
    public Dictionary<string, int> ColorChangeControllerState = new Dictionary<string, int>();

    private string CurrentDialogueKnotTutorialGhost = "TutorialStart";
    private string CurrentDialogueKnotHippie = "TutorialStart";
    private string CurrentDialogueKnotMuscleMan = "Start";
    private string CurrentDialogueKnotDrunkenGhost = "Start";



    private string TutorialGhostState;

    private void Awake()
    {
        Instance = this;
    }

    //Mineable Resources
    public void MarkResourceAsMined(string ResourceID)
    {
        MinedResources.Add(ResourceID);
    }
    public void MarkResourceAsRegrown(string ResourceID)
    {
        MinedResources.Remove(ResourceID);
    }
    public bool IsResourceMined(string ResourceID) 
    {
        return MinedResources.Contains(ResourceID);
    }

    //IsRepairEnabled
    public void MarkRepairAsEnabled(string NPCID)
    {
        IsRepairEnabled.Add(NPCID);
    }
    public bool GetIsRepairEnabled(string NPCID)
    {
        return IsRepairEnabled.Contains(NPCID);
    }
    //Buildplots
    public void MarkAsBuildPlot(string FurnitureID)
    {
        BuildPlot.Add(FurnitureID);
    }
    public void RemoveFromBuildPlot(string FurnitureID)
    {
        BuildPlot.Remove(FurnitureID);
    }
    public void MarkAsRepaired(string FurnitureID) 
    {
        RepairedFurniture.Add(FurnitureID);
    }
    public bool IsFurnitureRepaired(string FurnitureID)
    {
        return RepairedFurniture.Contains(FurnitureID);
    }
    public bool IsBuildPlot(string FurnitureID)
    {
        return BuildPlot.Contains(FurnitureID);
    }

    //ColorChange
    public bool HasDoneRepairCount(string NPCID) //für die erste ausführung, solange noch nichts repariert wurde, um keinen fehler zu erhalten, da das dictionary noch leer ist
    {
        return ColorChangeControllerState.ContainsKey(NPCID);
    }
    public void SaveDoneRepairCount(string NPCID, int RepairsDone)
    {
        ColorChangeControllerState[NPCID] = RepairsDone;
    }
    public int GetDoneRepairCount(string NPCID)
    {
        return ColorChangeControllerState[NPCID];
    }
    //Alle GOs, die zwei Zustände, also entweder eingesammelt/Interagiert/abgebaut etc. haben
    public void MarkObjectAsChanged(string ChangedObjectID)
    {
        ChangedObject.Add(ChangedObjectID);
    }

    public bool IsObjectChanged(string ChangedObjectID)
    {
        return ChangedObject.Contains(ChangedObjectID);
    }

    //Story Triggers

    public void SetStoryTriggerDone(string TriggerID)
    {
        StoryDone.Add(TriggerID);
    }
    public bool GetStoryTriggerDone(string TriggerID)
    {
        return StoryDone.Contains(TriggerID);
    }


    //Story Setter
    public void SetCurrentStory(string StoryName, string KnotName)
    {
        switch (StoryName)
        {
            case "TutorialGhostStory":
                CurrentDialogueKnotTutorialGhost = KnotName;
                break;
            case "HippieStory":
                CurrentDialogueKnotHippie = KnotName;
                break;
            case "MuscleManStory":
                CurrentDialogueKnotMuscleMan = KnotName;
                break;
            case "DrunkenGhostStory":
                CurrentDialogueKnotDrunkenGhost = KnotName;
                break;
            default:
                break;
        }
    }



    //Story Getter
    public string GetCurrentStory(string StoryName)
    {
        switch (StoryName)
        {
            case "TutorialGhostStory":
                return CurrentDialogueKnotTutorialGhost;
            case "HippieStory":
                return CurrentDialogueKnotHippie;
            case "MuscleManStory":
                return CurrentDialogueKnotMuscleMan;
            case "DrunkenGhostStory":
                return CurrentDialogueKnotDrunkenGhost;
            default:
                return null;
        }
    }

    //TutorialGhostMainRoom

    public void SetTutorialGhostState(string State)
    {
        TutorialGhostState = State;
    }

    public string GetTutorialGhostState()
    {
        return TutorialGhostState;
    }

}
