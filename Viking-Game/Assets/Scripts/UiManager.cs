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
    9 - Hosipital



    */
    [SerializeField]
    Text t1,t2,t3, t4, t5;

    //[SerializeField]
    //public Transform[] RedArrays;




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
        //Items[7].SetActive(true);
        GameObject gamobj =  Instantiate(Items[7],new Vector3(Items[7].transform.position.x + increase1, Items[7].transform.position.y, Items[7].transform.position.z),Items[7].transform.rotation);
        gamobj.transform.parent = GameObject.Find("Enemies").transform;
        EnemeisArr.Add(gamobj);
        //hideEnemiesMenu();
        increase1 += 1.3f;
    }
    public void instantiateGuard()
    {
        //Items[8].SetActive(true);
        GameObject gamobj = Instantiate(Items[8], new Vector3(Items[8].transform.position.x + increase2, Items[8].transform.position.y, Items[8].transform.position.z), Items[8].transform.rotation);
        gamobj.transform.parent = GameObject.Find("Enemies").transform;
        GaurdsArr.Add(gamobj);
        //hideEnemiesMenu();
        increase2 += 1.3f;

    }


    public void instantiateCrystalRed()
    {

        Items[0].SetActive(true);
        //gamobj = Instantiate(minerCrystalRed, GameObject.Find("respawn").transform.position, minerCrystalRed.transform.rotation);
        //gamobj.transform.parent = GameObject.Find("ResoursesRed").transform;
        //gamobj.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
        hideMinersMenu();

    }
    public void instantiateCrystalBlue()
    {
        Items[1].SetActive(true);
        hideMinersMenu();

    }
    public void instantiateIron()
    {
        Items[2].SetActive(true);
        hideMinersMenu();
    }
    public void instantiateGold()
    {
        Items[3].SetActive(true);
        hideMinersMenu();

    }



    public void instantiatetree()
    {
        Items[4].SetActive(true);
        hideMinersMenu();

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
