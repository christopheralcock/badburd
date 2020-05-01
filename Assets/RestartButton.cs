using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("clicked restart button");
    }
}
