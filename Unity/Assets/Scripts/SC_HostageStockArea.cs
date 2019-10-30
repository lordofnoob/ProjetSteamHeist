using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HostageStockArea : Mb_Trial
{

    private int areaCapacity = 0;
    //Dictionary des slots : true = free
    public Transform[] hostagesPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Counting();
    }

    public override void DoThings()
    {
        IAManager.Instance.StockHostagesInArea(this, listOfUser[0].capturedHostages);
        ResetValues();
    }
}
