using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouresePosition : MonoBehaviour
{

    //[SerializeField]
    List<Transform> rowResourses = new List<Transform>();
   // Transform[] rowResourses;
    [SerializeField]
    GameObject toInstantiate;

   //[SerializeField]
   // GameObject EventSystem;

    [SerializeField]
    Transform lastt;

    public List<Transform> itemsToCollect = new List<Transform>();


    Animator animator;
    //int index = 0;
    public float speed = 3f;
    int stopTime = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    [Obsolete]
    private void Update()
    {
        movePlayer();
        
    }

    [Obsolete]
    private void movePlayer()
    {
        rowResourses = GameObject.Find("EventSystem").GetComponent<UiManager>().RedResourses;

        if (rowResourses.Count > 0 )
        {
            
            transform.position = Vector3.MoveTowards(transform.position, rowResourses[0].transform.position , speed * Time.deltaTime);
            //animator.SetBool("Cut", true);

        }/*
        else if (index <= rowResourses.Count - 1 && rowResourses[index] == null) {
            index += 1;
        }*/

    }

    public void reActiveAll()
    {
        foreach (Transform t in rowResourses)
        {
            t.gameObject.SetActive(true);
        }
        
        //gameObject.SetActive(false);
       // gameObject.SetActive(true);
        
        //Destroy(gameObject);
        //Instantiate(gameObject);
        
    }




    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "RawResources")
        {
            if (stopTime > 0)
            {
                //Debug.Log("Stay - "+ gameObject.name+ " : "+ stopTime);
                //animator.SetBool("Cut", true);
                //animator.SetBool("forword", false);
                speed = 0f;
                stopTime -= 2;
            }
            else
            {

                // animator.SetBool("Cut", false);
                // animator.SetBool("forword", true);


                itemsToCollect.Add(Instantiate(toInstantiate, rowResourses[0].position, Quaternion.identity).transform);
                rowResourses[0].gameObject.SetActive(false);
                rowResourses.RemoveAt(0);

                if ( rowResourses.Count  == 0)
                {
                    transform.position = lastt.transform.position;
                    speed = 0f;
                    
                }
                else
                {
                    speed = 3f;
                    stopTime = 100;
                }

                
            }
        }

      
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "RowResources")
        {
            Debug.Log("Exit");
        }

    }
}
