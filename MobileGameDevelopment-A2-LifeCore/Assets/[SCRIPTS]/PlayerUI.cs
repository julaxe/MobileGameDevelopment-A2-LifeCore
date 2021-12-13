using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private GameObject HPText;
    private GameObject ScoreText;
    private Player PlayerRef;

    private void Start()
    {
        HPText = transform.Find("Canvas/HP").gameObject;
        ScoreText = transform.Find("Canvas/Score").gameObject;
        PlayerRef = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        HPText.transform.Find("Text1").GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + PlayerRef.hp;
        HPText.transform.Find("Text2").GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + PlayerRef.hp;
        ScoreText.transform.Find("Text1").GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + GameStatusSingleton.Instance.score;
        ScoreText.transform.Find("Text2").GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + GameStatusSingleton.Instance.score;
    }
}
