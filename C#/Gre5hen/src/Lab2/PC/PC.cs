using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiRouter;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public class PC
{
    public PC(Motherboard.Motherboard motherboard, Processor.Processor processor, PCCase @case, IEnumerable<Ram> ram, Cooler cooler, PowerSupply.PowerSupply powerSupply, HardDisk.HardDisk? hardDisk, VideoCard? videoCard, SSD.SSD? ssd, Router? wiFiRouter)
    {
        Motherboard = motherboard;
        Processor = processor;
        Case = @case;
        Rams = ram.ToList();
        Cooler = cooler;
        PowerSupply = powerSupply;
        HardDisk = hardDisk;
        VideoCard = videoCard;
        Ssd = ssd;
        WiFiRouter = wiFiRouter;
    }

    public Motherboard.Motherboard Motherboard { get; }
    public Processor.Processor Processor { get; }
    public PCCase Case { get; }
    public IList<Ram> Rams { get; }
    public Cooler Cooler { get; }
    public PowerSupply.PowerSupply PowerSupply { get; }
    public HardDisk.HardDisk? HardDisk { get; }
    public VideoCard? VideoCard { get; }
    public SSD.SSD? Ssd { get; }
    public Router? WiFiRouter { get; }

    public PcBuilder Direct(PcBuilder builder)
    {
        builder.AddCase(Case);
        builder.AddVideocard(VideoCard);
        builder.AddProcessor(Processor);
        builder.AddMotherboard(Motherboard);
        builder.AddCoolingSystem(Cooler);
        builder.AddPowerSupply(PowerSupply);
        builder.AddSSD(Ssd);
        builder.AddHardDisk(HardDisk);
        builder.AddWifiRouter(WiFiRouter);
        foreach (Ram ram in Rams)
        {
            builder.AddRam(ram);
        }

        return builder;
    }
}