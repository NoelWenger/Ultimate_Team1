using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerCardUI : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI rarityText;
    public Image playerImage;

    public void SetPlayer(PlayerData player)
    {
        playerNameText.text = player.name;
        rarityText.text = player.rarity;

        // Optional: Platzhalterbild oder Farbe setzen, falls kein Bild vorhanden
        playerImage.sprite = null;
        playerImage.color = Color.gray;
    }
}
