using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text comboText;
    [SerializeField] Text comboMultiText;
    [SerializeField] Text scoreText;
    [SerializeField] Text scorePlusText;

    private int comboCount = 0;
    private float comboTimer = 0f;
    private float comboDuration = 3f;
    private float scoreMultiplier = 1.1f;
    private int score = 0;

    void Update()
    {
        if (comboText != null)
        {
            comboMultiText.text = "+" + scoreMultiplier.ToString();
            comboText.text = comboCount.ToString() + " 연쇄";
        }

        if (scoreText != null)
        {
            scorePlusText.text = "+" + score;
            scoreText.text = "점수 " + score.ToString();
        }

        if (comboCount > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                ResetCombo();
            }
        }
    }

    public void OnFruitMerged(Fruit.Type fruitType)
    {
        UpdateCombo();
        UpdateScore(fruitType);
    }

    private void UpdateCombo()
    {
        if (comboTimer > 0)
        {
            comboMultiText.gameObject.SetActive(true);
            comboText.gameObject.SetActive(true);
            comboCount++;
            if (comboCount % 2 == 1) // 2번 증가할 때마다 0.1 배씩 증가
            {
                scoreMultiplier += 0.1f;
            }

            Debug.Log($"{comboCount} 콤보");
        }
        else
        {
            comboCount = 1;
            scoreMultiplier = 1.1f;
        }
        comboTimer = comboDuration;
    }

    private void UpdateScore(Fruit.Type fruitType)
    {
        scorePlusText.gameObject.SetActive(true);
        int points = 0;
        switch (fruitType)
        {
            case Fruit.Type.Blueberry:
                points = 1;
                break;
            case Fruit.Type.Strawberry:
                points = 2;
                break;
            case Fruit.Type.Durian:
                points = 3;
                break;
        }
        score += Mathf.CeilToInt(points * scoreMultiplier); // CeilToInt 올림
    }

    private void ResetCombo()
    {
        comboCount = 0;
        scoreMultiplier = 1.1f;
        comboTimer = 0f;

        comboMultiText.gameObject.SetActive(false);
        scorePlusText.gameObject.SetActive(false);
        comboText.gameObject.SetActive(false);
    }
}
