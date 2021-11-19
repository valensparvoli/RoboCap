using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    private int currentPointNum = 0;
    public int levelIndex;

    public void Points(int _pointNum)
    {
        currentPointNum = _pointNum;
        if(currentPointNum>PlayerPrefs.GetInt("Lv"+ levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _pointNum);
        }
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("00_LevelSelection00");
    }
}
