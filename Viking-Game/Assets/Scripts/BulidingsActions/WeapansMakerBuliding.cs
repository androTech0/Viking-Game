using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapansMakerBuliding : MonoBehaviour
{
    float swordCounter = 1f;
    float hammerCounter = 1f;
    float sheildCounter = 1f;
    float axeCounter = 2f;
    float pickaxeCounter = 2f;

    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        print("counter = " + swordCounter);
        if (swordCounter > 0.0f && PlayerPrefs.GetInt("Iron") >= 5)
        {
            swordCounter -= Time.deltaTime;
            print("counter = "+ swordCounter);
        }
        else if (swordCounter == 0.0f) {
            PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") - 5);
            PlayerPrefs.SetInt("Swords", PlayerPrefs.GetInt("Swords") + 1);
            swordCounter = 2f;
        }

        if (hammerCounter > 0.0f && PlayerPrefs.GetInt("Iron", 0) >= 5)
        {
            hammerCounter -= Time.deltaTime;
        }
        else if (hammerCounter == 0.0f)
        {
            PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") - 5);
            PlayerPrefs.SetInt("Hammers", PlayerPrefs.GetInt("Hammers") + 1);
            hammerCounter = 2f;
        }

        if (sheildCounter > 0.0f && PlayerPrefs.GetInt("Iron", 0) >= 5)
        {
            sheildCounter -= Time.deltaTime;
        }
        else if (sheildCounter == 0.0f)
        {
            PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") - 5);
            PlayerPrefs.SetInt("Shields", PlayerPrefs.GetInt("Shields") + 1);
            sheildCounter = 2f;
        }
        
    }
}
