using System.Text.Json;
using Azure.Data.Tables;
using Sfa.Tl.Service.Home.Configuration;

namespace Sfa.Tl.Service.Home.Extensions;

public static class ConfigurationExtensions
{
    public static ConfigurationOptions LoadConfigurationOptions(this IConfiguration configuration)
    {
        return configuration.LoadConfigurationOptions(
            configuration[ConfigurationKeys.EnvironmentNameConfigKey],
            configuration[ConfigurationKeys.ConfigurationStorageConnectionStringConfigKey],
            configuration[ConfigurationKeys.ServiceNameConfigKey],
            configuration[ConfigurationKeys.VersionConfigKey]);
    }

    public static ConfigurationOptions LoadConfigurationOptions(this IConfiguration configuration,
        string environment,
        string storageConnectionString,
        string serviceName,
        string version)
    {
        try
        {
            var tableClient = new TableClient(storageConnectionString, "Configuration",
                environment == "LOCAL"
                    ? new TableClientOptions //Options to allow development running without azure emulator
                    {
                        Retry =
                        {
                            NetworkTimeout = TimeSpan.FromMilliseconds(500),
                            MaxRetries = 1
                        }
                    }
                    : default);

            var tableEntity = tableClient
                .Query<TableEntity>(
                    filter: $"PartitionKey eq '{environment}' and RowKey eq '{serviceName}_{version}'");

            var data = tableEntity.FirstOrDefault()?["Data"]?.ToString();

            if (data == null)
            {
                throw new NullReferenceException("Configuration data was null.");
            }

            return JsonSerializer.Deserialize<ConfigurationOptions>(
                data,
                new JsonSerializerOptions
                {
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                })
                ?? new ConfigurationOptions();
        }
        catch (AggregateException aex)
        {
            if (environment is "LOCAL" && aex.InnerException is TaskCanceledException)
            {
                //Workaround to allow front-end developers to load config from app settings
                return LoadConfigurationOptionsFromAppSettings(configuration);
            }

            throw;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                "Configuration could not be loaded. Please check your configuration files or see the inner exception for details",
                ex);
        }
    }

    public static ConfigurationOptions LoadConfigurationOptionsFromAppSettings(this IConfiguration configuration)
    {
        return new ConfigurationOptions
        {
            Environment = configuration[ConfigurationKeys.EnvironmentNameConfigKey],
            LinkSettings = new LinkSettings
            {
                EmployerSupportSiteUrl = configuration[ConfigurationKeys.EmployerSupportSiteUrl],
                ProviderSupportSiteUrl = configuration[ConfigurationKeys.ProviderSupportSiteUrl],
                ProviderDataSiteUrl = configuration[ConfigurationKeys.ProviderDataSiteUrl],
                ResultsAndCertificationsSiteUrl = configuration[ConfigurationKeys.ResultsAndCertificationsSiteUrl]
            }
        };
    }
}
