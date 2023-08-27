using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayFPS : MonoBehaviour
{
    public int avgFrameRate;
    public TextMeshProUGUI display_Text;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}