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

    public List<Transform> itemsToCollect = new List<Transform>();


    Animator animator;
    int index = 0;
    float speed = 3f;
    int stopTime = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        if (index <= rowResourses.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, rowResourses[index].transform.position, speed * Time.deltaTime);
            //animator.SetBool("Cut", true);
        }
        /*
        if (PlayerPrefs.GetInt("Done",0) == 1)
        foreach (Transform t in CrystalRed)
        {
            t.gameObject.SetActive(true);
        }
        */
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
                //CrystalRed[index].gameObject.SetActive(false);
                Destroy(rowResourses[index].gameObject);
                
                itemsToCollect.Add(Instantiate(toInstantiate, rowResourses[index].position, Quaternion.identity).transform);
                Debug.Log("finished");
                index += 1;
                speed = 3f;
                stopTime = 100;
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
