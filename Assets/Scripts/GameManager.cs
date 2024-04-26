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
            //이미 생성되어있다면 새로 만든 거 삭제
            Destroy(this.gameObject);
        }
        //씬이 넘어가도 오브젝트 유지
        DontDestroyOnLoad(this.gameObject);
        #endregion

        grids = GameObject.FindGameObjectsWithTag("Grid");
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        board = new GameObject[grids.Length, grids.Length];
    }

    private void Start()
    {

        /*    
        foreach (GameObject t in tiles)
        {
            //Debug.Log(t.transform.position);
            Instantiate(candyPrefabs[Random.Range(0, candyPrefabs.Count)], t.transform.position, Quaternion.identity);
        }*/



        Debug.Log(board.GetLength(0));
        Debug.Log(board.GetLength(1));
        for(int i = 0; i < board.GetLength(0); i++)
        {
            for(int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = Instantiate(candyPrefabs[Random.Range(0, candyPrefabs.Count)], transform.position, Quaternion.identity);
            }
        }

        foreach(GameObject go in board)
        {
            Debug.Log(go.name);
        }

    }

}
