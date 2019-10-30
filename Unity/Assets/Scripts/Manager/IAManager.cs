using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    public static IAManager Instance;

    public List<Sc_IAHostage> IAList = new List<Sc_IAHostage>();
    public List<Mb_Trial> HostageArea = new List<Mb_Trial>();

    public float repeatActionInterval = 3f;
    private float timer = 0;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(timer >= repeatActionInterval)
        {
            foreach(Sc_IAHostage IACharacter in IAList)
            {
                IACharacter.RandomMovement();
            }
            timer = 0f;
        }
        timer += Time.deltaTime;*/
        UpdateHostageStress();
    }

    public void IAHostageFollowingPlayer(Sc_IAHostage hostage, Player p)
    {
        hostage.target = p;
        p.capturedHostages.Add(hostage);
        hostage.state = HostageState.Captured;
    }

    public void StockHostagesInArea(SC_HostageStockArea area, List<Sc_IAHostage> hostages)
    {
        List<Sc_IAHostage> stockedHosteges = new List<Sc_IAHostage>();
        foreach(Sc_IAHostage hostage in hostages)
        {
            foreach (Transform position in area.hostagesPos)
            {
                if (position.GetComponent<Mb_PositionCheck>().dispo)
                {
                    position.GetComponent<Mb_PositionCheck>().dispo = false;

                    hostage.state = HostageState.Stocked;                    
                    hostage.target = null;
                    stockedHosteges.Add(hostage);
                    hostage.agent.SetDestination(position.position);
                    hostage.agent.stoppingDistance = 0f;
                    break;
                }
            }
        }
        foreach(Sc_IAHostage stockedHostege in stockedHosteges)
            hostages.Remove(stockedHostege);
        
    }

    void UpdateHostageStress()
    {
        foreach(Sc_IAHostage hostage in IAList)
        {
            hostage.stress += Random.Range(0.01f, 0.1f) * Time.deltaTime;
        }
    }
}
