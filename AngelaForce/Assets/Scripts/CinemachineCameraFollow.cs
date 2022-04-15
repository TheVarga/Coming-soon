using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineCameraFollow : MonoBehaviour
{

    public GameObject Player;
    public Transform FollowTarget;
    
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (Player == null) {
            Player = GameObject.FindWithTag("Player");
            //Debug.Log("Found ya");
        }
       
        vcam.Follow = Player.transform;
    }


    
}
