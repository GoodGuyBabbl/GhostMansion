using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
    public int WoodCount;
    public int StoneCount;
    public int ClothCount;
    public int FlowerCount;


    public bool HasEnoughResources(int NeededWoodCount, int NeededStoneCount, int NeededClothCount, int NeededFlowerCount)
    {
        if(WoodCount >= NeededWoodCount && StoneCount >= NeededStoneCount && ClothCount >= NeededClothCount && FlowerCount >= NeededFlowerCount)
        {
            WoodCount -=NeededWoodCount;
            StoneCount -=NeededStoneCount;
            ClothCount -=NeededClothCount;  
            FlowerCount -=NeededFlowerCount;
            return true;
        }
        else
        {
            return false;
        }   
    }
    public int GetWoodCount()
    {
        return WoodCount;
    }

    public int GetStoneCount()
    {
        return StoneCount;
    }

    public int GetClothCount()
    {
        return ClothCount;
    }

    public int GetFlowerCount()
    {
        return FlowerCount;
    }

    public void IncreaseWoodCount()
    {
        WoodCount++;
    }

    public void IncreaseStoneCount()
    {
        StoneCount++;
    }
    public void IncreaseClothCount()
    {
        ClothCount++;
    }

    public void IncreaseFlowerCount()
    {
        FlowerCount++;
    }

    public void DecreaseWoodCount()
    {
        WoodCount--;
    }

    public void DecreaseStoneCount()
    {
        StoneCount--;
    }

    public void DecreaseClothCount()
    {
        ClothCount--;
    }

    public void DecreaseFlowerCount()
    {
        FlowerCount--;
    }
}
