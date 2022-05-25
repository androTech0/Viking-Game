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
    float referech = 2f;
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
            referech -= Time.deltaTime;
        }
        if (referech <= 0.0)
        {
            GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr.RemoveAt(0);
            Destroy(gameObject);
        }
        
    }

    private void attack() {
        EnemeisArr = GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr;
        GaurdsArr = GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr;

        


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

            animator.SetBool("swardAttack", false);
            animator.SetBool("shieldAttack", false);
            animator.SetBool("Walk", true);
            transform.position = Vector3.MoveTowards(transform.position, GaurdsArr[targetPosi].transform.position, enamySpeed * Time.deltaTime);

            //float angle = Quaternion.Angle(GaurdsArr[0].transform.rotation, transform.rotation);
            Quaternion desRotation = Quaternion.LookRotation(GaurdsArr[targetPosi].transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, desRotation.eulerAngles.y, 0), 2000 * Time.deltaTime);

        }
        else if (GaurdsArr.Count == 0)
        {
            enamySpeed = 2f;
            animator.SetBool("swardAttack", false);
            animator.SetBool("Walk", false);
            animator.SetBool("shieldAttack", false);
            

        }



    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "gaurd")
        {
            enamySpeed = 0;
            int ran = Random.Range(0, 2);

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
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "gaurdSward" || trigger.gameObject.tag == "gaurdShield" || trigger.gameObject.tag == "guardHammer")
        {
            int damage = 0;
            if (trigger.gameObject.tag == "gaurdSward")
            {
                damage = 140;
            }
            else if (trigger.gameObject.tag == "gaurdShield")
            {
                damage = 100;
            }
            else if (trigger.gameObject.tag == "guardHammer")
            {
                damage = 200;
            }
            health -= damage * Time.deltaTime ;
 
            if (health <= 0)
            {
                animator.SetBool("Die", true);

                for (int x = 0; x < GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.Count; x++)
                {
                    GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr[x].GetComponent<GaurdMovent>().gauedSpeed = 2f;

                }
                
            }

            
        }
    }
    
}
