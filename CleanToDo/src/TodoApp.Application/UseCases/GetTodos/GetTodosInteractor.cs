using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.GetTodos
{
    public class GetTodosInteractor : IGetTodosUseCase
    {
        private readonly ITodoRepository _repository;
        public GetTodosInteractor(ITodoRepository repository) => _repository = repository;

        public async Task<GetTodosResponse> HandleAsync(GetTodosRequest request)
        {
            var items = await _repository.GetAllAsync();
            var dtos = items.Select(i => new TodoItemDto { Id = i.Id, Title = i.Title, IsCompleted = i.IsCompleted });
            return new GetTodosResponse { Todos = dtos.ToList() };
        }
    }
}
