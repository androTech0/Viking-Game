using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    [SerializeField]
    int type;
    Image m_Image;
    float maxHealth = 100;
    float currentHealth;
    EnemyMovment enemy;
    GaurdMovent gaurd;



    void Start()
    {

        m_Image = GetComponent<Image>();

        if (type == 0)
        {
            enemy = FindObjectOfType<EnemyMovment>();

        }else if (type == 1)
        {

            gaurd = FindObjectOfType<GaurdMovent>();

        }
    }

    void Update()
    {
        if (type == 0)
        {
            currentHealth = enemy.health;

        }
        else
        {
            currentHealth = gaurd.health;
        }
        if(m_Image != null)
        m_Image.fillAmount = currentHealth / maxHealth;


    }
}
