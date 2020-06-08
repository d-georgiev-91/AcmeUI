using AcmeUI.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeUI
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the responsible services for AcmeUI functionality
        /// </summary>
        /// <param name="serviceCollection">The service collection</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddAcmeUI(this IServiceCollection serviceCollection) => serviceCollection.AddSingleton<ReflectionHelper>();
    }
}
