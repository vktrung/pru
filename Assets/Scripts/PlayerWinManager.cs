using UnityEngine;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessagePanel;
    PauseManger pauseManger;
    [SerializeField] DataContainer dataContainer;
    [SerializeField] FlagsTable flagsTable;

    private void Start()
    {
        pauseManger = GetComponent<PauseManger>();
    }

    public void Win(string stageID)
    {
        winMessagePanel.SetActive(true);
        pauseManger.PauseGame();
        Flag flag = flagsTable.GetFlag(stageID);
        if (flag != null)
        {
            flag.state = true;
        }

    }
}
