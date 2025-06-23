VAR NextDialogueKnot = ""
VAR CanRepairFurniture = false
EXTERNAL Disappear()

===Start===
    There you are, what took you so long?
    I've already taken a look around and my memories are coming back to me slowly...
    If you want to get started, I suggest following that gravel path to the left.
    ~NextDialogueKnot = "Start"
    ~CanRepairFurniture = false
    ~Disappear()

->END