using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Business.Services;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.DataAccess.Repositories;
using TaskFlow.Entities;

namespace TaskFlow.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITaskRepository repository = new FileTaskRepository();
            TaskService taskService = new TaskService(repository);

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Lütfen menüden bir tuşlama yapınız.");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine("1 - Task Ekle\n" +
                    "2 - Task Listele\n" +
                    "3 - Task Silme\n" +
                    "4 - Task Güncelle\n" +
                    "5 - Çıkış");

                Console.Write("Seçiminiz : ");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
                }

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("TASK EKLEME ALANI");
                        Console.WriteLine("*****************\n");
                        Console.Write("Task başlığını giriniz : ");
                        string tittle = Console.ReadLine();
                        taskService.AddTask(tittle);
                        Console.WriteLine("Task Eklendi.");
                        Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("TASK LİSTELEME ALANI");
                        Console.WriteLine("********************\n");
                        List<TaskItem> tasks = taskService.GetTasks();

                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Henüz eklenmiş bir task bulunmuyor.");
                        }
                        else
                        {
                            foreach (var task in tasks)
                            {
                                Console.WriteLine($"{task.Id} - {task.Title} - {(task.IsCompleted ? "Tamamlandı" : "Devam Ediyor")}");
                            }
                        }
                        Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("TASK SİLME ALANI");
                        Console.WriteLine("***************\n");

                        List<TaskItem> tasks2 = taskService.GetTasks();
                        foreach (var task in tasks2)
                        {
                            Console.WriteLine($"{task.Id} - {task.Title}");
                        }
                        Console.Write("Silmek istediğiniz taskın ID numarasını yazınız : ");
                        int deleteId;
                        while (!int.TryParse(Console.ReadLine(), out deleteId))
                        {
                            Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
                        }
                        taskService.DeleteTask(deleteId);
                        Console.WriteLine("Task Silindi.");
                        Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("TASK GÜNCELLEME ALANI");
                        Console.WriteLine("********************\n");
                        List<TaskItem> updateTasks = taskService.GetTasks();
                        if (updateTasks.Count == 0)
                        {
                            Console.WriteLine("Güncellenecek task bulunamadı.");
                            Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
                            Console.ReadKey();
                            break;
                        }
                        foreach (var task in updateTasks)
                        {
                            Console.WriteLine($"{task.Id} - {task.Title} - {(task.IsCompleted ? "Tamamlandı" : "Devam Ediyor")}");
                        }
                        Console.Write("\nGüncellemek istediğiniz task ID: ");
                        int updateId;
                        while (!int.TryParse(Console.ReadLine(), out updateId))
                        {
                            Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
                        }
                        TaskItem selectedTask = updateTasks.FirstOrDefault(t => t.Id == updateId);

                        if (selectedTask == null)
                        {
                            Console.WriteLine("Girilen ID'ye ait task bulunamadı");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Yeni başlık (boş bırakılırsa değişmez): ");
                        string newTitle = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newTitle))
                        {
                            selectedTask.Title = newTitle;
                        }

                        Console.Write("Task tamamlandı mı? (E/H): ");
                        string completedInput = Console.ReadLine();

                        if (completedInput.Equals("E", StringComparison.OrdinalIgnoreCase))
                        {
                            selectedTask.IsCompleted = true;
                        }
                        else if (completedInput.Equals("H", StringComparison.OrdinalIgnoreCase))
                        {
                            selectedTask.IsCompleted = false;
                        }

                        taskService.UpdateTask(selectedTask);

                        Console.WriteLine("\nTask başarıyla güncellendi.");

                        Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("\nÇıkış yapılıyor. Tamamlamak için bir tuşa basınız.");
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Geçersiz seçim.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
