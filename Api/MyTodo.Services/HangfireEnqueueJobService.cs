using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyTodo.Services.Interfaces;
using Hangfire;


namespace MyTodo.Services
{
    public class HangfireEnqueueJobService : IEnqueueJobService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public HangfireEnqueueJobService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task Execute(string identifier, Expression<Action> action)
        {
            var myQueueState = new Hangfire.States.EnqueuedState(identifier.ToLower());
            var jobId = _backgroundJobClient.Enqueue(action);
            _backgroundJobClient.ChangeState(jobId, myQueueState);
            
            await Task.FromResult<object>(null);
        }
    }
}