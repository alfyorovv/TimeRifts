using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnblockLevels : MonoBehaviour
{
    public Button[] levelsButtons;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < levelsButtons.Length; i++) 
        {
            if(PlayerPrefs.GetInt("currentLevel") >= i)
            {
                levelsButtons[i].interactable = true;
            }
        }
    }
}
