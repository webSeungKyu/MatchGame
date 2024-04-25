using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public List<GameObject> candyPrefabs = new List<GameObject>();

    GameObject[] grids;
    GameObject[] tiles;
    GameObject[,] board;

    private void Awake()
    {
        #region Instance
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
        #endregion

        grids = GameObject.FindGameObjectsWithTag("Grid");
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        board = new GameObject[grids.Length, grids.Length];
    }

    private void Start()
    {

            
        foreach (GameObject t in tiles)
        {
            //Debug.Log(t.transform.position);
            Instantiate(candyPrefabs[Random.Range(0, candyPrefabs.Count)], t.transform.position, Quaternion.identity);
        }



        Debug.Log(board.GetLength(0));
        Debug.Log(board.GetLength(1));
    }

}
