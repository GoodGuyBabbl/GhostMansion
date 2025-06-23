VAR NextDialogueKnot = ""
VAR CanRepairFurniture = false

===Start===
What do you want to know more about?
    *[Tools]
        I see you've already got an Axe in addition to my Pickaxe. If you want to help that Hippielady out, you're going to need some more stuff though.
        I suggest running around a bit in the garden, there should still be something handy lying around from back in my times..
        ~NextDialogueKnot = "Start"
        ->END
    *[Inhabitants]
        White knight in shining armor! Coming to the rescue of the depressed and soulless inhabitants of this ghostly manor!
        Jokes aside, you've already seen what has become of this place. The people here need a change of scenery. Try and rid them of their colorless peril by refurbishing their furniture.
        If that sparks them with joy for the eternity of afterlife, I too will be forever in your debt.
        ...
        Still here?
        Grab a hammer and get to it already! Collect whatever you need here in the garden and the lobby where we first met, then Craft up whatever you need on this Workbench. 
        If you've got your stuff, you can go to the living area and start hammering away!
        ~NextDialogueKnot = "Start"
        ->END
    *[Material]
        Every resource has a tool it needs to be farmed with. Select the tool you want to use by pressing the left and right shoulder buttons to navigate in your toolbar.
        While some things like trees might be the obvious source for wood, others could turn out to be more tricky.
        If you're unsure of what exactly it is that you are searching for, take a look at the recipes in our workbench over here. 
        ~NextDialogueKnot = "Start"
        ->END
    *[Workbench]
        This is going to be the heart of your operation. You can switch between pages by pressing the shoulder buttons of your controller. 
        I have added every recipe needed aswell as every available resident to your list of items. Their symbols at the top match the ones on their doors in the manor.
        Crafting buttons will be grey if you do not have enough resources to craft the item and brown if you do.
        There's one page of overview for every room and its inhabitant on which you can take a look at what furniture you are going to build.
        










->END