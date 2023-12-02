using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackQueueTest : MonoBehaviour
{
    private Stack<int> stack = new Stack<int>(); // LIFO : last in first out

    private Queue<int> queue = new Queue<int>(); // FIFO : first in first out

    private void Awake()
    {
        //stack.Push(654);
        //stack.Push(1163);
        //stack.Push(789);

        queue.Enqueue(654);
        queue.Enqueue(1163);
        queue.Enqueue(789);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
           //if(stack.Count > 0)
           // {
           //     int value = stack.Pop();

           //     print(value);
           // }

            if(queue.Count > 0)
            {
                int value = queue.Dequeue();

                print(value);
            }
        }
    }
}
