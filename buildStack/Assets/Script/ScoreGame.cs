using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGame : MonoBehaviour
{
    private int Score;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManager_OnCubeSawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSawned;
    }

   private void GameManager_OnCubeSawned()
    {
        Score++;
        text.text = "Score: " + Score;
    }
}
