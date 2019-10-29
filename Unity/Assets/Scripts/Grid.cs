using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public List<Tile> freeTiles = new List<Tile>();
    public Tile[,] tilemap = new Tile[20,20];

    public void BuildGridLevel(string[,] array)
    {
        Vector3 position = Vector3.zero;
        Tile newTile = null;

        for(int row = 1; row <= array.GetLength(0); row++)
        {
            for(int column = 1; column <= array.GetLength(1); column++)
            {
                //print(position +" : ["+row+","+column+"]");
                switch (array[row-1,column-1])
                {
                    case "W":
                        GameObject newWall = Instantiate(LevelManager.Instance.WallPrefab, position, new Quaternion(0f, 0f, 0f, 0f), GameObject.Find("Wall").transform);
                        newTile = newWall.GetComponent<Wall>();
                        newTile.row = row;
                        newTile.column = column;
                        break;

                    case "F":
                        GameObject newFree = Instantiate(LevelManager.Instance.FreePrefab, position, new Quaternion(0f, 0f, 0f, 0f), GameObject.Find("Tile").transform);
                        newTile = newFree.GetComponent<Free>();
                        newTile.row = row;
                        newTile.column = column;
                        freeTiles.Add(newTile);
                        break;

                    case "P":
                        GameObject newFreePlayer = Instantiate(LevelManager.Instance.FreePrefab, position, new Quaternion(0f, 0f, 0f, 0f), GameObject.Find("Tile").transform);
                        newTile = newFreePlayer.GetComponent<Free>();
                        newTile.row = row;
                        newTile.column = column;
                        //Spawn player
                        GameObject player = Instantiate(LevelManager.Instance.PlayerPrefab, new Vector3(position.x, 0.5f, position.z), new Quaternion(0f, 0f, 0f, 0f));
                        player.GetComponent<Player>().playerTile = newTile;
                        freeTiles.Add(newTile);
                        break;

                    case "IA":
                        GameObject newFreeIA = Instantiate(LevelManager.Instance.FreePrefab, position, new Quaternion(0f, 0f, 0f, 0f), GameObject.Find("Tile").transform);
                        newTile = newFreeIA.GetComponent<Free>();
                        newTile.row = row;
                        newTile.column = column;
                        //Spawn player
                        GameObject IA = Instantiate(LevelManager.Instance.IAPrefab, new Vector3(position.x, 0.5f, position.z), new Quaternion(0f, 0f, 0f, 0f));
                        IA.GetComponent<Sc_IAOstage>().IATile = newTile;
                        IAManager.Instance.IAList.Add(IA.GetComponent<Sc_IAOstage>());
                        freeTiles.Add(newTile);
                        break;
                }

                SetTileInTilemap(newTile, row, column);

                if (column != 20)
                    position.z += LevelManager.Instance.FreePrefab.transform.localScale.x;
                else
                    position.z = 0;
            }
            position.x += LevelManager.Instance.FreePrefab.transform.localScale.x;
        }
    }

    public void SetTileInTilemap(Tile tile, int row, int column)
    {
        tilemap[row - 1, column - 1] = tile;
    }

    public Tile GetTile(int row, int column)
    {
        //print(row + " , " + column);
        return tilemap[row - 1, column - 1];
    }

    public void ResetVisitedTile()
    {
        foreach(Tile tile in freeTiles)
        {
            if (tile.Visited)
                tile.Visited = false;
        }
    }
}
