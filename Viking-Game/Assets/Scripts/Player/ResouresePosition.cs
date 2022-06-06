using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouresePosition : MonoBehaviour
{

    
    public List<Transform> rowResourses;
    int index = 0;
    [SerializeField]
    GameObject toInstantiate;
    Animator animator;

    [SerializeField]
    Transform lastt;

    public List<Transform> itemsToCollect = new List<Transform>();

    float speed = 3f;
    int stopTime = 200;
    bool isMinning = false;

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

        if (rowResourses.Count > 0 )
        {
            if (rowResourses[index].transform.gameObject.active) {
                speed = 3f;
                transform.position = Vector3.MoveTowards(transform.position, rowResourses[index].transform.position, speed * Time.deltaTime);
                if (!isMinning)
                {
                    animator.SetBool("forword", true);
                }
            }
            
        }

    }

    public void reActiveAll()
    {
        foreach (Transform t in rowResourses)
        {
            t.gameObject.SetActive(true);
        }
        index = 0;
        
    }




    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "RawResources")
        {
            
            if (stopTime > 0)
            {
                animator.SetBool("forword", false);
                animator.SetBool("Minning", true);
                isMinning = true;
                speed = 0f;
                stopTime -= 2;
            }
            else
            {

                 animator.SetBool("Minning", false);
                 animator.SetBool("forword", true);

                itemsToCollect.Add(Instantiate(toInstantiate, rowResourses[index].position, Quaternion.identity).transform);
                rowResourses[index].gameObject.SetActive(false);
                index += 1;

                if (index == rowResourses.Count)
                {
                    transform.position = lastt.transform.position;
                    speed = 0f;
                    animator.SetBool("Minning", false);
                    animator.SetBool("forword", false);
                    index = 0;
                }
                else
                {
                    speed = 3f;
                    stopTime = 100;
                    animator.SetBool("Minning", false);
                    animator.SetBool("forword", true);
                }

                isMinning = false;

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
