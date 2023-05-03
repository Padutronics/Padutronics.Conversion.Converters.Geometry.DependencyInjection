using Padutronics.DependencyInjection;
using Padutronics.Geometry;
using System.Numerics;

namespace Padutronics.Conversion.Converters.Geometry.DependencyInjection.Modules;

public sealed class GeometryConvertersContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        RegisterPoint2ToStringConverter<sbyte>(containerBuilder);
        RegisterPoint2ToStringConverter<short>(containerBuilder);
        RegisterPoint2ToStringConverter<int>(containerBuilder);
        RegisterPoint2ToStringConverter<long>(containerBuilder);

        RegisterPoint2ToStringConverter<byte>(containerBuilder);
        RegisterPoint2ToStringConverter<ushort>(containerBuilder);
        RegisterPoint2ToStringConverter<uint>(containerBuilder);
    }

    private void RegisterPoint2ToStringConverter<T>(IContainerBuilder containerBuilder)
        where T : INumber<T>
    {
        containerBuilder.For<IConverter<Point2<T>, string>>().Use<Point2ToStringConverter<T>>().InstancePerDependency();
    }
}