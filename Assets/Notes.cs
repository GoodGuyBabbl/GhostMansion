using UnityEngine;

public class Notes : MonoBehaviour
{
    // Camera Confiner: entweder Damp hoch und vor fade in kamera auf 0 0 -5; oder in jeder szene deadzone in cinemachine cam per code anpassen




    //Interaktion in Hitbox des Baumes gedr�ckt halten

    //Animation Startet in Richung des Baumes, also Vektor von Player mittelpunkt richtung baum normalisiert in blend tree als direction f�r 
    //workingdirection und idle direction setzen

    //wenn knopf gehalten wird, dann ist nach bestimmter zeit der baum gef�llt -> Sprite �ndern, Holz droppen, WorkingAnimation stoppen  

    //wenn Knopf fr�her losgelassen wird, dann progress zur�cksetzen und WorkingAnimation stoppen

    //

    //Mineable GOs: Baum, Felsen, Glasflaschenhaufen, M�lls�cke, Pflanzen
    //
    //
    //
    //Werte Szenen�bergreifend behalten: Maybe alles, was Werte speichern kann, inactive setzen und nur aktivieren, wenn in der szene? Problem : doppelte gameobjects, wenn szene mehrfach betreten wird
    //Bandaid L�sung: if(! gameobject existiert bereits){dann dont instantiate} else {nicht erstellen}
    //
    //
    //




    //Progressbar Immer enablen in Buildplot, in workbench nur, wenn was gecraftet wird
    //snegge �bergang rauchwolke einf�gen
}
