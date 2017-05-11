using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private float initialTime;
    private float currentTime;
    private Text timerText;
    private Transform newSpawnPosition;
    public Transform boxSpawnPoint;
    public GameObject[] boxes;

    // Use this for initialization
    void Start () {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        initialTime = Time.time;

        if (boxSpawnPoint == null)
            Debug.LogError("BOXSPAWNPOINT is missing");
        else
            newSpawnPosition = boxSpawnPoint;

        GenerateBox();
    }
	
	// Update is called once per frame
	void Update () {
        CheckEndGame();
        RunTimer();
    }

    private void GenerateBox()
    {
        int boxIndex = UnityEngine.Random.Range(0, boxes.Length);
        float xBoxPosition = boxSpawnPoint.position.x;
        float zBoxPosition = boxSpawnPoint.position.z;

        newSpawnPosition.position = new Vector3(xBoxPosition, boxSpawnPoint.position.y, zBoxPosition);
        Instantiate(boxes[boxIndex], newSpawnPosition);

        Invoke("GenerateBox", 20);
    }

    private void CheckEndGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || GameObject.FindGameObjectWithTag("Box") == null)
            RestartGame();
    }

    private void RunTimer()
    {
        currentTime = Time.time - initialTime;
        timerText.text = currentTime.ToString("#.##");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Stage01");
    }
}
