using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private IDamageble PlayerHp;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _livesText;
    [SerializeField] GameObject restarBut;
    private int score;
    void Start()
    {
        EventSystemScript.OnEnemyDie.AddListener(UpScore);
        PlayerHp = Player.GetComponent<IDamageble>();
        if (PlayerHp == null)
        { Debug.LogError("Not found player HP"); }
    }
    void FixedUpdate()
    {
        if (PlayerHp != null)
        {
            float lives = PlayerHp.Health;
            _livesText.text = "Lives: " + lives.ToString();
        }
        else
        {
            _livesText.text = "Lives: 0";
            Debug.Log("Lost PlayerHp", transform);
            Time.timeScale = 0;
            restarBut.SetActive(true);
        }
        
    }
    public void UpScore(int Bonus)
    {
        score += Bonus;
        _scoreText.text = "Score: " + score.ToString();
    }

    void OnDestroy()
    {
        EventSystemScript.OnEnemyDie.RemoveListener(UpScore);
    }
}
