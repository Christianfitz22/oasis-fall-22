using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStatDisplay : MonoBehaviour
{
    private static GameObject enemyPanel;
    private static TMP_Text enemyStatText;


    // Start is called before the first frame update
    void Start()
    {
        enemyPanel = GameObject.Find("EnemyStatPanel");
        enemyStatText = enemyPanel.transform.Find("StatValues").gameObject.GetComponent<TMP_Text>();
        enemyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Display(string input)
    {
        enemyPanel.SetActive(true);
        enemyStatText.SetText(input);
    }

    public static void HideDisplay()
    {
        enemyPanel.SetActive(false);
    }
}
