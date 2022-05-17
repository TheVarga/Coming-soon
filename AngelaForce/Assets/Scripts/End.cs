using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    public int LevelIndexToLoad;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        if (collision.gameObject.tag == "Player")
        {

            QuitGame();
            
        }
    }

    public void QuitGame()
    {

        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.Find("Canvas"));
        SceneManager.LoadScene(LevelIndexToLoad);
        
    }

    // Update is called once per frame

}
