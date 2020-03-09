using UnityEngine;
using UnityEngine.Events;

public class TowerNetworkManager : MonoBehaviour
{
    TrackedLinkedList<GameObject> towers = new TrackedLinkedList<GameObject>();

    [System.Serializable]
    public class TowerChangedEvent : UnityEvent<string, GameObject> { }

    /// <summary>
    /// Fires whenever the selected tower is changed. The string sent is either
    /// "next" or "previous", depending on the direction moved.
    /// </summary>
    public TowerChangedEvent OnTowerChange;

    /// <summary>
    /// Retrieves the currently selected tower.
    /// </summary>
    public GameObject CurrentTower
    {
        get => towers.CurrentValue;
    }

    public void Start()
    {
        foreach (Transform child in transform)
        {
            towers.Add(child.gameObject);
        }
        // If we have towers already, set the first to be active
        towers.CurrentValue?.SetActive(true);
#if UNITY_EDITOR
        Debug.Log($"Current tower is {towers.CurrentValue}");
#endif
    }

    /// <summary>
    /// Sets the current tower to be the next one in the list.
    /// </summary>
    public void GoToNext()
    {
        towers.GoToNext();
        OnTowerChange.Invoke("next", CurrentTower);
    }

    /// <summary>
    /// Causes the tower previous in the list to be selected.
    /// </summary>
    public void GoToPrevious()
    {
        towers.GoToPrevious();
        OnTowerChange.Invoke("previous", CurrentTower);
    }
    
    /// <summary>
    /// Makes the current tower the tower at the given index.
    /// </summary>
    /// <param name="index">The index of the tower.</param>
    public void SetCurrent(int index)
    {
        towers.SetCurrentIndex(index);
        OnTowerChange.Invoke("indexChange", CurrentTower);
    }

    /// <summary>
    /// Adds a tower to this network manager. If the added tower's parent is 
    /// not this network, it will set it to this network.
    /// </summary>
    /// <param name="tower">The tower to add to this network.</param>
    public void CreateTower(GameObject tower)
    {
        if (tower.transform.parent != transform)
            tower.transform.parent = transform;
        towers.Add(tower);
    }
}
