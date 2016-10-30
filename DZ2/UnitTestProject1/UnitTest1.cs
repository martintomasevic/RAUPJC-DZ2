using System;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repositories;
using ClassLibrary1;


namespace UnitTestProject1
{
    [TestClass]
    public class ToDoRepositoryTests
    {
        [TestMethod]
        public void AddingUpdateingAndRemovingItem()
        {
            IToDoRepository repository = new ToDoRepository();
            ToDoItem item = new ToDoItem("Blah");
            Assert.AreEqual(0, repository.GetAll().Count);
            repository.Add(item);
            Assert.AreEqual(1, repository.GetAll().Count);
            item.MarkAsCompleted();
            Assert.AreEqual(false, repository.Get(item.Id).IsCompleted);
            repository.Update(item);
            Assert.AreEqual(true, repository.Get(item.Id).IsCompleted);
            repository.Remove(item.Id);
            Assert.AreEqual(0, repository.GetAll().Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            IToDoRepository repository = new ToDoRepository();
            repository.Add(null);
        }

        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            IToDoRepository repository = new ToDoRepository();
            var todoItem = new ToDoItem("Groceries");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateToDoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            IToDoRepository repository = new ToDoRepository();
            var todoItem = new ToDoItem("Groceries");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }
    }
}
