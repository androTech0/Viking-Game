using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdMovent : MonoBehaviour
{
    public List<GameObject> EnemeisArr, GaurdsArr = new List<GameObject>();
    public float gauedSpeed = 2f;
    int health = 400;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        attack();
        if (health <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.RemoveAt(0);

            Destroy(gameObject);
        }
    }


    private void attack()
    {

        EnemeisArr = GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr;
        GaurdsArr = GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr;

        if (EnemeisArr.Count > 0 && GaurdsArr.Count > 0)
        {

            if (EnemeisArr[0] == null)
            {
                // GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.RemoveAt(0);
                // GaurdsArr.RemoveAt(0);
            }
            else
            {
                if (gauedSpeed > 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, EnemeisArr[0].transform.position, gauedSpeed * Time.deltaTime);
                    animator.SetBool("Hit1", false);
                    animator.SetBool("Walk", true);
                }
            }

        }

    }
    /*

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "enemySward")
        {
            print(trigger.gameObject.tag);
            
            health -= 20;
        }
    }
    */

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gauedSpeed = 0;


                animator.SetBool("Walk", false);
                animator.SetBool("Hit1", true);

        }
        else
        {
            gauedSpeed = 2;
        }
    }

}
