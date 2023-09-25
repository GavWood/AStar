using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A generic Priority Queue implementation using a Binary Heap structure.
// T represents the type of elements in the priority queue.
// T must implement IComparable to be able to compare elements for ordering.
public class BWPriorityQueue<T> where T : IComparable<T>
{
    // A dynamically-sized list to store the elements of the heap.
    private List<T> _data;

    // Constructor initializes an empty list to represent the heap.
    public BWPriorityQueue()
    {
        _data = new List<T>();
    }

    // Adds an item to the priority queue and ensures heap property is maintained.
    public void Enqueue(T item)
    {
        // Add the item at the end of the list.
        _data.Add(item);
        int currentIndex = _data.Count - 1;

        // Bubble-up: Reorder the heap upwards until it's in the right position.
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            // If the current item is in the correct order, break out of the loop.
            if (_data[currentIndex].CompareTo(_data[parentIndex]) <= 0)
                break;

            // Swap the current item with its parent.
            T temp = _data[currentIndex];
            _data[currentIndex] = _data[parentIndex];
            _data[parentIndex] = temp;

            currentIndex = parentIndex;
        }
    }

    // Removes and returns the highest priority item from the queue.
    public T Dequeue()
    {
        int lastIndex = _data.Count - 1;
        T frontItem = _data[0]; // Item with highest priority.

        // Replace the root of the heap with the last item.
        _data[0] = _data[lastIndex];
        _data.RemoveAt(lastIndex);

        lastIndex--;
        int parentIndex = 0;

        // Bubble-down: Reorder the heap downwards to ensure it maintains the heap property.
        while (true)
        {
            int leftChildIndex = parentIndex * 2 + 1;
            int rightChildIndex = parentIndex * 2 + 2;
            int maxIndex = parentIndex;

            // Check if left child has higher priority.
            if (leftChildIndex <= lastIndex && _data[leftChildIndex].CompareTo(_data[maxIndex]) > 0)
                maxIndex = leftChildIndex;

            // Check if right child has higher priority.
            if (rightChildIndex <= lastIndex && _data[rightChildIndex].CompareTo(_data[maxIndex]) > 0)
                maxIndex = rightChildIndex;

            // If the parent item is in the correct position, break out of the loop.
            if (maxIndex == parentIndex)
                break;

            // Swap the parent item with the higher priority child.
            T temp = _data[parentIndex];
            _data[parentIndex] = _data[maxIndex];
            _data[maxIndex] = temp;

            parentIndex = maxIndex;
        }

        return frontItem;
    }
    public bool Remove(T item)
    {
        int index = _data.IndexOf(item);
        if (index == -1) return false; // Item not found, nothing to remove.

        _data[index] = _data[_data.Count - 1];
        _data.RemoveAt(_data.Count - 1);

        // Re-heapify.
        int parentIndex = (index - 1) / 2;
        // Bubble up.
        while (index > 0 && _data[index].CompareTo(_data[parentIndex]) > 0)
        {
            T temp = _data[index];
            _data[index] = _data[parentIndex];
            _data[parentIndex] = temp;
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }

        // If no bubbling up happened, bubble down.
        if (parentIndex == (index - 1) / 2)
        {
            while (true)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;
                int maxIndex = index;

                if (leftChildIndex < _data.Count && _data[leftChildIndex].CompareTo(_data[maxIndex]) > 0)
                    maxIndex = leftChildIndex;

                if (rightChildIndex < _data.Count && _data[rightChildIndex].CompareTo(_data[maxIndex]) > 0)
                    maxIndex = rightChildIndex;

                if (maxIndex == index)
                    break;

                T tmp = _data[index];
                _data[index] = _data[maxIndex];
                _data[maxIndex] = tmp;
                index = maxIndex;
            }
        }

        return true;
    }

    // Returns the number of items in the priority queue.
    public int Count
    {
        get { return _data.Count; }
    }

    // Checks if the priority queue contains a specific item.
    public bool Contains(T item)
    {
        return _data.Contains(item);
    }

    // Clears all items from the priority queue.
    public void Clear()
    {
        _data.Clear();
    }
}
