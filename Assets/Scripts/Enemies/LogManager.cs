using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    private Queue<RollingLogHazard> resetQueue = new Queue<RollingLogHazard>();

    public void LogReachedBottom(RollingLogHazard log)
    {
        resetQueue.Enqueue(log);
        ProcessQueue();
    }

    private void ProcessQueue()
    {
        if (resetQueue.Count > 0)
        {
            RollingLogHazard logToReset = resetQueue.Dequeue();
            logToReset.ResetToTop();
        }
    }
}
