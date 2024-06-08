using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManger pauseManger;

    [SerializeField] GameWinPanel levelCompletePanel;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManger = FindObjectOfType<PauseManger>();
        levelCompletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    private void Update()
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            pauseManger.PauseGame();
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}
