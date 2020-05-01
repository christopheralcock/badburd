using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelController : MonoBehaviour
{
    List<Enemy> enemies;
    Bird bird;
    string sceneName;
    static int levelIndex;
    static public AudioSource currentMusicToRaise;
    static public string[] levelList = {"MusicLoader", "Level1", "Level2", "Level3", "Level4", "EndScreen" };

    void Start() {
        sceneName = SceneManager.GetActiveScene().name;
        levelIndex = Array.IndexOf(levelList, sceneName);

        if (sceneName != "EndScreen")
        {
            enemies = FindObjectsOfType<Enemy>().ToList();
            bird = FindObjectOfType<Bird>();
        }
    }

    void Update()
    {
        if (sceneName != "EndScreen")
        {
            var autoRestart = FindObjectOfType<MusicManager>().autoRestart;
            // Restart if bird is marked idle
            if (bird && bird.idle && autoRestart)
            {
                SceneManager.LoadScene(sceneName);
            }
            // If all enemies nullified, Load next level
            if (!enemies.Any((arg) => arg))
            {
                Debug.Log("You killed all the enemies");
                levelIndex++;
                SceneManager.LoadScene(levelList[levelIndex]);
            }
        }
        // Turn up the right soundtrack elements
        foreach (AudioSource music in MusicManager.musicDictionary[sceneName])
        {
            if (music.volume < 1)
            {
                music.volume = music.volume + 0.01f;
            }
        }

        // Turn down the wrong soundtrack elements
        foreach (GameObject musicObject in MusicManager.allMusicObjects)
        {
            var music = musicObject.GetComponent<AudioSource>();
            if (music.volume > 0 && !MusicManager.musicDictionary[sceneName].Contains<AudioSource>(music) )
            {
                music.volume = music.volume - 0.01f;
            }
        }
        }
}
