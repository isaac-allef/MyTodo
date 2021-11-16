using System;
using System.Threading.Tasks;
using MyTodo.Services.Interfaces;
using System.Threading;

namespace MyTodo.Services
{
    public class FakeSendEmailService : ISendEmailService
    {
        public async Task Execute(string from, string[] to, string subject, string message)
        {
            int seconds = new Random().Next(5,10);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));

            // Console.WriteLine("------------Email fake-------------");
            // Console.WriteLine(subject);
            // Console.WriteLine(message);
            // Console.WriteLine("------------Email fake-------------");

            await Task.FromResult<object>(null);
        }
    }
}

