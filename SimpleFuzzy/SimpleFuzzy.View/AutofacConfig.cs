using Autofac;
using Autofac.Integration.Mvc;
using SimpleFuzzy.Abstract;
using System.Web.Mvc;
using SimpleFuzzy.Service;

public static class AutofacConfig
{
    public static void ConfigureContainer()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<AssemblyLoaderService>().As<IAssemblyLoaderService>();
        builder.RegisterType<GenerationMembershipFunctionService>().As<IGenerationMembershipFunctionService>();
        builder.RegisterType<GenerationObjectSetService>().As<IGenerationObjectSetService>();
        builder.RegisterType<ProjectListService>().As<IProjectListService>();
        builder.RegisterType<CompileService>().As<ICompileService>();

        var container = builder.Build();

        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
}