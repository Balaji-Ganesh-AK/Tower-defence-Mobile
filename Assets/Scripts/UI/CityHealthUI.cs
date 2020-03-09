using UnityEngine;
using UnityEngine.UI;

public class CityHealthUI : MonoBehaviour
{
    public Text healthText;
    public Text ScoreText;
    public GameData gameData;
   
    public void SetHealthText(CityManager cm)
    {
        healthText.text = $"Health: {cm.HealthPercentage.ToString("0")}%";
    }
    public void Update()
    {
        SetScoreText();
    }

    public void SetScoreText()
    {
        Debug.Log(gameData.score);
        ScoreText.text = $"Score: {gameData.score.ToString() }";
    }
}
