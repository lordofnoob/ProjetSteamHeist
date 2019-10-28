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
            ModifyOutlines(Outlines.Mode.OutlineVisible, Color.black, 7.5f);
            SetOutlinesEnabled(true);

        }
    }

    void OnMouseExit()
    {
        if (!outlined)
            SetOutlinesEnabled(false);
    }

    public float StraightLineDistanceTo(Tile end)
    {
        //print((end.transform.position - transform.position).magnitude);
        return (end.transform.position - transform.position).magnitude;
    }

    public List<Tile> GetFreeNeighbours()
    {
        List<Tile> res = new List<Tile>();

        if(LevelManager.Instance.Grid.GetTile(row-1,column) is Free && row !=0)
        {
            res.Add(LevelManager.Instance.Grid.GetTile(row - 1, column));
        }

        if(LevelManager.Instance.Grid.GetTile(row+1,column) is Free && row != LevelManager.Instance.Grid.tilemap.GetLength(0))
        {
            res.Add(LevelManager.Instance.Grid.GetTile(row + 1, column));
        }

        if(LevelManager.Instance.Grid.GetTile(row,column-1) is Free && column != 0)
        {
            res.Add(LevelManager.Instance.Grid.GetTile(row, column-1));
        }

        if(LevelManager.Instance.Grid.GetTile(row,column+1) is Free && column != LevelManager.Instance.Grid.tilemap.GetLength(1))
        {
            res.Add(LevelManager.Instance.Grid.GetTile(row, column+1));
        }

        return res;
    }

    void ModifyOutlines(Outlines.Mode mode, Color color, float width)
    {
        Outlines outline = gameObject.GetComponent<Outlines>();
        outline.OutlineMode = mode;
        outline.OutlineColor = color;
        outline.OutlineWidth = width;
    }

    void SetOutlinesEnabled(bool enabled)
    {
        Outlines outline = gameObject.GetComponent<Outlines>();
        outline.enabled = enabled;
    }

}