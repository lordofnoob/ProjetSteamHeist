using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject player;
	public bool isSelected { 
        set
        {
            switch (value)
            {
                case true:
                    ModifyOutlines(Outlines.Mode.OutlineVisible, Color.yellow, 7.5f);
                    SetOutlinesEnabled(true);
                    break;
                case false:
                    SetOutlinesEnabled(false);
                    break;
            }
        }
        get
        {
            return gameObject.GetComponent<Outlines>().enabled;
        }
    }

    public Tile playerTile;

	void Start () 
    {

	}

    // Update is called once per fraWe
    void Update () 
    {

	}

    void OnMouseEnter()
    {
        isSelected = true;
    }

    void OnMouseExit()
    {
        if (!isSelected)
            isSelected = true;
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
