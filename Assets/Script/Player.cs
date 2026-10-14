using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float F_speed = 5f;      // 직진 속도
    public float S_speed = 1.25f;   // 양옆으로 이동속도

    public float SliceRange = 2f;   // 슬라이스 가능 사거리

    private void Update()
    {
        float SideKeyInput = Input.GetAxis("Horizontal");                   // A, D 키 입력받기
        Vector3 MOVE = new Vector3(SideKeyInput * S_speed, 0f, F_speed);    // 직진, 좌우 이동
        transform.Translate(MOVE * Time.deltaTime, Space.Self);             // 바라보는 방향으로 이동

        TrySliceFoodUnderMouse();
    }

    private void TrySliceFoodUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                                    // 카메라에서 마우스 커서 위치로 쏘는 광선 생성(평면에서 물체 부딛힘 감지용도)
        RaycastHit[] hits = Physics.RaycastAll(ray, 100f);                                              // 광선에 닿은 모든 물체 가져오기

        foreach (RaycastHit hit in hits)                                                                // 광선에 닿은 물체들을 하나씩 검사
        {
            if (!hit.collider.CompareTag("Food")) continue;                                             // Food 태그가 아니면 건너뛰기

            float distance = Vector3.Distance(transform.position, hit.collider.transform.position);     // 플레이어와 Food 사이의 거리 계산
            if (distance <= SliceRange)                                                                 // 슬라이스 가능 사거리 이내인지 판단
            {
                Destroy(hit.collider.gameObject);                                                       // Food 오브젝트 제거 (슬라이스)
                break;                                                                                  // 종료
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))  // 플레이어가 스파이크에 닿았는지 판단
        {
            Debug.Log("게임 오버!");
            SceneManager.LoadScene("GameOver");
        }
    }
}