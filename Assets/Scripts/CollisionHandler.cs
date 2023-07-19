using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{  
    void OnTriggerEnter(Collider other)
    {
        startCrashSeequence();
    }

    void startCrashSeequence()
    {
        SceneManager.LoadScene(1);
    }
}
