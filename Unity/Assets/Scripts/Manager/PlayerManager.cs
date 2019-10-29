using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    PlayerManager Instance;

    public Sc_InputController InputController;

    public Player selectedPlayer = null;
    public int TickPerTileSpeed = 4;

    void Awake()
    {

    }

    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (InputController.LeftClick)
        {
            Ray ray = CameraManager.Instance.mainCam.ScreenPointToRay(Input.mousePosition);
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
            Ray ray = CameraManager.Instance.mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Tile") && selectedPlayer != null && selectedPlayer.state != Player.StateOfAction.Captured)
                {
                    hit.point += new Vector3(LevelManager.Instance.FreePrefab.transform.localScale.x / 2, 0f, LevelManager.Instance.FreePrefab.transform.localScale.x / 2);

                    Vector3 gridPos = Vector3.zero;
                    gridPos.x = Mathf.Floor(hit.point.x / LevelManager.Instance.FreePrefab.transform.localScale.x) * LevelManager.Instance.FreePrefab.transform.localScale.x;
                    gridPos.z = Mathf.Floor(hit.point.z / LevelManager.Instance.FreePrefab.transform.localScale.x) * LevelManager.Instance.FreePrefab.transform.localScale.x;

                    selectedPlayer.MovePlayer(gridPos);
                    selectedPlayer.state = Player.StateOfAction.Moving;
                }
                else if (hit.transform.CompareTag("Trial")  && selectedPlayer !=null && selectedPlayer.state != Player.StateOfAction.Captured && selectedPlayer.state!= Player.StateOfAction.Interacting)
                {
                    Vector3 positionToAccomplishDuty = Vector3.zero;

                    Mb_Trial  targetTrial = hit.transform.gameObject.GetComponent<Mb_Trial>();

                    if (targetTrial.listOfUser.Count>0)
                        for (int i =0; i< targetTrial.listOfUser.Count; i++)
                        {
                            if (targetTrial.listOfUser[i] != selectedPlayer)
                            {
                                positionToAccomplishDuty = targetTrial.positionToGo[targetTrial.listOfUser.Count].position;
                            }
                        }
                    else
                        positionToAccomplishDuty = targetTrial.positionToGo[targetTrial.listOfUser.Count].position;

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
