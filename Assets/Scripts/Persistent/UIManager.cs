using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Toolbar;
    public GameObject Toolbox;
    public GameObject Pickaxe;
    public GameObject Axe;
    public GameObject WateringCan;
    public GameObject InsectNet;
    public GameObject Hammer;
    public GameObject Sickle; // Todo
    public GameObject Hand; // should be working
    //SlotChange

    private HashSet<int> IsToolCollected = new HashSet<int>();
    public bool IsPickaxeCollected;
    public bool IsAxeCollected;
    public bool IsWateringCanCollected;
    public bool IsInsectNetCollected;

    private void Start()
    {
        CollectHand();
        CollectHammer();
        CollectSickle();
        EnableTools();
    }

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
    public void EnableHand()
    {
        Hand.SetActive(true);
    }
    public void DisableHand()
    {
        Hand.SetActive(false);
    }
    public void EnableHammer()
    { 
        Hammer.SetActive(true);
    }
    public void DisableHammer()
    {
        Hammer.SetActive(false);
    }
    public void EnableSickle()
    {
        Sickle.SetActive(true);
    }
    public void DisableSickle()
    {
        Sickle.SetActive(false);
    }
    public void EnableInsectNet()
    {
        InsectNet.SetActive(true);
    }
    public void DisableInsectNet()
    {
        InsectNet.SetActive(false);
    }
    





    public void DisableTools()
    {
        DisablePickaxe();
        DisableAxe();
        DisableWateringCan();
        DisableInsectNet();
        DisableHammer();
        DisableSickle();
        DisableHand();
       
    }
    public void EnableTools()
    {
        if(IsToolCollected.Contains(1))
        {
            EnableAxe();
        } 
        if(IsToolCollected.Contains(0))
        {
            EnablePickaxe();
        }
        if(IsToolCollected.Contains(2)) 
        { 
            EnableWateringCan();
        }
        if(IsToolCollected.Contains(9))
        {
            EnableHand();
        }
        if(IsToolCollected.Contains(4))
        {
            EnableHammer();
        }
        if(IsToolCollected.Contains(5))
        {
            EnableSickle();
        }
        if (IsToolCollected.Contains(3))
        {
            EnableInsectNet();
        }
    }


    public void CollectAxe()
    {
        IsToolCollected.Add(1);
    }
    public void CollectPickaxe()
    {
        IsToolCollected.Add(0);
    }
    public void CollectWateringCan()
    {
        IsToolCollected.Add(2);
    }
    public void CollectInsectNet()
    {
        IsToolCollected.Add(3);
    }
    public void CollectHand()
    {
        IsToolCollected.Add(9);
    }
    public void CollectHammer()
    {
        IsToolCollected.Add(4);
    }
    public void CollectSickle()
    {
        IsToolCollected.Add(5);
    }
    public bool GetToolCollected(int ToolbarIndex)
    {
        return IsToolCollected.Contains(ToolbarIndex);
    }
    //public bool GetAxeCollected()
    //{
    //    return IsAxeCollected;
    //}
    //public bool GetWateringCanCollected()
    //{
    //    return IsWateringCanCollected;
    //}
    //public bool GetInsectNetCollected()
    //{
    //    return IsInsectNetCollected;
    //}
}
