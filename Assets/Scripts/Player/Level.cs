using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int exp = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpGradePanelManager upgradePanel;
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExpSlider(exp, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        exp += amount;
        CheckLevelUp();
        experienceBar.UpdateExpSlider(exp, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if (exp >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        upgradePanel.OpenPanel();
        exp -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }
}
