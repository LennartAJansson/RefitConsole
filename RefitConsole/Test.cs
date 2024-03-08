namespace RefitConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RefitConsole.Services;

internal class Test(ILogger<Test> logger, IBuildVersionsApi client)
{
  public async Task Run()
  {
    var versions = await client.GetAll();
    foreach(var version in versions)
      logger.LogInformation("{name} {release}", version.ProjectName, version.Version);
  }
}
