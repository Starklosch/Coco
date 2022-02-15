using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    KeyCode pauseKey;
    [SerializeField]
    GameObject pauseScreen;

    bool pause = false;
    TarodevController.PlayerController controller;
    InteractionManager im;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<TarodevController.PlayerController>();
        im = GetComponent<InteractionManager>();

        UpdateScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            pause = !pause;

            UpdateScreen();
        }
    }

    void UpdateScreen()
    {
        if (pause)
        {
            pauseScreen.SetActive(true);
            controller.enabled = false;
            im.enabled = false;
        }
        else
        {
            pauseScreen.SetActive(false);
            controller.enabled = true;
            im.enabled = true;
        }
    }

    public void Continue()
    {
        pause = false;

        UpdateScreen();
    }

    public void Exit()
    {
        Application.Quit(0);
    }
}
