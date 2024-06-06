using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManger pauseManger;

    private void Awake()
    {
        pauseManger = GetComponent<PauseManger>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (panel.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void CloseMenu()
    {
        pauseManger.UnPauseGame();
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        pauseManger.PauseGame();
        panel.SetActive(true);
    }
}
