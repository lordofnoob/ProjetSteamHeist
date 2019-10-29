﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    public Scriptable_Charaspec characterProperty;
	public Player player;
    public Color highlightedColor, selectedColor;

    public bool highlighted = false;
    [SerializeField]private bool isSelected = false;
    [SerializeField] NavMeshAgent agent;
    public bool IsSelected { 
        set
        {
            switch (value)
            {
                case true:
                    isSelected = true;
                    ModifyOutlines(Outlines.Mode.OutlineAll, selectedColor, 7.5f);
                    SetOutlinesEnabled(true);
                    break;
                case false:
                    isSelected = false;
                    SetOutlinesEnabled(false);
                    break;
            }
        }
        get
        {
            return isSelected;
        }
    }

    public Tile playerTile;

    // nextInteractionToussa
    private Vector3 positionToGo;
    float distanceRemaining;
    Mb_Trial onGoingInteraction;

	void Start () 
    {

	}

    // Update is called once per fraWe
    void Update () 
    {
        CheckingDistance();
    }

    void OnMouseEnter()
    {
        highlighted = true;
        ModifyOutlines(Outlines.Mode.OutlineVisible, highlightedColor, 7.5f);
        SetOutlinesEnabled(true);
    }

    void OnMouseExit()
    {
        if (IsSelected)
        {
            ModifyOutlines(Outlines.Mode.OutlineVisible, selectedColor, 7.5f);
        }
        else
        {
            SetOutlinesEnabled(false);
        }
        highlighted = false;
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

    public void MovePlayer(Vector3 endPos)
    {
        agent.SetDestination(endPos);
        //uniquement pour la next interaction n influe pas sur le deplacement whatsoever
        positionToGo = endPos;
    }

    public void Interact()
    {
        onGoingInteraction.listOfUser.Add(player);
        onGoingInteraction.StartInteracting();
    }

    void CheckingDistance()
    {
        if (Vector3.Distance(transform.position, positionToGo) <= agent.stoppingDistance && onGoingInteraction !=null)
        {
            Interact();
        }
    }

    public void ResetInteractionParameters()
    {
        onGoingInteraction = null;
        distanceRemaining = 0;
        positionToGo = transform.position;
    }




    public void SetNextInteraction(Mb_Trial trialToUse)
    {
        onGoingInteraction = trialToUse;
    }
}