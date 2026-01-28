using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;


namespace TaskFlow.Business.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Task başlığı boş olamaz.");

            TaskItem task = new TaskItem
            {
                Title = title,
                IsCompleted = false,
                CreatedDate = DateTime.Now
            };

            _taskRepository.Add(task);
        }

        public List<TaskItem> GetTask()
        {
            return _taskRepository.GetAll();
        }

        public void UpdateTask(TaskItem task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }
    }
}
