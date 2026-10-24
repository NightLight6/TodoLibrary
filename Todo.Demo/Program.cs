using Todo.Core;
using System;
using System.IO;

string filePath = "todos_test.json";

Console.WriteLine("--- Запуск демонстрации Todo.Core ---");

var todoList = new TodoList();
var item1 = todoList.Add("Купить молоко");
var item2 = todoList.Add("Изучить CI/CD");

Console.WriteLine($"Добавлено задач: {todoList.Count}");

item1.MarkDone();
Console.WriteLine($"Задача '{item1.Title}' выполнена: {item1.IsDone}");

Console.WriteLine($"Сохраняем список в файл: {filePath}");
todoList.Save(filePath);

Console.WriteLine("\n--- Имитация перезагрузки приложения ---");
var loadedList = new TodoList();
loadedList.Load(filePath);

Console.WriteLine($"Загружено задач: {loadedList.Count}");
foreach (var item in loadedList.Items)
{
    Console.WriteLine($"- [{(item.IsDone ? "X" : " ")}] {item.Title} (ID: {item.Id})");
}

if (File.Exists(filePath))
{
    // File.Delete(filePath);
}

Console.WriteLine("\nПроверка завершена успешно!");