using UnityEngine;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessagePanel;
    PauseManger pauseManger;
    [SerializeField] DataContainer dataContainer;

    private void Start()
    {
        pauseManger = GetComponent<PauseManger>();
    }

    public void Win(int stageID)
    {
        winMessagePanel.SetActive(true);
        pauseManger.PauseGame();
        dataContainer.StageComplete(stageID);
    }
}
