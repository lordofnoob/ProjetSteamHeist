using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{

    public Color hoverColor;
    private Renderer rend;
    private Color startColor;

    public bool outlined = false;

    public int row, column;
    public float StraightLineDistanceToEnd, MinCostToStart;
    public bool Visited = false;
    public Tile previous;

    public object Connections { get; internal set; }

    public Tile(Vector3 position, float row, float column)
    {
        this.row = (int)row;
        this.column = (int)column;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        if (!(EventSystem.current.IsPointerOverGameObject()) && !outlined)
        {
            var outline = gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineColor = Color.black;
            outline.OutlineWidth = 7.5f;

        }
    }

    void OnMouseExit()
    {
        if(!outlined)
            Destroy(gameObject.GetComponent<Outline>());
    }

    public float StraightLineDistanceTo(Tile end)
    {
        //print((end.transform.position - transform.position).magnitude);
        return (end.transform.position - transform.position).magnitude;
    }

    public List<Tile> GetFreeNeighbours()
    {
        List<Tile> res = new List<Tile>();

        if(Manager.Instance.Grid.GetTile(row-1,column) is Free && row !=0)
        {
            res.Add(Manager.Instance.Grid.GetTile(row - 1, column));
        }

        if(Manager.Instance.Grid.GetTile(row+1,column) is Free && row != Manager.Instance.Grid.tilemap.GetLength(0))
        {
            res.Add(Manager.Instance.Grid.GetTile(row + 1, column));
        }

        if(Manager.Instance.Grid.GetTile(row,column-1) is Free && column != 0)
        {
            res.Add(Manager.Instance.Grid.GetTile(row, column-1));
        }

        if(Manager.Instance.Grid.GetTile(row,column+1) is Free && column != Manager.Instance.Grid.tilemap.GetLength(1))
        {
            res.Add(Manager.Instance.Grid.GetTile(row, column+1));
        }

        return res;
    }
}