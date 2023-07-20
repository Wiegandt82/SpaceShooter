using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadSceneDelay = 5.0f;
    [SerializeField] ParticleSystem crashVFX;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSeequence();
    }

    void StartCrashSeequence()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        Invoke("ReloadLevel", loadSceneDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
