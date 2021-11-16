using System.Threading.Tasks;

namespace MyTodo.Services.Interfaces
{
    public interface ISendEmailService
    {
        Task Execute(string from, string[] to, string subject, string message);
    }
}