using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiRouter;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public class PcBuilder : IPCBuilder, ICompatibility<Motherboard.Motherboard>
{
    private Motherboard.Motherboard? _motherboard;
    private Processor.Processor? _processor;
    private PCCase? _case;
    private List<Ram> _ram;
    private Cooler? _cooler;
    private PowerSupply.PowerSupply? _powerSupply;
    private HardDisk.HardDisk? _hardDisk;
    private VideoCard? _videoCard;
    private SSD.SSD? _ssd;
    private Router? _wiFiRouter;

    public PcBuilder()
    {
        _ram = new List<Ram>();
    }

    public IPCBuilder AddMotherboard(Motherboard.Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public IPCBuilder AddProcessor(Processor.Processor processor)
    {
        _processor = processor;

        return this;
    }

    public IPCBuilder AddCase(PCCase pcCase)
    {
        _case = pcCase;

        return this;
    }

    public IPCBuilder AddRam(Ram ram)
    {
        _ram.Add(ram);

        return this;
    }

    public IPCBuilder AddCoolingSystem(Cooler cooler)
    {
        _cooler = cooler;

        return this;
    }

    public IPCBuilder AddPowerSupply(PowerSupply.PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;

        return this;
    }

    public IPCBuilder AddHardDisk(HardDisk.HardDisk? hardDisk)
    {
        _hardDisk = hardDisk;

        return this;
    }

    public IPCBuilder AddVideocard(VideoCard? videoCard)
    {
        _videoCard = videoCard;

        return this;
    }

    public IPCBuilder AddSSD(SSD.SSD? ssd)
    {
        _ssd = ssd;

        return this;
    }

    public IPCBuilder AddWifiRouter(Router? router)
    {
        _wiFiRouter = router;

        return this;
    }

    public CompareResult Compare(Motherboard.Motherboard workWith)
    {
        if (_ram.Count > workWith.MaxRamNumber)
            return new CompareResult.Fail(nameof(Motherboard), nameof(Ram), "Too much rams.");

        return new CompareResult.Success();
    }

    public PCBuildResult Build()
    {
        if (_motherboard is null)
            throw new ArgumentNullException(nameof(_motherboard));
        if (_processor is null)
            throw new ArgumentNullException(nameof(_processor));
        if (_case is null)
            throw new ArgumentNullException(nameof(_case));
        if (_cooler is null)
            throw new ArgumentNullException(nameof(_cooler));
        if (_powerSupply is null)
            throw new ArgumentNullException(nameof(_powerSupply));
        if (_ram.Count == 0)
            throw new ArgumentNullException(nameof(_ram));
        if (_processor.BuiltInVideocard is null && _videoCard is null)
            throw new ArgumentNullException(nameof(_videoCard));

        int usablePciLines = 0;
        var allChecks = new List<CompareResult>()
        {
        Compare(_motherboard),
        _cooler.Compare(_motherboard),
        _cooler.Compare(_processor),
        _powerSupply.Compare(new int[]
        {
            _processor.PowerConsumption,
            _videoCard is null ? 0 : _videoCard.PowerConsumption, usablePciLines++,
            _hardDisk is null ? 0 : _hardDisk.PowerConsumption,
            _wiFiRouter is null ? 0 : _wiFiRouter.PowerConsumption, usablePciLines++,
            _ssd is null ? 0 : _ssd.PowerConsumption, usablePciLines++,
        }),
        _motherboard.Compare(usablePciLines),
        };

        foreach (Ram ram in _ram)
        {
            allChecks.Add(_motherboard.Compare(ram));
        }

        allChecks.Add(_case.Compare(_motherboard));
        allChecks.Add(_processor.Compare(_motherboard));

        if (_videoCard is not null)
            allChecks.Add(_case.Compare(_videoCard));

        var failList = new List<CompareResult>();
        foreach (CompareResult check in allChecks)
        {
            if (check is CompareResult.Fail)
                failList.Add(check);
        }

        if (failList.Count != 0)
            return new PCBuildResult.Fail(failList);

        return new PCBuildResult.Success(new PC(
            _motherboard,
            _processor,
            _case,
            _ram,
            _cooler,
            _powerSupply,
            _hardDisk,
            _videoCard,
            _ssd,
            _wiFiRouter));
    }
}