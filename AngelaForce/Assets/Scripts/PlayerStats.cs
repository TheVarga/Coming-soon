using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    private TextMeshProUGUI playerOne;
    
    
    private void Start()
    {
        playerOne = GameObject.Find("Player1Stats").GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(GameObject.Find("Canvas"));
    }
    void Update()
    {
        if(GameObject.FindWithTag("Player") != null){ 
        GameObject playerObject = GameObject.FindWithTag("Player");//GameObject.Find("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        playerOne.text = "Player health: "
            + playerController.Health.ToString() + "/"
            + playerController.MaxHealth.ToString() + "<br>Player points: " + playerController.Points;
        }
    }   
    
}
