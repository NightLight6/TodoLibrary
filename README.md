# Todo.Core

Простая .NET 8 библиотека для управления списком задач с поддержкой JSON-персистентности.

## Установка пакета

### 1. Добавление источника пакетов (GitHub Packages)
```bash
   dotnet nuget add source --username NightLight6 --password GITHUB_TOKEN --store-password-in-clear-text ...

#### Использование

Пример работы с библиотекой:

```csharp
using Todo.Core;

var todoList = new TodoList();
var item = todoList.Add("Купить молоко");
item.MarkDone();

// Сохранение в JSON
todoList.Save("todos.json");

// Загрузка из JSON
var loadedList = new TodoList();
loadedList.Load("todos.json");