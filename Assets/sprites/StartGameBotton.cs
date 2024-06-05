using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBotton : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlayStage");
    }


}
