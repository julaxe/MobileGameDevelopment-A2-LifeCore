using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreText = transform.Find("Score/Text").GetComponent<TextMeshProUGUI>();
        ScoreText.text = GameStatusSingleton.Instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
