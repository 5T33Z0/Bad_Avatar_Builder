namespace BadAvatarBuilder.Utilities
{
    internal class ActionQueue
    {
        private SortedDictionary<int, Queue<Func<Task>>> priorityQueue = new SortedDictionary<int, Queue<Func<Task>>>();

        internal void EnqueueAction(Func<Task> action, int priority)
        {
            if (!priorityQueue.ContainsKey(priority))
            {
                priorityQueue[priority] = new Queue<Func<Task>>();
            }
            priorityQueue[priority].Enqueue(action);
        }

        internal async Task ExecuteActionsAsync()
        {
            foreach (var priority in priorityQueue.Keys.OrderByDescending(p => p))
            {
                var actions = priorityQueue[priority];
                while (actions.Count > 0)
                {
                    var action = actions.Dequeue();
                    await action();
                }
            }
        }
    }
}