using LeaderboardCreatorDemo;
using SlimUI.ModernMenu;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    float time = 0;
    public Text startText;
    public Animator animator;

    public MovementScript playerMovement;
    public CameraMovement cameraMovement;
    public GameObject gameOver;

    public GameObject menu;
    public TMP_InputField inputField;

    bool state = true;

    public static float totalTime;


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            state = false;
            playerMovement.enabled = false;
            cameraMovement.enabled = false;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;

        }


        if (state)
        {
            time += Time.deltaTime;
            startText.text = (time).ToString("F1");
        }


        
    }



    public void reduceTime(float t)
    {
        time -= t;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().buildIndex < 4)
        {
            animator.Play("up");
            totalTime += time;
        }
        else
        {
            totalTime += time;
            state = false;
            playerMovement.enabled = false;
            cameraMovement.enabled = false;
            gameOver.SetActive(true);

            gameOver.transform.GetChild(2).GetComponent<TMP_Text>().text += totalTime.ToString("F1"); 

            Cursor.lockState = CursorLockMode.Confined;

            inputField.text = UIMenuManager.n;
            LeaderboardManager.UploadEntry(inputField , (int)totalTime);

        }

        
    }

    public void resume()
    {
        state = true;
        playerMovement.enabled = true;
        cameraMovement.enabled = true;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void exit()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
