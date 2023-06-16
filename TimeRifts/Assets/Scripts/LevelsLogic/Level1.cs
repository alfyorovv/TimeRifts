using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level1 : MonoBehaviour
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
            wall.SetActive(false);
            hintText.text = "�������������,������ ������!";
        }

        else
        {
            wall.SetActive(true);
            hintText.text = "����� ����� �����.�������� ,������ �� ����� �� ����.";
        }


    }
}
