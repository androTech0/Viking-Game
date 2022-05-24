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

    public List<GameObject> EnemeisArr, GaurdsArr = new List<GameObject>();

    //public List<Transform> RedResourses, BlueResourses, IronResourses, GoldResourses,toRespwn = new List<Transform>();



    /*
     * 
    0 - minerCrystalRed,
    1 - minerCrystalBlue,
    2 - minerIron,
    3 - minerGold,
    4 - treeCutter,
    5 - MinersMenuBtns,
    6 - EnemiesMenuBtns,
    7 - enemy 1,
    8 - Gaurd
    9 - repositry1
    10 - repositry2
    11 - revive1
    12 - revive2


    */
    [SerializeField]
    Text t1,t2,t3, t4, t5;


    private void Start()
    {
        PlayerPrefs.SetInt("RedCrystals", 0);
        PlayerPrefs.SetInt("BlueCrystals", 0);
        PlayerPrefs.SetInt("Iron", 0);
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("Trees", 100);
    }

    private void LateUpdate()
    {
        setValues();
    }



    public void showMinersMenu()
    {
        if (Items[5].active)
        {
            Items[5].SetActive(false);
        }
        else
        {
            Items[5].SetActive(true);
        }
    }
    public void hideMinersMenu()
    {
        Items[5].SetActive(false);
    }

    public void showEnemiesMenu()
    {
        if (Items[6].active)
        {
            Items[6].SetActive(false);
        }
        else
        {
            Items[6].SetActive(true);
        }
    }
    public void hideEnemiesMenu()
    {
        Items[6].SetActive(false);
    }


    public void instantiateEnemy()
    {
        GameObject gamobj =  Instantiate(Items[7],new Vector3(Items[7].transform.position.x + increase1, Items[7].transform.position.y, Items[7].transform.position.z),Items[7].transform.rotation);
        gamobj.transform.parent = GameObject.Find("Enemies").transform;
        EnemeisArr.Add(gamobj);
        //hideEnemiesMenu();
        increase1 += 1.3f;
    }
    public void instantiateGuard()
    {

        GameObject gamobj = Instantiate(Items[8], new Vector3(Items[8].transform.position.x + increase2, Items[8].transform.position.y, Items[8].transform.position.z), Items[8].transform.rotation);
        gamobj.transform.parent = GameObject.Find("Enemies").transform;
        GaurdsArr.Add(gamobj);
        //hideEnemiesMenu();
        increase2 += 1.3f;

    }


    public void instantiateCrystalRed()
    {
        if (Items[9].active)
        {
            Items[0].SetActive(true);
            hideMinersMenu();
        }
        else
        {
            Debug.Log("No storage");
        }
        

    }
    public void instantiateCrystalBlue()
    {
        if (Items[9].active)
        {
            Items[1].SetActive(true);
        hideMinersMenu();
        }
        else
        {
            Debug.Log("No storage");
        }
    }
    public void instantiateIron()
    {
        if (Items[9].active)
        {
            Items[2].SetActive(true);
            hideMinersMenu();
        }
        else
        {
            Debug.Log("No storage");
        }
        
    }
    public void instantiateGold()
    {
        if (Items[9].active)
        {
            Items[3].SetActive(true);
        hideMinersMenu();
        }
        else
        {
            Debug.Log("No storage");
        }
    }

    public void instantiatetree()
    {
        if (Items[9].active)
        {
            Items[4].SetActive(true);
        hideMinersMenu();
        }
        else
        {
            Debug.Log("No storage");
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
                Debug.Log("Not avilable");
            }
            
        }
        else
        {
            Debug.Log("No Trees");
        }
    }

    public void instantiateRepository()
    {
        if (PlayerPrefs.GetInt("Trees") >= 100)
        {
            if (!Items[9].active)
            {
                Items[9].SetActive(true);
                PlayerPrefs.SetInt("Trees", PlayerPrefs.GetInt("Trees") - 100);
                //hideMinersMenu();
            }
            else if (Items[9].active && !Items[10].active)
            {
                Items[10].SetActive(true);
                PlayerPrefs.SetInt("Trees" ,PlayerPrefs.GetInt("Trees") - 100);
                // hideMinersMenu();
            }
            else
            {
                Debug.Log("Not avilable");
            }
        }
        else
        {
            Debug.Log("No Trees");
        }
    }


    void setValues()
    {
        t1.text = "Red Crystal = " + PlayerPrefs.GetInt("RedCrystals", 0);
        t2.text = "Blue Crystal = " + PlayerPrefs.GetInt("BlueCrystals", 0);
        t3.text = "Iron = " + PlayerPrefs.GetInt("Iron", 0);
        t4.text = "Gold = " + PlayerPrefs.GetInt("Gold", 0);
        t5.text = "Trees = " + PlayerPrefs.GetInt("Trees", 0);
    }


}
