using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdMovent : MonoBehaviour
{
    public List<GameObject> EnemeisArr, GaurdsArr = new List<GameObject>();
    public float gauedSpeed = 2f;
    int health = 200;
    Animator animator;
    bool isHealing = false;
    int targetPosi = 0;
    int myPosi = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
        myPosi = GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.Count - 1 ;
    }

    void Update()
    {
        targetPosi = EnemeisArr.Count - 1;
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

        if (gauedSpeed > 0 && EnemeisArr.Count > 0)
        {
            
            if (EnemeisArr.Count == GaurdsArr.Count)
            {
                targetPosi = EnemeisArr.Count - 1;
                
            }
            else if (EnemeisArr.Count <= GaurdsArr.Count)
            {
                bool isFound = false;
                for (int x = GaurdsArr.Count-1; x >= 0; x--)
                {
                    if (x == EnemeisArr.Count) {
                        for (int y = 1; y <= x; y++) {
                            int diff = GaurdsArr.Count-y;
                            if (diff == EnemeisArr.Count) {
                                targetPosi = EnemeisArr.Count - y - 1;
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
            
            isHealing = false;
            animator.SetBool("Hit1", false);
            animator.SetBool("Walk", true);
            transform.position = Vector3.MoveTowards(transform.position, EnemeisArr[targetPosi].transform.position, gauedSpeed * Time.deltaTime);


            //float angle = Quaternion.Angle(EnemeisArr[0].transform.rotation, transform.rotation);
            Quaternion desRotation = Quaternion.LookRotation(EnemeisArr[targetPosi].transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, desRotation.eulerAngles.y, 0), 2000 * Time.deltaTime);


        }
        else if (EnemeisArr.Count == 0)
        {
            print("null");
            if (health < 200 && !isHealing)
            {
                GameObject gmobj = GameObject.Find("EventSystem").GetComponent<UiManager>().Items[9];
                animator.SetBool("Hit1", false);
                animator.SetBool("Walk", true);
                transform.position = Vector3.MoveTowards(transform.position, gmobj.gameObject.transform.position, gauedSpeed * Time.deltaTime);


                //float angle = Quaternion.Angle(EnemeisArr[0].transform.rotation, transform.rotation);
                Quaternion desRotation = Quaternion.LookRotation(gmobj.transform.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, desRotation.eulerAngles.y, 0), 2000 * Time.deltaTime);

            }
        }

    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "enemySward")
        {
            health -= 30;
            if (health <= 0)
            {
                GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.RemoveAt(0);

                EnemeisArr.ForEach(current =>
                {
                    current.gameObject.GetComponent<EnemyMovment>().enamySpeed = 2f;

                });
                Destroy(gameObject);

            }

            print(health);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gauedSpeed = 0;

            isHealing = false;
            animator.SetBool("Walk", false);
            animator.SetBool("Hit1", true);

        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Hit1", false);
            gauedSpeed = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medic") {
            health = 200;
            isHealing = true;
        }   
    }

}
