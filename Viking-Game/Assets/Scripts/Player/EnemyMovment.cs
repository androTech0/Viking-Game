using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public List<GameObject> EnemeisArr, GaurdsArr = new List<GameObject>();
    public float enamySpeed = 2f;
    public float health = 100;
    Animator animator;
    int targetPosi = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        targetPosi = GaurdsArr.Count -1;
        attack();
        if (health <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr.RemoveAt(0);

            Destroy(gameObject);
        }
    }

    private void attack() {
        EnemeisArr = GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr;
        GaurdsArr = GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr;

       // enamySpeed = 2f;

        if (enamySpeed > 0 && GaurdsArr.Count > 0)
        {
            

            if (GaurdsArr.Count == EnemeisArr.Count)
            {
                targetPosi = GaurdsArr.Count - 1;

            }
            else if (GaurdsArr.Count <= EnemeisArr.Count)
            {
                bool isFound = false;
                for (int x = EnemeisArr.Count - 1; x >= 0; x--)
                {
                    if (x == GaurdsArr.Count)
                    {
                        for (int y = 1; y < x; y++)
                        {
                            int diff = EnemeisArr.Count - y;

                            if (diff == GaurdsArr.Count)
                            {
                                targetPosi = GaurdsArr.Count - y - 1;
                                isFound = true;
                                break;
                            }
                        }
                    }
                    if (isFound)
                    {
                        break;
                    }

                }
            }
            else if ( GaurdsArr.Count >= EnemeisArr.Count)
            {
                targetPosi = GaurdsArr.Count - 1;

            }

            animator.SetBool("Hit1", false);
            animator.SetBool("Walk", true);
            transform.position = Vector3.MoveTowards(transform.position, GaurdsArr[targetPosi].transform.position, enamySpeed * Time.deltaTime);

            //float angle = Quaternion.Angle(GaurdsArr[0].transform.rotation, transform.rotation);
            Quaternion desRotation = Quaternion.LookRotation(GaurdsArr[targetPosi].transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, desRotation.eulerAngles.y, 0), 2000 * Time.deltaTime);

        }
        else if (GaurdsArr.Count == 0)
        {
            animator.SetBool("Hit1", false);
            animator.SetBool("Walk", false);
            enamySpeed = 0;

        }



    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "gaurd")
        {
            enamySpeed = 0;

            animator.SetBool("Walk", false);
            animator.SetBool("Hit1", true);

        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "gaurdSward")
        {
            health -= 140 *Time.deltaTime ;
            if (health <= 0)
            {
                GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr.RemoveAt(0);

                GaurdsArr.ForEach(current =>
                {
                    current.gameObject.GetComponent<GaurdMovent>().gauedSpeed = 2f;

                });
                Destroy(gameObject);

            }

           // print(health);
        }
    }
    
}
