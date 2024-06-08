using UnityEngine;

public class PauseManger : MonoBehaviour
{
    private void Start()
    {
        UnPauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }
}
