S&G Lock Management API
======================

An API which serves as a back end for **S&G Lock Management System**.


### Build for Debug
1. Run **BuildDebug.bat** or **BuildDebug-2013.bat** for **VS2013**

### Build for Release
1. Run **BuildRelease.bat** or **BuildRelease-2013.bat** for **VS2013**

### Running Unit Tests
1. Run **RunTests.bat** or **RunTests-2013.bat** for **VS2013**

### Build for Deployment

#### Any Platform
1. Run **BuildPackage.bat** or **BuildPackage-2013.bat** for **VS2013**
2. It will generate a zip file, filename: {Version}-{datestamp}.zip (e.g.: **1.0.0.2-20140514.zip**)

#### x86
1. Run **BuildPackage(x86).bat** or **BuildPackage(x86)-2013.bat** for **VS2013**
2. It will generate a zip file, filename: {Version}(x86)-{datestamp}.zip (e.g.: **1.0.0.2(x86)-20140514.zip**)

#### Notes
Building for deployment will fail if one or more unit test fails.

### Deploying for Production
1. Modify **Web.config**.
2. Go to **connectionStrings** section.
3. Edit connection string **Production.DbConnection**.
4. Change **connectionString** attribute to point to production database server.
5. Host the application in IIS
6. Application Pool settings should support **32bit** applications and the pipeline mode set to **Integrated**


### Running the Solution for Development
1. Run **BuildDebug.bat** or **BuildDebug-2013.bat** for **VS2013**
2. Open **SaG.API.sln** in **Visual Studio**
3. Under **005.API** set **SaG.API** as start up project.
4. Modify connection string **Dev.DbConnection**
5. Run the solution or press **F5**

### Documentation
* [Development Guidelines](DevGuide/README.md)