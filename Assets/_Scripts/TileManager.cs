using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileManager : MonoBehaviour
{
    private Queue<GameObject> m_TilePool;

    public int MaxTiles;

    // Start is called before the first frame update
    void Start()
    {
        // init tilepool
        m_TilePool = new Queue<GameObject>();
        _BuildTilePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void _BuildTilePool()
    {
        for (var count = 0; count < MaxTiles; count++) 
        {
            // Enqueue new tile from factory
            var tempTile = TileFactory.Instance().CreateTile(new Vector3());
            tempTile.SetActive(false);
            m_TilePool.Enqueue(tempTile);
        }
    }

    /// <summary>
    /// Removes a GameObject tile form the pool
    /// </summary>
    /// <returns></returns>
    public GameObject GetTile()
    {
        var tempTile = m_TilePool.Dequeue();
        tempTile.SetActive(true);
        return tempTile;
    }

    /// <summary>
    /// Returns GameObject tile to the pool
    /// </summary>
    /// <param name="tile"></param>
    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        m_TilePool.Enqueue(tile);
    }


}
