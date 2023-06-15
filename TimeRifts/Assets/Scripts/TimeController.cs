using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    


public class TimeController : MonoBehaviour
{
    public Sprite[] backgrounds;
    public Button pastButton, perestButton, futureButton;
    public GameObject currentBackground;

    public void Settime(int time)
    {
        currentBackground.GetComponent<SpriteRenderer>().sprite = backgrounds[time];
    }    
}
