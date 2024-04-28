using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Vector3 offset;
    public Vector3 firstPos;

    void OnMouseDown()
    {
        // 마우스 클릭 시 게임 오브젝트의 현재 위치와 마우스 포인터의 위치 간의 차이를 계산하여 저장
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        // 마우스 드래그 시 새로운 위치 계산 후 적용
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = newPosition;
    }

    
    void Start()
    {
        firstPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{gameObject.name}는 {collision.name}과 충돌하여 위치 변경");
        collision.transform.position = firstPos;
        gameObject.transform.position = collision.GetComponent<Candy>().firstPos;

    }


}
