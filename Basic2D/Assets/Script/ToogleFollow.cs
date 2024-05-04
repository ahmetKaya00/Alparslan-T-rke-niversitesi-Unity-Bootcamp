using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleFollow : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject Player1, Player2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            VirtualCamera.Follow = Player1.transform;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            VirtualCamera.Follow = Player2.transform;

        }
    }
}
