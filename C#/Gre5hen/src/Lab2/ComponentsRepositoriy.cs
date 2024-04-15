using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiRouter;
using Itmo.ObjectOrientedProgramming.Lab2.XMPProfiles.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepositoriy
{
    private List<Ram> _rams;
    private List<Processor.Processor> _processors;
    private List<Cooler> _coolingSystems;
    private List<Motherboard.Motherboard> _motherboards;
    private List<PCCase> _cases;
    private List<Bios> _bioses;
    private List<HardDisk.HardDisk> _hardDisks;
    private List<PowerSupply.PowerSupply> _powerSupplies;
    private List<VideoCard> _videoCards;
    private List<Router> _routers;
    private List<SSD.SSD> _ssds;
    private List<XMPProfile> _xmpProfiles;
    private List<Chipset.Chipset> _chipsets;

    public ComponentsRepositoriy()
    {
        _cases = new List<PCCase>();
        _bioses = new List<Bios>();
        _motherboards = new List<Motherboard.Motherboard>();
        _chipsets = new List<Chipset.Chipset>();
        _processors = new List<Processor.Processor>();
        _rams = new List<Ram>();
        _routers = new List<Router>();
        _ssds = new List<SSD.SSD>();
        _coolingSystems = new List<Cooler>();
        _hardDisks = new List<HardDisk.HardDisk>();
        _powerSupplies = new List<PowerSupply.PowerSupply>();
        _videoCards = new List<VideoCard>();
        _xmpProfiles = new List<XMPProfile>();
    }

    public void AddRamModel(Ram model)
    {
        _rams.Add(model);
    }

    public void AddProcessorModel(Processor.Processor model)
    {
        _processors.Add(model);
    }

    public void AddCoolerModel(Cooler model)
    {
        _coolingSystems.Add(model);
    }

    public void AddMotherboardModel(Motherboard.Motherboard model)
    {
        _motherboards.Add(model);
    }

    public void AddCaseModel(PCCase model)
    {
        _cases.Add(model);
    }

    public void AddBiosModel(Bios model)
    {
        _bioses.Add(model);
    }

    public void AddHarddiskModel(HardDisk.HardDisk model)
    {
        _hardDisks.Add(model);
    }

    public void AddPowerSupplyModel(PowerSupply.PowerSupply model)
    {
        _powerSupplies.Add(model);
    }

    public void AddVideocardModel(VideoCard model)
    {
        _videoCards.Add(model);
    }

    public void AddWiFiRouterModel(Router model)
    {
        _routers.Add(model);
    }

    public void AddSSDModel(SSD.SSD model)
    {
        _ssds.Add(model);
    }

    public void AddXMPProfilesModel(XMPProfile model)
    {
        _xmpProfiles.Add(model);
    }

    public void AddChipsetModel(Chipset.Chipset model)
    {
        _chipsets.Add(model);
    }

    public Ram? SelectRam(int id)
    {
        foreach (Ram model in _rams)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public Processor.Processor? SelectProcessor(int id)
    {
        foreach (Processor.Processor model in _processors)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public Cooler? SelectCooler(int id)
    {
        foreach (Cooler model in _coolingSystems)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public Motherboard.Motherboard? SelectMotherboard(int id)
    {
        foreach (Motherboard.Motherboard model in _motherboards)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public PCCase? SelectCase(int id)
    {
        foreach (PCCase model in _cases)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public VideoCard? SelectVideocard(int id)
    {
        foreach (VideoCard model in _videoCards)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public Bios? SelectBios(int id)
    {
        foreach (Bios model in _bioses)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public HardDisk.HardDisk? SelectHarddisk(int id)
    {
        foreach (HardDisk.HardDisk model in _hardDisks)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public PowerSupply.PowerSupply? SelectPowerSupply(int id)
    {
        foreach (PowerSupply.PowerSupply model in _powerSupplies)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public Router? SelectRouter(int id)
    {
        foreach (Router model in _routers)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public SSD.SSD? SelectSSD(int id)
    {
        foreach (SSD.SSD model in _ssds)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public XMPProfile? SelectXmpProfile(int id)
    {
        foreach (XMPProfile model in _xmpProfiles)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }

    public Chipset.Chipset? SelectChipset(int id)
    {
        foreach (Chipset.Chipset model in _chipsets)
        {
            if (model.Id == id)
                return model;
        }

        return null;
    }
}