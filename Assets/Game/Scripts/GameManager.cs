using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isControllable;
    
    // Start is called before the first frame update
    void Start()
    {
        isControllable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isControllable = !isControllable;
        }
    }
}
