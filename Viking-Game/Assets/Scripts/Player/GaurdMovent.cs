using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdMovent : MonoBehaviour
{
    public List<GameObject> EnemeisArr, GaurdsArr = new List<GameObject>();
    public float gauedSpeed = 2f;
    public float health = 100;
    Animator animator;
    bool isHealing = false;
    int targetPosi = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetBool("swardAttack", false);
            animator.SetBool("shieldAttack", false);
            animator.SetBool("Walk", true);
            transform.position = Vector3.MoveTowards(transform.position, EnemeisArr[targetPosi].transform.position, gauedSpeed * Time.deltaTime);


            //float angle = Quaternion.Angle(EnemeisArr[0].transform.rotation, transform.rotation);
            Quaternion desRotation = Quaternion.LookRotation(EnemeisArr[targetPosi].transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, desRotation.eulerAngles.y, 0), 2000 * Time.deltaTime);


        }
        else if (EnemeisArr.Count == 0)
        {
            if (health < 100 && !isHealing)
            {
                gauedSpeed = 2;
                animator.SetBool("swardAttack", false);
                animator.SetBool("shieldAttack", false);
                animator.SetBool("Walk", true);

                GameObject gmobj = GameObject.Find("EventSystem").GetComponent<UiManager>().Items[9];
                transform.position = Vector3.MoveTowards(transform.position, gmobj.gameObject.transform.position, gauedSpeed * Time.deltaTime);


                //float angle = Quaternion.Angle(EnemeisArr[0].transform.rotation, transform.rotation);
                Quaternion desRotation = Quaternion.LookRotation(gmobj.transform.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, desRotation.eulerAngles.y, 0), 2000 * Time.deltaTime);

            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gauedSpeed = 0;

            isHealing = false;

            int ran = Random.Range(0, 2);
            print(ran);
            if (ran == 0)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("shieldAttack", false);
                animator.SetBool("swardAttack", true);
            }
            else if (ran == 1)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("swardAttack", false);
                animator.SetBool("shieldAttack", true);
            }

        }/*
        else
        {
            gauedSpeed = 2;
            //animator.SetBool("Walk", false);
            animator.SetBool("swardAttack", false);
            animator.SetBool("shieldAttack", false);
        }*/
    }


    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "enemySward" || trigger.gameObject.tag == "enemyShield")
        {

            int damage = 0;
            if (trigger.gameObject.tag == "enemySward")
            {
                damage = 180;
            }
            else if (trigger.gameObject.tag == "enemyShield")
            {
                damage = 140;
            }

            health -= damage * Time.deltaTime ;

            if (health < 20)
            {
                animator.SetBool("Die", true);
            }

            if (health <= 0)
            {
                GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.RemoveAt(0);

                EnemeisArr.ForEach(current =>
                {
                    current.gameObject.GetComponent<EnemyMovment>().enamySpeed = 2f;

                });
                Destroy(gameObject);

            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medic") {
            health = 100;
            isHealing = true;
        }   
    }

}
