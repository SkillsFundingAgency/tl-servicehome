# tl-servicehome" 

T Levels Service Home Site


## Requirements 

1. node - https://nodejs.org/en/
2. npm - https://www.npmjs.com/package/npm
3. Gulp - https://gulpjs.com/


## Actions

To set up gulp and npm, `cd` to the project "root" directory then:

|Task|Description|
|----|-----------|
| `npm install` | Installs all node packages |
| `gulp` | Merges, compiles and moves all sass / js / assets. Creates all front end resources |

If the above has worked you should see files being generated in frontend.

Developers don't need to run gulp manually as it should be run by the task runner. If there are errors when running the gulp tasks, check that you have the latest version.
If the node.js version is newer than the one used in Visual Studio, the task might not run properly and you might see a warning about bindings.
To fix this, set the version that Visual Studio runs by following the following steps. See https://ryanhayes.net/synchronize-node-js-install-version-with-visual-studio/.
* Open Tools > Options
* In the dialog navigate to Projects and Solutions > Web Package Management > External Web Tools 
* Add C:\Program Files\nodejs at the top of the locations list.
* Alternatively, add the nodejs folder to Windows PATH.


## Configuration

Website configuration is in `appsettings.json` but most settings are read from Azure Storage.

Some of the configuration settings are also in `appsettings.json` but will only be used if the Azure Storage Emulator or Azurite is not running. This is done for convenience and so that developers don't always need to run Azure Storage, but it will not work for the Find page.

If you need to override any values on your local machine, add a `appsettings.Development.json` file and set `Copy to Output Directory` to `Copy if newer`, then add keys/values there.

To set up configuration in local Azure Storage on a developer machine, make sure Azure Storage Emulator or Azurite is running then add a table to local storage called `Configuration` if it doesn't already exist.
Add a new row to the table with:

- PartitionKey : `LOCAL`
- RowKey : `Sfa.Tl.Service.Home_1.0`
- a property `Data` with the value below.

```
{
  "LinkSettings": {
    "EmployerSupportSiteUrl": "<url>",
    "ProviderSupportSiteUrl": "<url>",
    "ProviderDataSiteUrl": "<url>",
    "ResultsAndCertificationsSiteUrl": "<url>"
  }
}
```

- `CacheExpiryInSeconds` - Default cache time (in seconds) used for caching providers and qualifications.
- `LinkSettings` 
  - `EmployerSupportSiteUrl` - the url of the Zendesk Employer Support site.
  - `ProviderSupportSiteUrl` - the url of the Zendesk Provider Support site.
  - `ProviderDataSiteUrl` - the url of the Zendesk Provider Data site.
  - `ResultsAndCertificationsSiteUrl` - the url of the Results and Certifications site.

