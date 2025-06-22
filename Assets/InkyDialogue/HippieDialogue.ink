////////////////////////////////////////////////////////////
EXTERNAL GiveAxe()
EXTERNAL GoingToGarden()
VAR CanRepairFurniture = false
===TutorialStart===
VAR NextDialogueKnot = ""
'Sniff'
Oh.. How did you get in here? I thought I was locked inside?
        *[Yes, I moved those stones blocking your door. Why were you crying?]
        Why? Look around! This place looks horrible! I need some color in here or else I'm gonna go crazy!
                **[Maybe I could help you out?]
                ~NextDialogueKnot = "DidHelp"
                Oh, you would do that? 
                ->DidHelp
                **[Can't do anything about that, I'm sorry.]
                ~NextDialogueKnot = "DidntHelp"
                ->END
        *[Sorry to disturb you.]
        ~NextDialogueKnot = "TutorialStart"
        ->END



////////////////////////////////////////////////////////////
===DidHelp===
That sounds great! I think you should maybe try the garden by the pond, if you want to get me some new things. Strange.. I've never been out there but somehow I recall there being a workbench..
Anyways, you might need this axe.
~GiveAxe()
You know, I was going to go out there and do it myself but I almost killed myself again trying to swing that thing hahahahahahaHAHAHAHAHAHA
        ~NextDialogueKnot = "IsHelping"
        ~CanRepairFurniture = true
        ~GoingToGarden()
        ->END



////////////////////////////////////////////////////////////
===DidntHelp===
Changed your mind?
        *[Yes.]
        ->DidHelp
        *[Nope.]
        ->END

////////////////////////////////////////////////////////////
===IsHelping===
The Garden I was talking about is just outside of the house and to the left. You can't miss it.
        ~CanRepairFurniture = true


->END



