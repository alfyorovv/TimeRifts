using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level4 : MonoBehaviour
{
    private TimeController timeController;

    public GameObject water;
    public Text hintText;

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }

    void Update()
    {
        if (timeController.currentTime == 0)
        {
            water.SetActive(true);
            hintText.text = "����� ����� ����,����� ��������� ����� �� �����?";
        }

        else if (timeController.currentTime == 1)
        {
            water.SetActive(true);
            hintText.text = "����� ����� ����,����� ��������� ����� �� �����?";
        }
        else
        {
            water.SetActive(false);
            hintText.text = "�����! ���� ���� �����!";
        }


    }
}
