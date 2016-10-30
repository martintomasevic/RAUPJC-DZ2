using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using Interfaces;
using Models;

namespace Repositories
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class ToDoRepository : IToDoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<ToDoItem> _inMemoryTodoDatabase;

        public ToDoRepository(IGenericList<ToDoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<ToDoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >() ;
            // x ?? y -> if x is not null , expression returns x. Else y.
        }
    
        public ToDoItem Get(Guid todoId)
        {
            var item = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId));
            return (ToDoItem) item.FirstOrDefault();
        }

        public void Add(ToDoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException();
            if (_inMemoryTodoDatabase == null) throw new NotImplementedException();
            if (_inMemoryTodoDatabase.Contains(todoItem)) throw new DuplicateToDoItemException();
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public bool Remove(Guid todoId)
        {
            var item = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId));
            return _inMemoryTodoDatabase.Remove((ToDoItem) item.FirstOrDefault());
        }

        public void Update(ToDoItem todoItem)
        {
            var items = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoItem.Id));
            ToDoItem item = items.FirstOrDefault();
            if (_inMemoryTodoDatabase.Contains(item))
            {
                _inMemoryTodoDatabase.Remove(item);
                _inMemoryTodoDatabase.Add(todoItem);
            }
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            ToDoItem item = (ToDoItem) _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId)).FirstOrDefault();
            if (item != null)
            {
                item.MarkAsCompleted();
                return item.IsCompleted;
            }
            return false;
        }

        public List<ToDoItem> GetAll()
        {
            return _inMemoryTodoDatabase.ToList();

        }

        public List<ToDoItem> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetCompleted()
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetFiltered(Func<ToDoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => filterFunction(i)).ToList();
        }
    }
}