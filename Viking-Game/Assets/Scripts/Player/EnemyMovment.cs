using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

    int health = 200;

    Animator animator;
    public List<GameObject>  GaurdsArr = new List<GameObject>();

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GaurdsArr = GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr;

        if (health <= 0)
        {
           

        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "gaurd")
        {
            //animator.SetBool("Walk", false);
            //animator.SetBool("Hit1", true);
            if (health <= 0)
            {
               
               // collision.gameObject.GetComponent<GaurdMovent>().gauedSpeed = 2f;
            }
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "gaurdSward")
        {
            health -=20;
            if (health <= 0)
            {
                GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr.RemoveAt(0);

                GaurdsArr.ForEach(current =>
                {
                    current.gameObject.GetComponent<GaurdMovent>().gauedSpeed = 2f;

                });
                Destroy(gameObject);

            }

            print(health);
        }
    }
    
}
