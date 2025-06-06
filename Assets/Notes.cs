using UnityEngine;

public class Notes : MonoBehaviour
{
    // Camera Confiner: entweder Damp hoch und vor fade in kamera auf 0 0 -5; oder in jeder szene deadzone in cinemachine cam per code anpassen




    //Interaktion in Hitbox des Baumes gedrückt halten

    //Animation Startet in Richung des Baumes, also Vektor von Player mittelpunkt richtung baum normalisiert in blend tree als direction für 
    //workingdirection und idle direction setzen

    //wenn knopf gehalten wird, dann ist nach bestimmter zeit der baum gefällt -> Sprite ändern, Holz droppen, WorkingAnimation stoppen  

    //wenn Knopf früher losgelassen wird, dann progress zurücksetzen und WorkingAnimation stoppen

    //

    //Mineable GOs: Baum, Felsen, Glasflaschenhaufen, Müllsäcke, Pflanzen
    //
    //
    //
    //Werte Szenenübergreifend behalten: Maybe alles, was Werte speichern kann, inactive setzen und nur aktivieren, wenn in der szene? Problem : doppelte gameobjects, wenn szene mehrfach betreten wird
    //Bandaid Lösung: if(! gameobject existiert bereits){dann dont instantiate} else {nicht erstellen}
    //
    //
    //
}
