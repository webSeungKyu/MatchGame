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
            //이미 생성되어있다면 새로 만든 거 삭제
            Destroy(this.gameObject);
        }
        //씬이 넘어가도 오브젝트 유지
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
