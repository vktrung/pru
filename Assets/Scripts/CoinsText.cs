using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] DataContainer datacontainer;
    TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Coins:" + datacontainer.coins.ToString();
    }
}
