using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;
using System.Text.Json;
using System.IO;

namespace TaskFlow.DataAccess.Repositories
{
    public class FileTaskRepository : ITaskRepository
    {
        private readonly string _filePath = "tasks.json";
        public void Add(TaskItem task)
        {
            List<TaskItem> tasks = GetAll();

            task.Id = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

            tasks.Add(task);

            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }


        public void Delete(int id)
        {
            List<TaskItem> tasks = GetAll();

            TaskItem taskToDelete = tasks.FirstOrDefault(t => t.Id == id);

            if (taskToDelete == null)
                return;

            tasks.Remove(taskToDelete);

            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }


        public List<TaskItem> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TaskItem>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<TaskItem>();
            }

            return JsonSerializer.Deserialize<List<TaskItem>>(json);
        }


        public void Update(TaskItem task)
        {
            List<TaskItem> tasks = GetAll();

            TaskItem existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);

            if (existingTask == null)
                return;

            existingTask.Title = task.Title;
            existingTask.IsCompleted = task.IsCompleted;

            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

    }
}
