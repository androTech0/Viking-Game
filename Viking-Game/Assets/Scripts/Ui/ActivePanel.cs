using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePanel : MonoBehaviour
{
    public GameObject panel;
    public void SetActive() {
        panel.SetActive(true);
    }

    public void SetDisActive()
    {
        panel.SetActive(false);
    }

}
