using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayInterface : MonoBehaviour
{
    public CharacterController character;
    public TextMeshProUGUI Lives;
    public Cooldown cooldown;

    void Update()
    {
        if (false)
        {
            Lives.text = character.life.ToString();
        }
    }

    public void StartCooldown()
    {
        cooldown.StartCooldown();
    }

    public bool IsOnCooldown()
    {
        return !cooldown.isCountingDown;
    }
}
