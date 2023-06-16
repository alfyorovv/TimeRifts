using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    


public class TimeController : MonoBehaviour
{
    public Sprite[] backgrounds;
    public Button pastButton, presentButton, futureButton;
    public GameObject currentBackground;
    public int currentTime = 1; //0-past 1-present 2-furute

    public void Settime(int time) //0-past 1-present 2-furute
    {
        currentTime = time;
        currentBackground.GetComponent<SpriteRenderer>().sprite = backgrounds[currentTime];
    }    

}
