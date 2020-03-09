using UnityEngine;
using UnityEngine.UI;

public class MoneyButton : MonoBehaviour
{
    public Text text;

    public GameObject moneyImage;

    public void ToggleMoneyImage()
    {
        moneyImage.SetActive(!moneyImage.activeSelf);
        text.text = moneyImage.activeSelf ? "Close" : "Customization";
    }
}
