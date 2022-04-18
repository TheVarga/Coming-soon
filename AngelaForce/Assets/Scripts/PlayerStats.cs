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
        GameObject playerObject = GameObject.Find("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        playerOne.text = "Player(1) health: "
            + playerController.Health.ToString() + "/"
            + playerController.MaxHealth.ToString() + "<br>Player(1) points: " + playerController.Points;
    }   
    
}
