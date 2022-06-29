using Microsoft.Extensions.DependencyInjection;
using Pariplay.API.Workflows;

namespace Pariplay.API.Extensions
{
    public static class WorkflowExtensions
    {
        public static IServiceCollection AddWorkflows(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IMatchWorkflow, MatchWorkflow>()
                .AddScoped<ITeamWorkflow, TeamWorkflow>()
                .AddScoped<IResultWorkflow, ResultWorkflow>();
        }
    }
}
