using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNetworkUI : MonoBehaviour
{
    public TowerNetworkManager tnm;

    public void TNMGoToNext()
    {
        tnm.GoToNext();
    }

    public void TNMGoToPrevious()
    {
        tnm.GoToPrevious();
    }
}
