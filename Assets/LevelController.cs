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

    void OnEnable() {
        _enemies = FindObjectsOfType<Enemy>().ToList();
        bird = FindObjectOfType<Bird>();
        sceneName = SceneManager.GetActiveScene().name;
        levelNumber = Int32.Parse(sceneName.Replace("Level", ""));
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
            foreach (GameObject obj in MusicManager.musics)
            {
                if (obj.name == nextLevelName+"Music") {
                    currentMusicToRaise = obj.GetComponent<AudioSource>();
                    //obj.GetComponent<AudioSource>().volume = 1;
                        }
            }
        }
        if (currentMusicToRaise)
        {
            if (currentMusicToRaise.volume < 1)
            {
                currentMusicToRaise.volume = currentMusicToRaise.volume + 0.01f;
            }
        }

        if (bird.idle)
        {
            SceneManager.LoadScene(sceneName);
        }
}
}
