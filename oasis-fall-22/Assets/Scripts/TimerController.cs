using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private float turnTimeMax = 10f;

    private bool timerRunning;
    private float currentTime;

    private PlayerTest01 player;
    private Image timerContent;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = turnTimeMax;
        timerRunning = true;

        player = GameObject.Find("Player").GetComponent<PlayerTest01>();
        timerContent = transform.Find("TimerContent").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            SetTimer(Mathf.Max(currentTime - Time.deltaTime, 0));
            if (Mathf.Approximately(currentTime, 0f))
            {
                SetTimer(turnTimeMax);
                player.ExecuteTurn();
            }
        }
    }

    public void SetTimer(float t)
    {
        currentTime = t;
        timerContent.fillAmount = Mathf.Clamp(currentTime / turnTimeMax, 0f, 1f);
    }
}
