﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] public bool autoRestart = true;

    public static Dictionary<string, List<AudioSource>> musicDictionary = new Dictionary<string, List<AudioSource>>();
    public static GameObject[] allMusicObjects;
    Dictionary<string, List<string>> musicStringDictionary = new Dictionary<string, List<string>>(){
            {"Level1", new List<string>(){ "Level1Music" } },
            {"Level2", new List<string>(){ "Level1Music", "Level2Music" } },
            {"Level3", new List<string>(){ "Level1Music", "Level2Music", "Level3Music" } },
            {"Level4", new List<string>(){ "Level1Music", "Level2Music", "Level3Music", "Level4Music" } },
            {"EndScreen", new List<string>(){ "Level2Music", "Level3Music", "Level4Music" } }
            };

    private void Start()
    {
        allMusicObjects = GameObject.FindGameObjectsWithTag("Music");
        CreateMusicDictionary();
        SetUIToNotDestroy();
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Level1");
    }

    private void CreateMusicDictionary()
    {
        foreach (var levelMusicConfig in musicStringDictionary)
        {
            var audioSourceList = new List<AudioSource>();

            foreach (var obj in levelMusicConfig.Value)
            {
                var audioSource = GameObject.Find(obj).GetComponent<AudioSource>();
                audioSourceList.Add(audioSource);
                DontDestroyOnLoad(audioSource);
            }
            musicDictionary.Add(levelMusicConfig.Key, audioSourceList);
        }
    }

    private void SetUIToNotDestroy()
    {
        var uiStuff = GameObject.FindGameObjectsWithTag("UI");
        foreach (var ui in uiStuff)
        {
            Debug.Log("found a UI thing to mark safe:" + ui.ToString() + ui.name);
            DontDestroyOnLoad(ui);
        }
    }
}
