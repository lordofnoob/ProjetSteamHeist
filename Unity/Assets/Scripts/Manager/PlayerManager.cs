using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

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
                    if (hit.transform.CompareTag("Tile") && selectedPlayer != null)
                    {
                        hit.point += new Vector3(LevelManager.Instance.FreePrefab.transform.localScale.x / 2, 0f, LevelManager.Instance.FreePrefab.transform.localScale.x / 2);

                        Vector3 gridPos = Vector3.zero;
                        gridPos.x = Mathf.Floor(hit.point.x / LevelManager.Instance.FreePrefab.transform.localScale.x) * LevelManager.Instance.FreePrefab.transform.localScale.x;
                        gridPos.z = Mathf.Floor(hit.point.z / LevelManager.Instance.FreePrefab.transform.localScale.x) * LevelManager.Instance.FreePrefab.transform.localScale.x;

                        MovePlayer(selectedPlayer, gridPos);
                    }
                    else if (hit.transform.CompareTag("Player"))
                    {
                        Player p = hit.transform.GetComponent<Player>();
                        if (p != selectedPlayer)
                            SelectPlayer(p);
                        else
                            DeselectPlayer();
                    }
                }
            }
        }
    }

    public void SelectPlayer(Player p)
    {
        Debug.Log("SELECT PLAYER");
        if (selectedPlayer != null)
            selectedPlayer.IsSelected = false;
        selectedPlayer = p;
        p.IsSelected = true;
    }

    public void DeselectPlayer()
    {
        Debug.Log("DESELECT PLAYER");
        selectedPlayer.IsSelected = false;
        selectedPlayer = null;
    }

    public void MovePlayer(Player p, Vector3 endPos)
    {
        print("Move");
        p.transform.GetComponent<NavMeshAgent>().SetDestination(endPos);
        //selectedPlayer.isSelected = false;
        //selectedPlayer = null;
    }
}
