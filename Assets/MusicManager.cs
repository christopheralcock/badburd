using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static Dictionary<string, AudioSource[]> musicDictionary = new Dictionary<string, AudioSource[]>();

    void Start()
    {

        AudioSource level1Music = GameObject.Find("Level1Music").GetComponent<AudioSource>();
        DontDestroyOnLoad(level1Music);
        AudioSource level2Music = GameObject.Find("Level2Music").GetComponent<AudioSource>();
        DontDestroyOnLoad(level2Music);
        AudioSource level3Music = GameObject.Find("Level3Music").GetComponent<AudioSource>();
        DontDestroyOnLoad(level3Music);
        AudioSource level4Music = GameObject.Find("Level4Music").GetComponent<AudioSource>();
        DontDestroyOnLoad(level4Music);


        AudioSource[] level1Musics = { level1Music };
        musicDictionary.Add("MusicLoader", level1Musics);
        musicDictionary.Add("Level1", level1Musics);
        AudioSource[] level2Musics = { level1Music, level2Music };
        musicDictionary.Add("Level2", level2Musics);
        AudioSource[] level3Musics = { level1Music, level2Music, level3Music };
        musicDictionary.Add("Level3", level3Musics);
        AudioSource[] level4Musics = { level1Music, level2Music, level3Music, level4Music };
        musicDictionary.Add("Level4", level4Musics);
        AudioSource[] level5Musics = { level1Music, level2Music, level3Music, level4Music };
        musicDictionary.Add("Level5", level5Musics);

        SceneManager.LoadScene("Level1");
    }
}
