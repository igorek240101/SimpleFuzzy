using Autofac;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;

public class AutofacConfig : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AssemblyLoaderService>().As<IAssemblyLoaderService>().SingleInstance();
        builder.RegisterType<GenerationMembershipFunctionService>().As<IGenerationMembershipFunctionService>().SingleInstance();
        builder.RegisterType<GenerationObjectSetService>().As<IGenerationObjectSetService>().SingleInstance();
        builder.RegisterType<ProjectListService>().As<IProjectListService>().SingleInstance();
        builder.RegisterType<CompileService>().As<ICompileService>().SingleInstance();
        builder.RegisterType<RepositoryService>().As<IRepositoryService>().SingleInstance();
    }
}