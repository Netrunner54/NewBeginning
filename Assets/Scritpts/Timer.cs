using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = ((float)(Mathf.Round(time * 100f) / 100f)).ToString() + "s";
    }
}
