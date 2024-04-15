using Itmo.ObjectOrientedProgramming.Lab2.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiRouter;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public interface IPCBuilder
{
    IPCBuilder AddMotherboard(Motherboard.Motherboard motherboard);
    IPCBuilder AddProcessor(Processor.Processor processor);
    IPCBuilder AddCase(PCCase pcCase);
    IPCBuilder AddRam(Ram ram);
    IPCBuilder AddCoolingSystem(Cooler cooler);
    IPCBuilder AddPowerSupply(PowerSupply.PowerSupply powerSupply);

    IPCBuilder AddHardDisk(HardDisk.HardDisk? hardDisk);
    IPCBuilder AddVideocard(VideoCard? videoCard);
    IPCBuilder AddSSD(SSD.SSD? ssd);
    IPCBuilder AddWifiRouter(Router? router);

    PCBuildResult Build();
}