using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfObstacles;

    public void addToList(GameObject go) {
        listOfObstacles.Add(go);
    }

    // Start is called before the first frame update
    void Start()
    {
        listOfObstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(listOfObstacles[0] != null)
            Debug.Log(listOfObstacles[0].position);
    }
}
