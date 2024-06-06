using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBotton : MonoBehaviour
{

    public void StartGame(string stageToPlay)
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
    }


}
