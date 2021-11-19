using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked; //Default value is false. False = lock
    public Image unlockImage;
    public GameObject[] stars;

    public Sprite StarSprite;

    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();

    }

    private void UpdateLevelStatus()
    {
        
        int previusLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previusLevelNum) > 0)
        {
            unlocked = true;
        }
        
    }

    private void UpdateLevelImage()
    {
        if (!unlocked) // if unlock is false means this level is locked
        {
            unlockImage.gameObject.SetActive(true);
            for(int i=0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else // if unlock is true means this level can play
        {
            unlockImage.gameObject.SetActive(false);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
            
            for(int i = 0; i< PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = StarSprite;
            }
        }
    }

    public void PressSelection(string _LevelName) //When we press this level, we can move to the corresponding scene to play
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }
}
