using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Items;

    float increase1, increase2 = 1;

    public GameObject pathss;

    public List<GameObject> EnemeisArr, GaurdsArr,citizensArr = new List<GameObject>();

    //public List<Transform> RedResourses, BlueResourses, IronResourses, GoldResourses,toRespwn = new List<Transform>();

    float swordCounter = 5f;
    float hammerCounter = 5f;
    float sheildCounter = 5f;
    float axeCounter = 2f;
    float pickaxeCounter = 2f;

    /*
     * 
    0 - minerCrystalRed,
    1 - minerCrystalBlue,
    2 - minerIron,
    3 - minerGold,
    4 - treeCutter,
    5 - --,
    6 - Gaurd2,
    7 - enemy 1,
    8 - Gaurd1
    9 - repositry1
    10 - repositry2
    11 - revive1
    12 - revive2
    13 - collector 1
    14 - collector 2
    15 - collector 3
    16 - collector 4
    17 - collector trees
    18 - WeapansMaker1
    19 - shiltter 1
    20 - shiltter 2
    21 - citizen


    */
    [SerializeField]
    Text t1,t2,t3, t4, t5,t6,t7,t8;


    private void Start()
    {
        PlayerPrefs.SetInt("RedCrystals", 1000);
        PlayerPrefs.SetInt("BlueCrystals", 0);
        PlayerPrefs.SetInt("Iron", 25);
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("Trees", 1000);
        PlayerPrefs.SetInt("Swords",0);
        PlayerPrefs.SetInt("Shields",0);
        PlayerPrefs.SetInt("Hammers",0);
        PlayerPrefs.SetInt("Axe", 0);
        PlayerPrefs.SetInt("Pickaxe", 0);
    }

    void LateUpdate()
    {
        setValues();
        makeWeapons();
    }



    #region instantiate fighters
    public void instantiateEnemy()
    {/*
        if (Items[11].active)
        {
            */
        GameObject gamobj =  Instantiate(Items[7],new Vector3(Items[7].transform.position.x + increase1, Items[7].transform.position.y, Items[7].transform.position.z),Items[7].transform.rotation);
        gamobj.transform.parent = GameObject.Find("Enemies").transform;
        EnemeisArr.Add(gamobj);
        //hideEnemiesMenu();
        increase1 += 1.3f;
            /*
        }
        else
        {
            SSTools.ShowMessage("you must build a Hospital before fighting", SSTools.Position.top, SSTools.Time.threeSecond);

        }*/
        
    }

    public void citizenBB()
    {
        if (citizensArr.Count > 0)
        {

            if (PlayerPrefs.GetInt("Swords") > 0 && PlayerPrefs.GetInt("Shields") > 0)
            {
                citizensArr[0].GetComponent<moveCitizen>().isBusy = true;
                citizensArr.RemoveAt(0);
            }

            else
            {
                SSTools.ShowMessage("Need Weapans !!", SSTools.Position.top, SSTools.Time.threeSecond);

            }
        }
    }

    public void instantiateGuard()
    {
                GameObject gamobj = Instantiate(Items[8], new Vector3(Items[8].transform.position.x + increase2, Items[8].transform.position.y, Items[8].transform.position.z), Items[8].transform.rotation);
                gamobj.transform.parent = GameObject.Find("Enemies").transform;
                GaurdsArr.Add(gamobj);
                //hideEnemiesMenu();
                increase2 += 1.3f;
                PlayerPrefs.SetInt("Swords", PlayerPrefs.GetInt("Swords") - 1);
                PlayerPrefs.SetInt("Shields", PlayerPrefs.GetInt("Shields") - 1);
    }

    public void instantiateGuard2()
    {
        
        if (PlayerPrefs.GetInt("Hammers") > 0 && PlayerPrefs.GetInt("Shields") > 0)
        {
            GameObject gamobj = Instantiate(Items[6], new Vector3(Items[6].transform.position.x + increase2, Items[6].transform.position.y, Items[6].transform.position.z), Items[6].transform.rotation);
            gamobj.transform.parent = GameObject.Find("Enemies").transform;
            GaurdsArr.Add(gamobj);
            //hideEnemiesMenu();
            increase2 += 1.3f;
            PlayerPrefs.SetInt("Hammers", PlayerPrefs.GetInt("Hammers") - 1);
            PlayerPrefs.SetInt("Shields", PlayerPrefs.GetInt("Shields") - 1);
        }
        else
        {
            SSTools.ShowMessage("Need Weapans !!", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }
    #endregion


    #region active Miners
    public void instantiateCrystalRed()
    {
        if (Items[9].active)
        {
            Items[0].SetActive(true);
        }
        else
        {
            SSTools.ShowMessage("you must build a Repository First",SSTools.Position.top,SSTools.Time.threeSecond);
        }
        

    }
    public void instantiateCrystalBlue()
    {
        if (Items[9].active)
        {
            Items[1].SetActive(true);
        }
        else
        {
            SSTools.ShowMessage("you must build a Repository First", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }
    public void instantiateIron()
    {
        if (Items[9].active)
        {
            Items[2].SetActive(true);
        }
        else
        {
            SSTools.ShowMessage("you must build a Repository First", SSTools.Position.top, SSTools.Time.threeSecond);
        }
        
    }
    public void instantiateGold()
    {
        if (Items[9].active)
        {
            Items[3].SetActive(true);
        }
        else
        {
            SSTools.ShowMessage("you must build a Repository First", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }

    public void instantiatetree()
    {
        if (Items[9].active)
        {
            Items[4].SetActive(true);
        }
        else
        {
            SSTools.ShowMessage("you must build a Repository First", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }
    #endregion


    #region active Building

    public void instantiateWeaponsMaker()
    {
        if (PlayerPrefs.GetInt("Trees") >= 200)
        {
            if (!Items[18].active) {
                Items[18].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 500);
            }
        }
        else
        {
            SSTools.ShowMessage("you don't have wood", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }
    public void instantiateHospital()
    {
        if (PlayerPrefs.GetInt("Trees") >= 200)
        {
            if (!Items[11].active)
            {
                Items[11].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 200);
                //hideMinersMenu();
            }
            else if (Items[11].active && !Items[12].active)
            {
                Items[12].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 200);
                // hideMinersMenu();
            }
            else
            {
                SSTools.ShowMessage("number of maximum hospitals is Two", SSTools.Position.top, SSTools.Time.threeSecond);
            }
            
        }
        else
        {
            SSTools.ShowMessage("you don't have wood", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }

    public void instantiateRepository()
    {
        if (PlayerPrefs.GetInt("Trees") >= 100)
        {
            if (!Items[9].active)
            {
                Items[9].SetActive(true);
                activeCollectors();
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 100);
                //hideMinersMenu();
            }
            else if (Items[9].active && !Items[10].active)
            {
                Items[10].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 100);
                // hideMinersMenu();
            }
            else
            {
                SSTools.ShowMessage("number of maximum Stores is Two", SSTools.Position.top, SSTools.Time.threeSecond);
            }
        }
        else
        {
            SSTools.ShowMessage("you don't have wood", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }
    public void instantiateShiltter()
    {
        if (PlayerPrefs.GetInt("Trees") >= 100)
        {
            if (!Items[19].active)
            {
                Items[19].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 100);
                //hideMinersMenu();
            }
            else if (Items[19].active && !Items[20].active)
            {
                Items[20].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 100);
                // hideMinersMenu();
            }
            else
            {
                SSTools.ShowMessage("number of maximum Stores is Two", SSTools.Position.top, SSTools.Time.threeSecond);
            }
        }
        else
        {
            SSTools.ShowMessage("you don't have wood", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }

    #endregion

    void makeWeapons() {
        if (Items[18].active)
        {
            if (swordCounter > 0.0f && PlayerPrefs.GetInt("Iron") >= 5)
            {
                swordCounter -= 1;
            }
            else if (swordCounter == 0.0f)
            {
                PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") - 5);
                PlayerPrefs.SetInt("Swords", PlayerPrefs.GetInt("Swords") + 1);
                swordCounter = 2f;
            }

            if (hammerCounter > 0.0f && PlayerPrefs.GetInt("Iron", 0) >= 5)
            {
                hammerCounter -= 1;
            }
            else if (hammerCounter == 0.0f)
            {
                PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") - 5);
                PlayerPrefs.SetInt("Hammers", PlayerPrefs.GetInt("Hammers") + 1);
                hammerCounter = 2f;
            }

            if (sheildCounter > 0.0f && PlayerPrefs.GetInt("Iron", 0) >= 5)
            {
                sheildCounter -= 1;
            }
            else if (sheildCounter == 0.0f)
            {
                PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") - 5);
                PlayerPrefs.SetInt("Shields", PlayerPrefs.GetInt("Shields") + 1);
                sheildCounter = 2f;
            }
        }
    }


    public void instantiateCitizens()
    {
        if (Items[19].active)
        {
            if (PlayerPrefs.GetInt("RedCrystals") >= 5)
            {

            GameObject citizen = Instantiate(Items[21]);
            citizen.transform.parent = GameObject.Find("Citizens").transform;
            citizensArr.Add(citizen);
                PlayerPrefs.SetInt("RedCrystals", PlayerPrefs.GetInt("RedCrystals") - 5);
            }
            else
            {
                SSTools.ShowMessage("need crystals", SSTools.Position.top, SSTools.Time.threeSecond);

            }
        }
        else
        {
            SSTools.ShowMessage("create shiltter", SSTools.Position.top, SSTools.Time.threeSecond);
        }
    }
    void activeCollectors()
    {
        Items[13].SetActive(true);
        Items[14].SetActive(true);
        Items[15].SetActive(true);
        Items[16].SetActive(true);
        Items[17].SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void setValues()
    {
        t1.text = "Red Crystal = " + PlayerPrefs.GetInt("RedCrystals", 0);
        t2.text = "Blue Crystal = " + PlayerPrefs.GetInt("BlueCrystals", 0);
        t3.text = "Iron = " + PlayerPrefs.GetInt("Iron", 0);
        t4.text = "Gold = " + PlayerPrefs.GetInt("Gold", 0);
        t5.text = "Trees = " + PlayerPrefs.GetInt("Trees", 0);
        t6.text = "Swords = " + PlayerPrefs.GetInt("Swords", 0);
        t7.text = "Hammers = " + PlayerPrefs.GetInt("Hammers", 0);
        t8.text = "Shields = " + PlayerPrefs.GetInt("Shields", 0);
    }

}


