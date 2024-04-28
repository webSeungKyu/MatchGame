using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Vector3 offset;
    public Vector3 firstPos;

    void OnMouseDown()
    {
        // ���콺 Ŭ�� �� ���� ������Ʈ�� ���� ��ġ�� ���콺 �������� ��ġ ���� ���̸� ����Ͽ� ����
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        // ���콺 �巡�� �� ���ο� ��ġ ��� �� ����
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
        Debug.Log($"{gameObject.name}�� {collision.name}�� �浹�Ͽ� ��ġ ����");
        collision.transform.position = firstPos;
        gameObject.transform.position = collision.GetComponent<Candy>().firstPos;

    }


}
