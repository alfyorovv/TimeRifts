using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level2 : MonoBehaviour
{
    private TimeController timeController;

    public GameObject wall;
    public Text hintText;

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }

    void Update()
    {
        if (timeController.currentTime == 0)
        {
            wall.SetActive(true);
            hintText.text = "Здесь стоит волк,может подождать когда он уйдет?";
        }

        else if (timeController.currentTime == 1)
        {
            wall.SetActive(true);
            hintText.text = "Здесь стоит волк,может подождать когда он уйдет?";
        }
        else
        {
            wall.SetActive(false);
            hintText.text = "Вышло! Волк ушел спать!";
        }


    }
}
