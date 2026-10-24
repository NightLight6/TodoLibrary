using Xunit;
using Todo.Core;
using System.Linq;
using System.IO;

namespace Todo.Core.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Add_IncreasesCount()
        {
            var list = new TodoList();
            list.Add("  task ");
            Assert.Equal(1, list.Count);
            Assert.Equal("task", list.Items.First().Title);
        }

        [Fact]
        public void Remove_ById_Works()
        {
            var list = new TodoList();
            var item = list.Add("a");
            Assert.True(list.Remove(item.Id));
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Find_ReturnsMatches()
        {
            var list = new TodoList();
            list.Add("Buy milk");
            list.Add("Read book");
            var found = list.Find("buy").ToList();
            Assert.Single(found);
            Assert.Equal("Buy milk", found[0].Title);
        }

        [Fact]
        public void SaveAndLoad_WorksCorrectly()
        {
            var list = new TodoList();
            var item1 = list.Add("Task 1");
            item1.MarkDone();
            list.Add("Task 2");
            string testFilePath = "test_todos.json";

            list.Save(testFilePath);

            var newList = new TodoList();
            newList.Load(testFilePath);

            Assert.Equal(2, newList.Count);
            Assert.Equal("Task 1", newList.Items[0].Title);
            Assert.True(newList.Items[0].IsDone);

            if (File.Exists(testFilePath)) File.Delete(testFilePath);
        }
    }
}