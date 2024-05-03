using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager Instance;
    //match�� ������ 6��
    public List<GameObject> candyPrefabs = new List<GameObject>();

    //8x8 ǥ���� / 8���̹Ƿ� 8��
    GameObject[] grids;
    //ǥ���� ���� Ÿ�� / 8�ٿ� 8�����̹Ƿ� 64��
    GameObject[] tiles;
    //match �������� ������ �迭
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
        //Grid �±� ã�Ƽ� �ֱ� (8��)
        grids = GameObject.FindGameObjectsWithTag("Grid");
        //Tile �±� ã�Ƽ� �ֱ� 64��
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        //match �������� ������ �迭 / 8x8
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
