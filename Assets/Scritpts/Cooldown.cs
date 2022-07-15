using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public float MaxSize = 100.0f;
    public float CooldownTime = 1.0f;
    private float CurrentSize = 0.0f;
    public bool isCountingDown = false;

    public RectTransform rt;
    public Image img;


    void Update()
    {
        if(isCountingDown)
        {
            if (CurrentSize < MaxSize)
            {
                CurrentSize += (MaxSize / CooldownTime) * Time.deltaTime;
                img.color = new Vector4(img.color.r, img.color.g, img.color.b, 255.0f);
            }
            else
            {
                img.color = new Vector4(img.color.r, img.color.g, img.color.b, 0.0f);
                isCountingDown = false;
            }
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, CurrentSize);

        }
    }

    public void StartCooldown()
    {
        CurrentSize = 0.0f;
        isCountingDown = true;
    }
}
