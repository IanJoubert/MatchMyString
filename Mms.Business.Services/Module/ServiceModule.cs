using Autofac;
using Mms.Framework.Comparers.Module;
using Mms.Framework.Validators.Module;

namespace Mms.Business.Services.Module
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterModules(builder);
            builder.RegisterAssemblyTypes(typeof(StringMatcherService).Assembly).AsImplementedInterfaces();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<ComparerModule>();
            builder.RegisterModule<ValidatorModule>();
        }
    }
}
