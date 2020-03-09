using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps track of the current tower.
/// </summary>
public class TrackedLinkedList<T> : IEnumerable
{

    private List<T> objects = new List<T>();

    
    #region Fields
    private int currentIndex = 0;
    /// <summary>
    /// The currently selected index in the system.
    /// </summary>
    public int CurrentIndex
    {
        get => currentIndex;
    }

    /// <summary>
    /// Gets the current value of the list.
    /// </summary>
    public T CurrentValue
    {
        get => objects[currentIndex];
    }

    /// <summary>
    /// Gets the number of objects in the list.
    /// </summary>
    public int Count
    {
        get => objects.Count;
    }
    #endregion Fields

    #region Public Methods
    /// <summary>
    /// Moves the the next location in the list.
    /// </summary>
    public void GoToNext()
    {
        currentIndex++;
        currentIndex %= Count;
    }

    /// <summary>
    /// Moves to the previous location in the list.
    /// </summary>
    public void GoToPrevious()
    {
        currentIndex = currentIndex == 0 ? Count - 1 : currentIndex - 1;
    }

    public void SetCurrentIndex(int index)
    {
        if (index < 0 || Count <= index)
            throw new System.IndexOutOfRangeException();
        currentIndex = index;
    }

    /// <summary>
    /// Adds a tower at the end of the list.
    /// </summary>
    /// <param name="value">The value to be added to the list.</param>
    public void Add(T value)
    {
        objects.Add(value);
    }

    /// <summary>
    /// Removes the value from the list.
    /// </summary>
    /// <param name="value">The value to be removed.</param>
    public void Remove(T value)
    {
        objects.Remove(value);
    }
    #endregion Public Methods

    #region Operators
    /// <summary>
    /// Allows the user to get the element at any given index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index]
    {
        get => objects[index];
        set => objects[index] = value;
    }

    #endregion

    #region Interface Implementations
    public IEnumerator<T> GetEnumerator()
    {
        return objects.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion Interface Implementations
}
