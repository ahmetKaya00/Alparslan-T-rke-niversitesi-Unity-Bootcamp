using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeRespawn : MonoBehaviour
{
    [SerializeField] private MovingController cubePrefab;
    [SerializeField] private MoveDirection moveDirection;

    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);

        if (MovingController.LastCube != null && MovingController.LastCube.gameObject != GameObject.Find("Start"))
        {
            float x = moveDirection == MoveDirection.X ? transform.position.x : MovingController.LastCube.transform.position.x;
            float z = moveDirection == MoveDirection.Z ? transform.position.z : MovingController.LastCube.transform.position.z;

            cube.transform.position = new Vector3(x, MovingController.LastCube.transform.position.y + cubePrefab.transform.localScale.y,z);
        }
        else
        {
            cube.transform.position = transform.position;
        }
        cube.MoveDirection = moveDirection;
    }
}

public enum MoveDirection { X,Z }
