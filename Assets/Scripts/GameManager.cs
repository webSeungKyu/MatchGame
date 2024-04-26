using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
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
        grids = grids.OrderBy(x => Convert.ToInt32(x.name.Replace("Grid_", ""))).ToArray();
        tiles = tiles.OrderBy(x => Convert.ToInt32(x.name.Replace("Tile_", ""))).ToArray();

        int temp = 0;
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for(int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = Instantiate(candyPrefabs[Random.Range(0, candyPrefabs.Count)], tiles[temp].transform.position, Quaternion.identity);
                temp++;
            }   
        }
    }

}
