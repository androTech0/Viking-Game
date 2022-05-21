using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

    public List<GameObject> EnemeisArr, GaurdsArr = new List<GameObject>();
    float speed = 2f;
    int stopTime = 300;

    void Update()
    {
        
        attack();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "gaurd")
        {
            if (stopTime > 0)
            {
                speed = 0f;
                stopTime -= 2;
            }
            else
            {
                Destroy(GaurdsArr[0]);
                GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.RemoveAt(0);
                stopTime = 300;
                speed = 2f;
            }
        }
    }

    private void attack()
    {

        EnemeisArr = GameObject.Find("EventSystem").GetComponent<UiManager>().EnemeisArr;
        GaurdsArr = GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr;

        if (EnemeisArr.Count > 0 && GaurdsArr.Count > 0)
        {
            
            if (GaurdsArr[0] == null)
            {
               // GameObject.Find("EventSystem").GetComponent<UiManager>().GaurdsArr.RemoveAt(0);
               // GaurdsArr.RemoveAt(0);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, GaurdsArr[0].transform.position, speed * Time.deltaTime);
            }

        }

    }

}
