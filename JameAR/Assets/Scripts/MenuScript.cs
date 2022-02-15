using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    string firstScene;

    public void Play()
    {
        SceneManager.LoadSceneAsync(firstScene);
    }

    public void Exit()
    {
        Application.Quit(0);
    }
}
