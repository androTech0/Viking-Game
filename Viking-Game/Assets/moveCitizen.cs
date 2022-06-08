using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCitizen : MonoBehaviour
{
    public List<Transform> paths;
    public bool access,isBusy = false;
    int last = 0;
    int ran = 1;


    // Update is called once per frame
    void Update()
    {
        if (!isBusy)
        {
            if (!access)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(paths[ran].position.x, 1f, paths[ran].position.z - 0.80f), 9f * Time.deltaTime);
                last = ran;

            }
            else
            {
                ran = Random.Range(0, 3);
                access = false;
            }
        }
        else
        {
            moveToWeapensMaker();
        }
            
        
    }

    public void moveToWeapensMaker()
    {

        GameObject mm = GameObject.Find("EventSystem").GetComponent<UiManager>().Items[18];

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(mm.transform.position.x, 1f, mm.transform.position.z), 6f * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
                if (!isBusy)
        {
            if (collision.gameObject.tag == "citizenStation")
            {

                access = true;

            }
        }

        if (collision.gameObject.tag == "WeapansMaker")
        {
            print("OnTriggerEnter");

            GameObject.Find("EventSystem").GetComponent<UiManager>().instantiateGuard();
            Destroy(gameObject);
        }
    }


}
