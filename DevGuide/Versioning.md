## Build and Version Iteration

### Building

See [Building for Deployment](Building.md#build-for-deployment)

### Version Iteration

The version iteration steps should be performed after a build is created for release.

1. Edit **version.build**
2. Modify the **CurrentVersion** node.  Change it to the next version iteration.
3. Execute **GenerateCommonAssemblyInfo.bat**.  This will generate a new **Common.AssemblyInfo.cs**.
4. In the **Migrations** project under **SaG.Data.Migrations** add a new folder to contain the new versions migration scripts.  The folder name should be in this format **Version-{VersionNumber}** (e.g.: Version-1.0.0.3).
5. Under the new folder create a **Version** class.  The filename format should be **Version{VersionNumberWithoutTheDots}.cs**.  For example **Version1003.cs** for **Version: 1.0.0.3**.  See below for **Version** class example.

```C#
namespace SaG.Data.Migrations.Version1003
{
    class Version1002 : IProductVersion
    {
        public string Version
        {
            get { return "1.0.0.3"; }
        }

        public string Name
        {
            get { return "alpha-1003"; }
        }
    }
}
```

Under the same folder, create a **VersionInit** class.  The filename should be in this format **{VersionWithoutTheDots}01-VersionInit.cs** (e.g.: 100301-VersionInit.cs).  See below for **VersionInit** class example.

```C#
using FluentMigrator;

namespace SaG.Data.Migrations.Version1003
{
    [Migration(100301)]
    public class VersionInit : VersionInitializer
    {
        public VersionInit()
            : base(new Version1003())
        { }
    }
}
```

Save and commit the changes to the repository.

[<< Back to Development Guide](README.md)
