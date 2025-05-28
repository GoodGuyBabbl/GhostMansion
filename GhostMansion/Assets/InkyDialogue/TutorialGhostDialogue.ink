//EXTERNAL GivePickaxe()
//EXTERNAL PutGhostInIdle()
/////////////////////////////////////////////////////////////////
VAR CanRepairFurniture = false
===TutorialStart===
VAR NextDialogueKnot = ""
Oh no, no, no, no, no...
Can you hear that?
Somebody is caught inside that room up there! I need something to get that rubble out of the way! 
I'm pretty sure I dropped my Pickaxe down in the cellar before I died. But it's been 400 years and I cant remember the location of the entrance...
Will you help me?
        *[Yes, but calm down.]
        ->DidHelp

        *[Nah, I'm good.]
        AAAAAAAAHHHHHHHHHHHH
        ~NextDialogueKnot = "DidntHelp"
        ->END

/////////////////////////////////////////////////////////////////
===DidHelp===
//Animation auslaufen lassen
//~PutGhostInIdle()
~NextDialogueKnot = "Helping"
...
Okay. Okay, I'm calm. Thank you.
Please go and find the hatch down into the basement. If you've got the pickaxe, go and bring it to me. I'll do the rest.
        ->END





/////////////////////////////////////////////////////////////////
===DidntHelp===
Changed your mind?
        *[Yes, but calm down.]
        ->DidHelp
        *[Nope.]
        A**.
        ->END
/////////////////////////////////////////////////////////////////
===Helping===
This damned hatch has to be somewhere around here! Keep looking!
        ->END

/////////////////////////////////////////////////////////////////
===PickaxePickedUp===
You found it! That's great, give it here
...
Wait, I can't even hold it...
Whatever, you'll have to do it! Take it and Go! 
//~GivePickaxe()
        ~NextDialogueKnot = "BreakStones"
        ->BreakStones

===BreakStones===
Just swing it as hard as you can at that pile of stones in front of the door up there. 
You can do that by holding the Interact Button.





- ->END