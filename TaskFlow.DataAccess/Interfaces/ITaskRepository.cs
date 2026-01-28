using System;
using System.Collections.Generic;
using TaskFlow.Entities;

namespace TaskFlow.DataAccess.Interfaces
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAll();
        void Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(int id);
    }
}
