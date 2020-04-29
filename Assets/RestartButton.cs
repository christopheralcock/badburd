using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour
{

    public void RestartGame()
    {
        foreach (var music in MusicManager.musics)
        {
            Destroy(music);
        }

        SceneManager.LoadScene("MusicLoader");

        Debug.Log("You have clicked the button!");
    }
}
