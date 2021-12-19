using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform playerTransform;

    public GameObject pauseMenu;
    public bool isPaused;
    void Start()
    {
        playerTransform.position = spawnPoint.position;
        pauseMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>().PlayMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
