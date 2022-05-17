using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{
    public int LevelIndexToLoad;
    public int NextLevelReq;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        if (collision.gameObject.tag == "Player") {
            if (playerController.Points >= NextLevelReq)
            {
                DontDestroyOnLoad(GameObject.Find("Sounds"));
                DontDestroyOnLoad(GameObject.Find("Canvas"));

                LoadScene();
            }
        }
    }

   // if (collision.gameObject.name == "Player")
    void LoadScene() {
        SceneManager.LoadScene(LevelIndexToLoad);
    }
}
