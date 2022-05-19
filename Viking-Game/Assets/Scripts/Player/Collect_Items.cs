using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Items : MonoBehaviour
{
    [SerializeField]
    Transform Path;
    [SerializeField]
    GameObject Miner;
    [SerializeField]
    GameObject Repository;
    [SerializeField]
    string nameOfResourses;
    public List<Transform> itemsToCollect;

    Animator animator;
    float speed = 5f;
    int index = 0;

    bool pickedUp = false;
    bool go = true;
    bool back = false;
    bool iss = true;

    void Update()
    {
        
        collectItems();

    }

    private void collectItems()
    {

            itemsToCollect = Miner.GetComponent<ResouresePosition>().itemsToCollect;


        if (itemsToCollect.Count > 0 && itemsToCollect.Count <= 12 && !pickedUp)
        {
            if (go) {
                transform.position = Vector3.MoveTowards(transform.position, Path.position, speed * Time.deltaTime);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, itemsToCollect[index].transform.position, speed * Time.deltaTime);
            }
        }
        else if (pickedUp) {
            if (back)
            {
                transform.position = Vector3.MoveTowards(transform.position, Repository.transform.position, speed * Time.deltaTime);
                itemsToCollect[index].transform.position = transform.position;

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Path.position, speed * Time.deltaTime);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Repository")
        {
            print("Repository");
            PlayerPrefs.SetInt(nameOfResourses, PlayerPrefs.GetInt(nameOfResourses, 0) + 10);
            Destroy(itemsToCollect[index].gameObject);
            index += 1;
            pickedUp = false; 
            go = true;
            back = false;

        }

        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectables")
        {
            pickedUp = true;
        }

        if (collision.gameObject.tag == "cube")
        {
            if (!pickedUp)
            {
                go = false;
            }
            else
            {
                back = true;
            }

        }
    }
}
