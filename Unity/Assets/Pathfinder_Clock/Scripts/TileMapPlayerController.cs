using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TileMapPlayerController : MonoBehaviour {

	public Camera cam;
	public CameraController camController;

    void Awake()
    {
        cam = FindObjectOfType<Camera>();
        camController = cam.GetComponent<CameraController>();
    }

	void Update () {
		if(Input.GetMouseButtonDown(0)){

			if (!(EventSystem.current.IsPointerOverGameObject()))
            {
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit)){
					if(!(hit.transform.CompareTag("mur")))
                    {
                        //print("Go to" + hit.transform.position);
                        List<Tile> ShortestPath = LevelManager.Instance.pathfinder.SearchForShortestPath(gameObject.GetComponent<Player>().playerTile, hit.transform.GetComponent<Tile>());
                        foreach(Tile tile in ShortestPath)
                        {
                            Outlines outline;
                            if (tile.GetComponent<Outlines>() == null)
                                outline = tile.gameObject.AddComponent<Outlines>();
                            else
                                outline = tile.GetComponent<Outlines>();

                            outline.OutlineMode = Outlines.Mode.OutlineVisible;
                            outline.OutlineColor = Color.red;
                            outline.OutlineWidth = 7.5f;
                            tile.outlined = true;
                        }

                        MovePlayer(ShortestPath);
                    }
				}
			}
		}
	}

    public void MovePlayer(List<Tile> path)
    {
        foreach(Tile tile in path)
        {
            LevelManager.Instance.clock.AddActionToPerform("Move to [" + tile.column + ", " + tile.row + "]");
        }
    }
}
