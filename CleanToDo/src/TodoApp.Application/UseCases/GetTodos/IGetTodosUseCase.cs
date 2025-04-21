using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.GetTodos
{
    public interface IGetTodosUseCase
    {
        Task<GetTodosResponse> HandleAsync(GetTodosRequest request);
    }
}
