using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;         // Awake함수를 사용하기위해 초기화, 어디서든 사용가능하게 공용으로 지정

    public int score = 0;                       // 점수
    public int FoodScore = 2;                   // Food 하나를 자를 때 얻는 점수

    private void Awake()
    {
        if (Instance == null)                   // GameManager가 없다면
        {
            Instance = this;                    // 자기 자신을 등록
        }
        else                                    // 이미 있다면
        {
            Destroy(gameObject);                // 중복 생성 방지를 위해 제거
        }
    }

    public void AddScore(int amount)            // 점수 추가 함수
    {
        score += amount;
        Debug.Log("점수: " + score);
    }
}