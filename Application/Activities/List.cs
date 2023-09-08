using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                this._logger = logger;
                this._context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(5000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");
                    }
                }
                catch (System.Exception)
                {
                    _logger.LogInformation("Task was canceled");
                }
                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}