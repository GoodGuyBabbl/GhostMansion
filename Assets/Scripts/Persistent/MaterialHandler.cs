using System.Collections.Generic;
using UnityEngine;

public class MaterialHandler : MonoBehaviour
{

    private Dictionary<string, int> Resources = new Dictionary<string, int>();


    private void Start()
    {

        //Filler for lower amounts of differing resources
        Resources["Nothing"] = 0;
        //from Miro


        ////Collectable
        //Resources["IronOreCount"] = 0;
        //Resources["StoneCount"] = 0;
        //Resources["WoodCount"] = 0;
        //Resources["CottonCount"] = 0;
        //Resources["ReedCount"] = 0;
        //Resources["BottleCount"] = 0;
        //Resources["FlowerYellowCount"] = 0;
        //Resources["FlowerPurpleCount"] = 0;
        //Resources["FlowerRedCount"] = 0;
        //Resources["FlowerGreenCount"] = 0;
        //Resources["FlowerPinkCount"] = 0;
        //Resources["FirefliesCount"] = 0;
        //Resources["CobwebCount"] = 0;

        ////Basic Crafting

        //Resources["IronBarCount"] = 0;
        //Resources["PlankCount"] = 0;
        //Resources["FiberCount"] = 0;
        //Resources["ClothCount"] = 0;
        //Resources["YellowDyeCount"] = 0;
        //Resources["PurpleDyeCount"] = 0;
        //Resources["RedDyeCount"] = 0;
        //Resources["GreenDyeCount"] = 0;
        //Resources["PinkDyeCount"] = 0;
        //Resources["GlassCount"] = 0;
        //Resources["PaperCount"] = 0;
        //Resources["BrickCount"] = 0;

        ////Unique

        //Resources["DrumCymbalCount"] = 0;
        //Resources["GreenCarpetCount"] = 0;
        //Resources["PurpleCarpetCount"] = 0;
        //Resources["FirefliesInGlassCount"] = 0;
        //Resources["WallpaperPinkCount"] = 0;
        //Resources["PillowCount"] = 0;
        //Resources["GuitarStringsCount"] = 0;
        //Resources["BookCount"] = 0;
        //Resources["PosterCount"] = 0;


        //in order of resourcesheet
        Resources["WallpaperPinkCount"] = 0;
        Resources["PinkCarpetCount"] = 0;
        Resources["PinkPlankCount"] = 0;
        Resources["PinkPadCount"] = 0;
        Resources["FirefliesInGlassCount"] = 0;
        Resources["YellowDyeCount"] = 0;
        Resources["PaperCount"] = 0;
        Resources["FirefliesCount"] = 0;
        Resources["ClothCount"] = 0;
        Resources["CottonCount"] = 0;
        Resources["PinkDyeCount"] = 0;
        Resources["BookCount"] = 0;
        Resources["SunflowerCount"] = 0;
        Resources["GuitarStringsCount"] = 0;
        Resources["PurpleDyeCount"] = 0;
        Resources["IronBarCount"] = 0;
        Resources["StoneCount"] = 0;
        Resources["PurpleCarpetCount"] = 0;
        Resources["DrumCymbalCount"] = 0;
        Resources["PurplePadCount"] = 0;
        Resources["GreenDyeCount"] = 0;
        Resources["PosterCount"] = 0;
        Resources["WallpaperGreenCount"] = 0;
        Resources["PlankCount"] = 0;
        Resources["WoodenFloor"] = 0;
        Resources["FiberCount"] = 0;
        Resources["PinkStoolCount"] = 0;
        Resources["GreenCarpetCount"] = 0;
        Resources["BrickCount"] = 0;
        Resources["RedDyeCount"] = 0;
        Resources["FlowerYellowCount"] = 0;
        Resources["BottleCount"] = 0;
        Resources["GlassCount"] = 0;
        Resources["CobwebCount"] = 0;
        Resources["FlowerPurpleCount"] = 0;
        Resources["IronOreCount"] = 0;
        Resources["FlowerRedCount"] = 0;
        Resources["WoodCount"] = 0;
        Resources["FlowerGreenCount"] = 0;
        Resources["ReedCount"] = 0;
        Resources["FlowerPinkCount"] = 0;
        Resources["PinkBrickWallCount"] = 0;

    }

    public bool HasEnoughResources(string Name1, int Amount1, string Name2, int Amount2, string Name3, int Amount3, string Name4, int Amount4, string Name5, int Amount5)
    {
        if (Resources[Name1] >= Amount1 && Resources[Name2] >= Amount2 && Resources[Name3] >= Amount3 && Resources[Name4] >= Amount4 && Resources[Name5] >= Amount5 )
        {
            //Resources[Name1] -= Amount1;
            //Resources[Name2] -= Amount2;
            //Resources[Name3] -= Amount3;
            //Resources[Name4] -= Amount4;
            //Resources[Name5] -= Amount5;
            return true;
        }
        else
        {
            return false;
        }   
    }

    //Get
    public int GetResourceCount(string ResourceName)
    {
        return Resources[ResourceName];
    }




    //Increase
    public void IncreaseResourceCount(string ResourceName, int Amount)
    {
        Resources[ResourceName] += Amount;
    }



    //Decrease
    public void DecreaseResourceCount(string ResourceName, int Amount)
    {
        Resources[ResourceName] -= Amount;
    }

}
