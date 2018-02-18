using Autofac;

namespace Mms.Framework.Validators.Module
{
    public class ValidatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AlphanumericValidator).Assembly).AsImplementedInterfaces();
        }
    }
}
