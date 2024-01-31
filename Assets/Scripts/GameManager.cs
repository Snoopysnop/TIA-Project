using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public bool timerStarted;
    public TextMeshProUGUI timerText;
    // Variable to keep track of game time duration
    public float currentTime;
    public int imageTargetCounter;
    public TextMeshProUGUI imageTargetText;

    public void Awake()
    {
        if (GameManager.Manager != null)
        {
            Destroy(this);
        }
        Manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        timerStarted = false;
        imageTargetCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            currentTime += Time.deltaTime;
        }
    }

    public void IncrementImageTargetCounter()
    {
        // imageTargetCounter += 1;
    }

    public void DecrementImageTargetCounter()
    {
        // imageTargetCounter -= 1;
    }

    // StartGame starts timer and sets the number of Image Targets used
    public void StartGame()
    {
        timerStarted = true;

        GameObject[] imageTargets = GameObject.FindGameObjectsWithTag("ImageTarget");
        imageTargetCounter = imageTargets.Length;
    }

    public void StopTimer()
    {
        timerStarted = false;
        timerText.text = "Time: " + currentTime.ToString("00.000");
        imageTargetText.text = "Image Targets: " + imageTargetCounter;
    }
}
