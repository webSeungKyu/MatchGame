using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        // ���콺 Ŭ�� �� ���� ������Ʈ�� ���� ��ġ�� ���콺 �������� ��ġ ���� ���̸� ����Ͽ� ����
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        // ���콺 �巡�� �� ���ο� ��ġ ��� �� ����
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = newPosition;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    

}
