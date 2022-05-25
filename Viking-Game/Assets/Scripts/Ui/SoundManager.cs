using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider gameVolumeSlider;
    [SerializeField] Slider playVolumeSlider;
    [SerializeField] string type;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("GameVolume", 1);
        PlayerPrefs.SetFloat("PlayVolume", 1);
        LoadVolume();
        if (type == "play") {
            ChangeVolume2();
        } else if (type == "game") {
            ChangeVolume1();
        }
    }

    public void ChangeVolume1() {
        AudioListener.volume = gameVolumeSlider.value;
    }

    public void ChangeVolume2()
    {
        AudioListener.volume = playVolumeSlider.value;
    }

    public void LoadVolume() { 
        gameVolumeSlider.value = PlayerPrefs.GetFloat("GameVolume");
        playVolumeSlider.value = PlayerPrefs.GetFloat("PlayVolume");
        
    }

    public void SaveVolume() {
        PlayerPrefs.SetFloat("GameVolume", gameVolumeSlider.value);
        PlayerPrefs.SetFloat("PlayVolume", playVolumeSlider.value);
        LoadVolume();
        if (type == "play")
        {
            ChangeVolume2();
        }
        else if (type == "game")
        {
            ChangeVolume1();
        }
    }
}
