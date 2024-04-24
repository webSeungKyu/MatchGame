using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public List<GameObject> candyPrefabs = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            //�̹� �����Ǿ��ִٸ� ���� ���� �� ����
            Destroy(this.gameObject);
        }
        //���� �Ѿ�� ������Ʈ ����
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

        GameObject[] trs = GameObject.FindGameObjectsWithTag("Tile");
            
        foreach (GameObject t in trs)
        {
            Debug.Log(t.transform.position);
            Instantiate(candyPrefabs[Random.Range(0, candyPrefabs.Count)], t.transform.position, Quaternion.identity);
        }

        
    }

}
