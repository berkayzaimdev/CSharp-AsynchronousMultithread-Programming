using System.Collections.Concurrent;

var tasks = TaskScope.Create(group =>
{
    group.Run(async cancellationToken => await Task.Delay(100, cancellationToken));
    group.Run(async cancellationToken => await Task.Delay(200, cancellationToken));
    group.Run(async cancellationToken =>
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(200);
        }
    });
});

class TaskScope : IAsyncDisposable
{
    readonly CancellationTokenSource _cancellationTokenSource = new();
    readonly ConcurrentBag<Task> _tasks = new();

    public static async Task Create(Func<TaskScope, Task> action)
    {
        await using var scope = new TaskScope();
        await action(scope);
        await scope.WaitForAll();
    }
    
    public static async Task Create(Action<TaskScope> action)
    {
        await using var scope = new TaskScope();
        action(scope);
        await scope.WaitForAll();
    }
    
    public async ValueTask DisposeAsync()
    {
        _cancellationTokenSource.Cancel();
        await WaitForAll();
    }

    public Task Run(Func<CancellationToken, Task> action)
    {
        var task = Task.Run(async () =>
        {
            try
            {
                await action(_cancellationTokenSource.Token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
        
        _tasks.Add(task);
        return task;
    }

    async Task WaitForAll()
    {
        try
        {
            await Task.WhenAll(_tasks.ToArray());
        }
        catch
        {
            throw;
        }
    }
}