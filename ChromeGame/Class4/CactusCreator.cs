using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusCreator : MonoBehaviour
{
    public GameObject[] cactusPrefabList;

    // Start is called before the first frame update
    void Start()
    {
        // Inputs are: Function name, Start in 1 sec, repeat rate is 2 sec
        InvokeRepeating("CreateCastus", 1, 2);
        //Invoke("CreateCastus", 5);
    }

    void CreateCastus()
    {

        // Instantiate(cactusPrefabList[0], transform.position, transform.rotation);
        // Instantiate(cactusPrefabList[1], transform.position, transform.rotation);
        // Instantiate(cactusPrefabList[2], transform.position, transform.rotation);

        // Debug.Log("List size is: " + cactusPrefabList.Length);

        // int randomInt = Random.Range(0, 3);

        int randomInt = Random.Range(0, cactusPrefabList.Length);
        Debug.Log("Random int value is: " + randomInt);

        Instantiate(cactusPrefabList[randomInt], transform.position, transform.rotation);
    }
}
