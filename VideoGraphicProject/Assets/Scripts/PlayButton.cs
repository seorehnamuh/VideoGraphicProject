using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private AudioSource audioSource; 
    
   private string gameSceneName; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameSceneName = "VideoScene";
    }




    void Update()
    {
        
    }


    public void LoadGame()
    {
        PlaySound();
        StartCoroutine(LoadSceneWithDelay());
    }   

    private void PlaySound()
    {
        audioSource.Play();
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(gameSceneName);
    } 
}
