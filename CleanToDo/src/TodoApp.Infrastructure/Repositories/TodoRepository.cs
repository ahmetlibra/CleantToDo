using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _ctx;
        public TodoRepository(TodoDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(TodoItem item)
        {
            await _ctx.Todos.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync() =>
            await _ctx.Todos.AsNoTracking().ToListAsync();
    }
}
