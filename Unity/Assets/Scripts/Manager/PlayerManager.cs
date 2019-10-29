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
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Player p = hit.transform.GetComponent<Player>();
                    if (p != selectedPlayer)
                        SelectPlayer(p);
                }
                else
                    DeselectPlayer();
            }
            
        }
        
        if (InputController.RightClick)
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

                    selectedPlayer.MovePlayer(gridPos);
                }
                if (hit.transform.CompareTag("Trial")  && selectedPlayer !=null)
                {
                    Vector3 positionToAccomplishDuty = Vector3.zero;

                    Mb_Trial  targetTrial = hit.transform.gameObject.GetComponent<Mb_Trial>();
                    if (targetTrial.listOfUser.Count > 0)
                    {
                        positionToAccomplishDuty = targetTrial.positionToGo[targetTrial.listOfUser.Count].position;
                    }
                    else
                    {
                        positionToAccomplishDuty = targetTrial.positionToGo[0].position;
                    }
                    selectedPlayer.MovePlayer(positionToAccomplishDuty);
                    selectedPlayer.SetNextInteraction(targetTrial);
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


}
