VAR NextDialogueKnot = ""
VAR CanRepairFurniture = false
->Start

===Start===
~NextDialogueKnot = "Start"
~CanRepairFurniture = false
    Oh hey! I saw what you did to my neighbors room over there..
    I would love a room-makeover too!
    What do you say, want to go once again?
        *[Yes.]
        ->SaidYes
        
        *[No.]
        Oh...
        ~NextDialogueKnot = "Redecide"
->END


===Redecide===
    Yes?
        *[I want to help you.]
            You sure? 
            ->SaidYes
        *[Nothing. Bye.]
        ~NextDialogueKnot = "Redecide"
        ->END
        
===SaidYes===
    Love to hear that! I'm excited about what you are going to come up with.
    ~CanRepairFurniture = true
    ~NextDialogueKnot = "IsRepairing"
    ->END
    
===IsRepairing===
    I'm sorry but I can't help you. Delicate hands, you know.
    ~CanRepairFurniture = true
    ->END

===RoomRepaired===
    This is brilliant! Thank you so much!
->END