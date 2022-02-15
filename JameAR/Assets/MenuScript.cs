using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    string firstScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(firstScene);
    }

    public void Exit()
    {
        Application.Quit(0);
    }
}
