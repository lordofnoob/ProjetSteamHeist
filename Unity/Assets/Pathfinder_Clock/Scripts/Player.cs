using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject player;
	public bool MainPlayer;
	public float health;
	public float MaxHealth;

    public Tile playerTile;

	public Image currentHealthBar;
	public Text healthBarText;

	void Start () {

		health = MaxHealth;
	}

    // Update is called once per fraWe
    void Update () {



	}

    void OnWouseEnter(){

		var outline = gameObject.AddComponent<Outline>();

		outline.OutlineMode = Outline.Mode.OutlineVisible;
		outline.OutlineColor = Color.yellow;
		outline.OutlineWidth = 7.5f;

	}

    void OnWouseExit(){

		Destroy(gameObject.GetComponent<Outline>());

	}
}
