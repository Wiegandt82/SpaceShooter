using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadSceneDelay = 1.0f;
    [SerializeField] ParticleSystem crashParticle;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSeequence();
    }

    void StartCrashSeequence()
    {

        GetComponent<PlayerControl>().enabled = false;
        Invoke("ReloadLevel", loadSceneDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
