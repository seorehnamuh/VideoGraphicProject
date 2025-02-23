using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    
   private string gameSceneName; 
    void Start()
    {
        gameSceneName = "SampleScene";
    }
    void Update()
    {
        
    }


    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }   
}
