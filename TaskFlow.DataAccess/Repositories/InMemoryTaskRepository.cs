using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.DataAccess.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {

        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        public void Add(TaskItem task)
        {
            task.Id = _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1;
            _tasks.Add(task);
        }

        public void Delete(int id)
        {
            TaskItem task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public List<TaskItem> GetAll()
        {
            return _tasks.ToList();
        }

        public void Update(TaskItem task)
        {
            TaskItem existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }
    }
}
