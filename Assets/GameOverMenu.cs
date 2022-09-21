using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {

    }

    public void SelectRestart()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
