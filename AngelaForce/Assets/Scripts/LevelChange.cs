using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{
    public int LevelIndexToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            DontDestroyOnLoad(GameObject.Find("Sounds"));
            LoadScene();
        }
    }

   // if (collision.gameObject.name == "Player")
    void LoadScene() {
        SceneManager.LoadScene(LevelIndexToLoad);
    }
}
