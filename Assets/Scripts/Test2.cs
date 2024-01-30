using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public List<GameObject> listOfObstacles;

    public void AddToList(GameObject go) {
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
        // if(listOfObstacles != null && listOfObstacles.Count != 0)
        //    Debug.Log(listOfObstacles[0].transform.position);
    }
}
