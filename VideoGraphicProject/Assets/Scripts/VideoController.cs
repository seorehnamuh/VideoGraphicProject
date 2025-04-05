using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public string nextSceneName = "ExperienceScene"; // Sostituisci con il nome della scena di gioco
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd; // Quando il video finisce, cambia scena
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
