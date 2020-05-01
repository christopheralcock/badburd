using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoRestartToggleSwitch : MonoBehaviour
{
    public void AutoRestartToggle()
    {
        var musicManager = FindObjectOfType<MusicManager>();
        musicManager.autoRestart = !musicManager.autoRestart;
        Debug.Log("you toggled");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("you pressed the restart button");
    }
}
