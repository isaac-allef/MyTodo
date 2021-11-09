using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyTodo.Models.EntityModels;
using MyTodo.Repositories.Db.Data;
using MyTodo.Repositories.Exceptions;
using MyTodo.Repositories.Interfaes.Db;

namespace MyTodo.Repositories.Db
{
    public class TodoRepository : IGetAllTodosRepository, 
                                    IGetTodoRepository, 
                                    ICreateTodoRepository, 
                                    IUpdateTodoRepository, 
                                    IDeleteTodoRepository
    {
        private AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public TodoRepository(AppDbContext context, IMemoryCache memoryCache)
        {
            this._context = context;
            this._memoryCache = memoryCache;
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
                todo.deleteMe();
                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();

                return todo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Todo>> GetAll(string search,
                                            string orderBy,
                                            string direction,
                                            int per_page,
                                            int page)
        {
            try
            {
                string parametersConcatenation = $"{search}-{orderBy}-{direction}-{per_page}-{page}";
                
                if (_memoryCache.TryGetValue(parametersConcatenation, out List<Todo> todos))
                {
                    return todos;
                }

                var query = _context.Todos.AsNoTracking();

                if (!String.IsNullOrEmpty(search))
                {
                    query = query.Where(t => EF.Functions.Like(t.Title , $"%{search}%"));
                }

                if (page > 0 && per_page > 0)
                {
                    query = query
                        .Skip((page - 1) * per_page)
                        .Take(per_page);
                }

                if (orderBy?.ToLower() == "title")
                {
                    if (direction == "asc")
                    {
                        query = query.OrderBy(t => t.Title);
                    }
                    else if (direction == "desc")
                    {
                        query = query.OrderByDescending(t => t.Title);
                    }
                }
                else if (orderBy?.ToLower() == "expire")
                {
                    if (direction == "asc")
                    {
                        query = query.OrderBy(t => t.Expire);
                    }
                    else if (direction == "desc")
                    {
                        query = query.OrderByDescending(t => t.Expire);
                    }
                }
                
                todos = await query.ToListAsync();

                _memoryCache.Set(parametersConcatenation, todos, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5),
                        SlidingExpiration = TimeSpan.FromSeconds(2)
                    }
                );

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
                if (_memoryCache.TryGetValue(id.ToString(), out Todo todo))
                {
                    return todo;
                }

                todo = await _context
                    .Todos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (todo == null)
                {
                    throw new EntityNotFoundException(id);
                }

                _memoryCache.Set(id.ToString(), todo, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5),
                        SlidingExpiration = TimeSpan.FromSeconds(2)
                    }
                );

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