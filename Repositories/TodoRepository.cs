using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTodo.Data;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;

namespace MyTodo.Repositories
{
    public class TodoRepository : IGetAllTodosRepository, 
                                    IGetTodoRepository, 
                                    ICreateTodoRepository, 
                                    IUpdateTodoRepository, 
                                    IDeleteTodoRepository
    {
        private AppDbContext _context;
        public TodoRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Todo> Create(Todo todo)
        {
            try
            {
                await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();

                return todo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Todo> Delete(Todo todo)
        {
            try
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();

                return todo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Todo>> GetAll()
        {
            try
            {
                var todos = await _context
                .Todos
                .AsNoTracking()
                .ToListAsync();

                return todos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Todo> GetById(int id)
        {
            try
            {
                var todo = await _context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

                return todo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Todo> Update(Todo todo)
        {
            try
            {
                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();

                return todo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}