using System.Security.Cryptography;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Toolbar;
    public GameObject Toolbox;
    public GameObject Pickaxe;
    public GameObject Axe;
    public GameObject WateringCan;
    public GameObject InsectNet;

    public bool IsPickaxeCollected;
    public bool IsAxeCollected;
    public bool IsWateringCanCollected;
    public bool IsInsectNetCollected;


    public void DisableToolbar()
    {
        Toolbar.SetActive(false);
        DisableTools();
        //Toolbox.SetActive(false);
    }
    public void EnableToolbar()
    {
        Toolbar.SetActive(true);
        EnableTools();
        //Toolbox.SetActive(true);    
    }

    public void EnablePickaxe()
    {
        Pickaxe.SetActive(true);
    }
    public void DisablePickaxe()
    {
        Pickaxe.SetActive(false);
    }

    public void EnableAxe()
    {
        Axe.SetActive(true);
    }
    public void DisableAxe()
    {
        Axe.SetActive(false);
    }

    public void EnableWateringCan()
    {
        Pickaxe.SetActive(true);
    }
    public void DisableWateringCan()
    {
        Pickaxe.SetActive(false);
    }




    public void DisableTools()
    {
        DisableAxe();
        DisablePickaxe();
        DisableWateringCan();
    }
    public void EnableTools()
    {
        if(IsAxeCollected)
        {
            EnableAxe();
        } 
        if(IsPickaxeCollected)
        {
            EnablePickaxe();
        }
        if(IsWateringCanCollected) 
        { 
            EnableWateringCan();
        }
    }


    public void CollectAxe()
    {
        IsAxeCollected = true;
    }
    public void CollectPickaxe()
    {
        IsPickaxeCollected = true;
    }
    public void CollectWateringCan()
    {
        IsWateringCanCollected = true;
    }
    public void CollectInsectNet()
    { 
        IsInsectNetCollected = true;
    }
    public bool GetPickaxeCollected()
    {
        return IsPickaxeCollected;
    }
    public bool GetAxeCollected()
    {
        return IsAxeCollected;
    }
    public bool GetWateringCanCollected()
    {
        return IsWateringCanCollected;
    }
    public bool GetInsectNetCollected()
    {
        return IsInsectNetCollected;
    }
}
