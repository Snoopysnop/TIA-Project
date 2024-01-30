using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    public List<GameObject> obstacles;
    public PlaygroundObserverEventHandler playgroundObserverEventHandler;

    public void AddToList(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveFromList(GameObject go)
    {
        obstacles.Remove(go);
    }
    public void InstantiateObstacles()
    {
        foreach (GameObject obstacle in obstacles)
        {
            Vector3 position = obstacle.transform.position;
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.parent = transform;
            newObstacle.transform.position = position;
        }

        GameObject[] obstaclesImageTargets = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject go in obstaclesImageTargets)
        {
            go.SetActive(false);
        }

        playgroundObserverEventHandler.AddElement();
    }

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<GameObject>();
    }
}
