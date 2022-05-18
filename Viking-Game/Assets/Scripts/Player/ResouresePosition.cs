using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouresePosition : MonoBehaviour
{

    [SerializeField]
    //Animator animator;
    public Transform[] CrystalRed;
    int index = 0;
    float speed = 2f;
    int stopTime = 300;

    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, CrystalRed[index].transform.position, 2f * Time.deltaTime);
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        if (index <= CrystalRed.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CrystalRed[index].transform.position, speed * Time.deltaTime);
            /*if (transform.position == CrystalRed[index].transform.position)
            {
                index += 1;
            }*/
        }
    }
   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Coll")
        {
            if (stopTime > 0)
            {
                Debug.Log("Stay - "+ gameObject.name+ " : "+ stopTime);
                //animator.SetBool("forword", false);
                //animator.SetBool("Cut", true);
                speed = 0f;
                stopTime -= 2;
            }
            else
            {

                //animator.SetBool("Cut", false);
                Destroy(CrystalRed[index].gameObject);

                index += 1;
                speed = 2f;
                stopTime = 300;
                //animator.SetBool("forword", true);
            }
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Coll")
        {
            index += 1;
            speed = 2f;
            stopTime = 5;

        }
    }
    */

}
