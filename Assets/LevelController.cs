using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelController : MonoBehaviour
{
    List<Enemy> _enemies;
    Bird bird;
    string sceneName;
    static int levelNumber;
    static public AudioSource currentMusicToRaise;
    GameObject[] allMusicObjects;

    void Start() {
        _enemies = FindObjectsOfType<Enemy>().ToList();
        bird = FindObjectOfType<Bird>();
        sceneName = SceneManager.GetActiveScene().name;
        levelNumber = Int32.Parse(sceneName.Replace("Level", ""));
        allMusicObjects = GameObject.FindGameObjectsWithTag("Music");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in _enemies) {
            if (enemy == null) {
                _enemies.Remove(enemy);
            }
        }
        if (_enemies.Count == 0) {
            Debug.Log("You killed all the enemies");
            levelNumber++;
            var nextLevelName = "Level" + levelNumber;
            SceneManager.LoadScene(nextLevelName);

        }

        foreach (AudioSource music in MusicManager.musicDictionary[sceneName])
        {
            if (music.volume < 1)
            {
                music.volume = music.volume + 0.01f;
            }
        }

        foreach (GameObject musicObject in allMusicObjects)
        {
            var music = musicObject.GetComponent<AudioSource>();
            if (music.volume > 0 && !MusicManager.musicDictionary[sceneName].Contains<AudioSource>(music) )
            {
                music.volume = music.volume - 0.01f;
            }
        }


        if (bird.idle)
        {
            SceneManager.LoadScene(sceneName);
        }
}
}
