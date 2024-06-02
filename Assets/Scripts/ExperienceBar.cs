using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateExpSlider(int currrent, int target)
    {
        slider.maxValue = target;
        slider.value = currrent;
    }

    public void SetLevelText(int level)
    {
        levelText.text = "LEVEL: " + level.ToString();
    }
}
