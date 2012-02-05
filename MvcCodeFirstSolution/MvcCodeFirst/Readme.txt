- Created separate MVC Areas in its own projects.  Created using Class Library project. I've set the build output path to ..\GlobalBin   
- I've created a separate project: Preload.  This project will have database initialization code to set up all the preloaded data prior to running the app.
    So, in order to have Preload.dll on application start we need to add a setting in web.config like so:

   <appSettings>
         <add key ="DatabaseInitializerForType Infrastructure.DomainContext, Infrastructure" value="Preload.DatabaseInitilizer, Preload" />
    </appSettings>
  

- In MvcCodeFirst.csproj, I've added a folder: _bin_deployableAssemblies.  I've added external dlls that MvcCodeFirst requires to run but are not directly dependent on.
    So, instead of doing a hard reference to these dlls I added them to this folder.  Visual Studio will eventually copy these dlls to the \bin directory when f5 is hit.
- In MvcCodeFirst.csproj, in pre-build events, add: copy $(SolutionDir)GlobalBin\*Area.dll $(TargetDir).  The reason is because MvcCodeFirst.csproj, does not
    hold a hard reference to any *Area.dlls.  I also did the same for Preload.dll.  

- In Common.csproj, I've added IIncluder.cs.  This interface allows us to abstract away EntityFramework's System.Data.Entity.dll from MvcCodeFirst.sln.  In fact, I removed 
	a hard reference to System.Data.Entity.dll from MvcCodeFirst.sln.  The web project should be agnostic to the underlying ORM technology.  In Infrastructure.csproj, I've
	implement IIncluder for DbIncluder.  DbIncluder will invoke EntityFramework specific calls.  So, Infrastructure.csproj will have a hard reference to System.Data.entity.dll. 

- Database-Entity mappings are found in Infrastructure.Mappings.  These mappings are then called from DomainContext.OnModelCreating().
- DomainContext implements IDomainContext.  In this way, we can add DomainContext to Ninject.  IDomainContext will be injected into all repositories.
- All entities implement IEntity.  IEntity is currently used as a marker interface for DomainContext methods.  Only CRUD calls call only perform actions on IEntity objects. 




ISSUES
-----------------------------------------------------------------------------------------------------------------------------
- Ninject doesn't appear to call IDisposable.Dispose() on injected dependencies.