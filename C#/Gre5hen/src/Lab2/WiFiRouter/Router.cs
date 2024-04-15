using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiRouter;

public class Router
{
    public Router(int id, float wiFiVersion, float pciVersion, int powerConsumption, bool? withBluetooth)
    {
        Id = id;
        WiFiVersion = wiFiVersion;
        PciVersion = pciVersion;
        WithBluetooth = withBluetooth;
        PowerConsumption = powerConsumption;
    }

    public static IIdBuilder<IRouterBuilder> Builder => new RouterBuilder();

    public int Id { get; }
    public float WiFiVersion { get; }
    public float PciVersion { get; }
    public bool? WithBluetooth { get; }
    public int PowerConsumption { get; }

    private class RouterBuilder : IRouterBuilder, IIdBuilder<IRouterBuilder>
    {
        private float? _wiFiVersion;
        private float? _pciVersion;
        private bool _withBluetooth;
        private int? _powerConsumption;
        private int? _id;

        public RouterBuilder()
        {
            _withBluetooth = false;
        }

        public IRouterBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IRouterBuilder AddWiFiVersion(float version)
        {
            _wiFiVersion = version;

            return this;
        }

        public IRouterBuilder AddPCIVersion(float version)
        {
            _pciVersion = version;

            return this;
        }

        public IRouterBuilder AddPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public IRouterBuilder AddBluetooth()
        {
            _withBluetooth = true;

            return this;
        }

        public Router Build()
        {
            return new Router(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _wiFiVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)),
                _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
                _withBluetooth);
        }
    }
}