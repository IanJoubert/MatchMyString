using Autofac;

namespace Mms.Framework.Comparers.Module
{
    public class ComparerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(PresenceComparer).Assembly).AsImplementedInterfaces();
        }
    }
}
