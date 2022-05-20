using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouresePosition : MonoBehaviour
{

    [SerializeField]
    Transform[] rowResourses;

    [SerializeField]
    GameObject toInstantiate;

   // [SerializeField]
   // GameObject contnetObj;

    [SerializeField]
    Transform lastt;

    public List<Transform> itemsToCollect = new List<Transform>();


    Animator animator;
    int index = 0;
    float speed = 3f;
    int stopTime = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
        //rowResourses = contnetObj.GetComponent<UiManager>().RedArrays;
    }

    [Obsolete]
    private void Update()
    {
        movePlayer();
        
    }

    [Obsolete]
    private void movePlayer()
    {
        if (index <= rowResourses.Length - 1 )
        {
            
            transform.position = Vector3.MoveTowards(transform.position, rowResourses[index].transform.position , speed * Time.deltaTime);
            //animator.SetBool("Cut", true);

        }
        else if (index <= rowResourses.Length - 1 && rowResourses[index] == null) {
            index += 1;
        }

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


                itemsToCollect.Add(Instantiate(toInstantiate, rowResourses[index].position, Quaternion.identity).transform);
                rowResourses[index].gameObject.SetActive(false);

                index += 1;

                if (index == rowResourses.Length)
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
