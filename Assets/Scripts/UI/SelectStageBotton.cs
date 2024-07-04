using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStageBotton : MonoBehaviour
{
    public StageData stageData;
    public void StartGame(string stageToPlay)
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
    }
}
