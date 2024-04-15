namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiRouter;

public interface IRouterBuilder
{
    IRouterBuilder AddWiFiVersion(float version);
    IRouterBuilder AddPCIVersion(float version);
    IRouterBuilder AddPowerConsumption(int powerConsumption);
    IRouterBuilder AddBluetooth();
    Router Build();
}