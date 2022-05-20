using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject minerCrystalRed, minerCrystalBlue, minerIron, minerGold, treeCutter, btnsMenu;

    [SerializeField]
    Text t1,t2,t3, t4, t5;

    [SerializeField]
    public Transform[] RedArrays;

    private void LateUpdate()
    {
        setValues();
    }

    public void showMenu()
    {
        if (btnsMenu.active)
        {
            btnsMenu.SetActive(false);
        }
        else
        {
            btnsMenu.SetActive(true);
        }
    }
    public void hideMenu()
    {
        btnsMenu.SetActive(false);
    }
    public void instantiateCrystalRed()
    {

        minerCrystalRed.SetActive(true);
        //gamobj = Instantiate(minerCrystalRed, GameObject.Find("respawn").transform.position, minerCrystalRed.transform.rotation);
        //gamobj.transform.parent = GameObject.Find("ResoursesRed").transform;
        //gamobj.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f); ;
        hideMenu();

    }
    public void instantiateCrystalBlue()
    {
        minerCrystalBlue.SetActive(true);
        hideMenu();

    }
    public void instantiateIron()
    {
        minerIron.SetActive(true);
        hideMenu();
    }
    public void instantiateGold()
    {
        minerGold.SetActive(true);
        hideMenu();

    }

    public void instantiatetree()
    {
        treeCutter.SetActive(true);
        hideMenu();

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
