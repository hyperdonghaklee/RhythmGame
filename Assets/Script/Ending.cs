using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text scoreText;                                                  // 결과 점수 표시 텍스트

    private void Start()
    {
        if (scoreText != null && GameManager.Instance != null)              // 존재 여부 확인
        {
            scoreText.text = "최종 점수: " + GameManager.Instance.score;    // 
        }
    }
}
