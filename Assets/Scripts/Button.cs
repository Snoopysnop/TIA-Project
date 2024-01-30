using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Test2 test2;
    public Test1 test1;
    public GameObject playGround;

    public void Click()
    {

        GameObject[] bouloute = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject go in bouloute)
        {
            go.SetActive(false);
        }

        List<GameObject> myList = test2.listOfObstacles;


        foreach (GameObject piv in myList)
        {
            Vector3 position = piv.transform.position;
            GameObject pivpiv = Instantiate(piv);
            pivpiv.transform.parent = playGround.transform;
            pivpiv.transform.position = position;
        }

        test1.AfficheNewElement();
    }
}
