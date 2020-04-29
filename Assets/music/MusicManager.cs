using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static GameObject[] musics;

    public static string test;

    // Start is called before the first frame update
    void Start()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");


        foreach (GameObject music in musics)
        {

            DontDestroyOnLoad(music);
            if (music.name != "Level1Music")
            {
                music.GetComponents<AudioSource>()[0].volume = 0;
            }
        }

        SceneManager.LoadScene("Level1");
        test = "hello";

    }

}
