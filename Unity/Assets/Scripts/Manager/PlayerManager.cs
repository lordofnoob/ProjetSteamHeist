using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerManager Instance;

    public Sc_InputController InputController;
    public Camera cam;

    public Player selectedPlayer = null;
    public int TickPerTileSpeed = 4;

    void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (InputController.LeftClick)
        {
            if (!(EventSystem.current.IsPointerOverGameObject()))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Tile"))
                    {
                        //print("Go to" + hit.transform.position);
                        List<Tile> ShortestPath = LevelManager.Instance.pathfinder.SearchForShortestPath(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerTile, hit.transform.GetComponent<Tile>());
                        foreach (Tile tile in ShortestPath)
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
                    else if (hit.transform.CompareTag("Player"))
                    {
                        //SelectPlayer(Player p);
                    }
                }
            }
        }
    }

    public void SelectPlayer(Player p)
    {
        selectedPlayer = p;
    }

    public void MovePlayer(List<Tile> path)
    {
        print("Move");
        LevelManager.Instance.clock.AddActionToPerform(new Sc_Deplacement(TickPerTileSpeed, GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(), path));
    }
}
