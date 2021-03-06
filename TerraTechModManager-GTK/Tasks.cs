﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class Tasks
{
    private static List<Task> TaskQueue = new List<Task>();
    
    private static void CycleQueue(Task obj)
    {
        TaskQueue.RemoveAt(0);
        int count = TaskQueue.Count;
        if (count != 0)
        {
            TaskQueue[0].Start();
        }
    }

    public static void AddToTaskQueue(Task task)
    {
        TaskQueue.Add(task);
        task.ContinueWith(CycleQueue);
        if (TaskQueue.Count == 1)
        {
            task.Start();
        }
    }

    public static void ClearTasks()
    {
        if (TaskQueue.Count != 0)
        {
            TaskQueue.Clear();
        }
    }
}
