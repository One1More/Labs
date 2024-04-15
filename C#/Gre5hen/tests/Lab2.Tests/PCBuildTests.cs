using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.ConnectionType.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PCBuildTests
{
    [Fact]
    public void PCBuildShouldReturnSuccess()
    {
        Bios bios = Bios.Builder.AddId(0).
            AddType("SomeType").
            AddVersion(3.5f).
            AddSupportedProccessor(3).
            AddSupportedProccessor(12).
            Build();

        VideoCard videocard = VideoCard.Builder.AddId(1).
            AddLength(100).
            AddWidth(40).
            AddPciVersion(3.0f).
            AddChipFrequency(144).
            AddPowerConsumption(50).
            Build();

        Processor.Processor processor = Processor.Processor.Builder.AddId(3).
            AddSocket(new Socket("AMD-31231", 33)).
            AddTdp(20).
            AddCoreNumber(8).
            AddCoreFrequency(300).
            AddPowerConsumption(50).
            AddAvailableMemoryFrequencies(12).
            Build();

        PCCase pcCase = PCCase.Builder.AddId(24).
            AddMaxLength(150).
            AddMaxWidth(60).
            AddSupportedFormFactor(2).
            AddSize(200).
            Build();

        Cooler cooler = Cooler.Builder.AddId(44).
            AddSocket("AMD-31231").
            AddTDP(50).
            Build();

        HardDisk.HardDisk hardDisk = HardDisk.HardDisk.Builder.AddId(5).
            AddPowerConsumption(50).
            AddCapacity(500).
            AddSpindleSpeed(30).
            Build();

        SSD.SSD ssd = SSD.SSD.Builder.AddId(10).
            AddCapacity(200).
            AddConnectionType(new PCI(0)).
            AddMaxWorkSpeed(12).
            AddPowerConsumption(50).
            Build();

        Ram ram = Ram.Builder.AddId(1).
            AddPowerConsumption(50).
            AddFormFactor(new SIMM(5)).AddDDRVersion(3.5f).
            AddSupportedFrequency(3).
            AddAvailableXMPProfiles(5).
            AddAvailableMemorySize(10).
            Build();

        Chipset.Chipset chipset = Chipset.Chipset.Builder.AddId(12).
            AddPciLinesNumber(3).
            AddXMPSupply().
            AddAvailableMemoryFrequencies(10).
            Build();

        Motherboard.Motherboard motherboard = Motherboard.Motherboard.Builder.AddId(13).
            AddSocket(new Socket("AMD-31231", 33)).
            AddDDRVersion(3.5f).
            AddFormFactor(new MidiTower(2)).
            AddChipset(chipset).
            AddBios(bios).
            AddMaxRamNumber(2).
            AddRamFormFactor(5).
            Build();

        var powerSupply = new PowerSupply.PowerSupply(10, 1000);

        var builder = new PcBuilder();
        PCBuildResult result = builder.AddCase(pcCase).
            AddMotherboard(motherboard).
            AddProcessor(processor).
            AddVideocard(videocard).
            AddRam(ram).
            AddCoolingSystem(cooler).
            AddHardDisk(hardDisk).
            AddSSD(ssd).
            AddPowerSupply(powerSupply).
            Build();

        Assert.True(result is PCBuildResult.Success);
    }

    [Fact]
    public void PCBuildShouldReturnFailConsumption()
    {
        Bios bios = Bios.Builder.AddId(0).
            AddType("SomeType").
            AddVersion(3.5f).
            AddSupportedProccessor(3).
            AddSupportedProccessor(12).
            Build();

        VideoCard videocard = VideoCard.Builder.AddId(1).
            AddLength(100).
            AddWidth(40).
            AddPciVersion(3.0f).
            AddChipFrequency(144).
            AddPowerConsumption(50).
            Build();

        Processor.Processor processor = Processor.Processor.Builder.AddId(3).
            AddSocket(new Socket("AMD-31231", 33)).
            AddTdp(20).
            AddCoreNumber(8).
            AddCoreFrequency(300).
            AddPowerConsumption(50).
            AddAvailableMemoryFrequencies(12).
            Build();

        PCCase pcCase = PCCase.Builder.AddId(24).
            AddMaxLength(150).
            AddMaxWidth(60).
            AddSupportedFormFactor(2).
            AddSize(200).
            Build();

        Cooler cooler = Cooler.Builder.AddId(44).
            AddSocket("AMD-31231").
            AddTDP(50).
            Build();

        HardDisk.HardDisk hardDisk = HardDisk.HardDisk.Builder.AddId(5).
            AddPowerConsumption(50).
            AddCapacity(500).
            AddSpindleSpeed(30).
            Build();

        SSD.SSD ssd = SSD.SSD.Builder.AddId(10).
            AddCapacity(200).
            AddConnectionType(new PCI(0)).
            AddMaxWorkSpeed(12).
            AddPowerConsumption(50).
            Build();

        Ram ram = Ram.Builder.AddId(1).
            AddPowerConsumption(50).
            AddFormFactor(new SIMM(5)).AddDDRVersion(3.5f).
            AddSupportedFrequency(3).
            AddAvailableXMPProfiles(5).
            AddAvailableMemorySize(10).
            Build();

        Chipset.Chipset chipset = Chipset.Chipset.Builder.AddId(12).
            AddPciLinesNumber(3).
            AddXMPSupply().
            AddAvailableMemoryFrequencies(10).
            Build();

        Motherboard.Motherboard motherboard = Motherboard.Motherboard.Builder.AddId(13).
            AddSocket(new Socket("AMD-31231", 33)).
            AddDDRVersion(3.5f).
            AddFormFactor(new MidiTower(2)).
            AddChipset(chipset).
            AddBios(bios).
            AddMaxRamNumber(2).
            AddRamFormFactor(5).
            Build();

        var powerSupply = new PowerSupply.PowerSupply(10, 10);

        var builder = new PcBuilder();
        PCBuildResult result = builder.AddCase(pcCase).
            AddMotherboard(motherboard).
            AddProcessor(processor).
            AddVideocard(videocard).
            AddRam(ram).
            AddCoolingSystem(cooler).
            AddHardDisk(hardDisk).
            AddSSD(ssd).
            AddPowerSupply(powerSupply).
            Build();

        if (result is PCBuildResult.Fail failResult)
        {
            foreach (CompareResult res in failResult.CompareResult)
            {
                Assert.Equal(res, new CompareResult.Fail(nameof(PowerSupply), "Power usable components", "Peak Load is lower than usable."));
            }
        }
    }

    [Fact]
    public void PCBuildShouldFailTDP()
    {
        Bios bios = Bios.Builder.AddId(0).
            AddType("SomeType").
            AddVersion(3.5f).
            AddSupportedProccessor(3).
            AddSupportedProccessor(12).
            Build();

        VideoCard videocard = VideoCard.Builder.AddId(1).
            AddLength(100).
            AddWidth(40).
            AddPciVersion(3.0f).
            AddChipFrequency(144).
            AddPowerConsumption(50).
            Build();

        Processor.Processor processor = Processor.Processor.Builder.AddId(3).
            AddSocket(new Socket("AMD-31231", 33)).
            AddTdp(20).
            AddCoreNumber(8).
            AddCoreFrequency(300).
            AddPowerConsumption(50).
            AddAvailableMemoryFrequencies(12).
            Build();

        PCCase pcCase = PCCase.Builder.AddId(24).
            AddMaxLength(150).
            AddMaxWidth(60).
            AddSupportedFormFactor(2).
            AddSize(200).
            Build();

        Cooler cooler = Cooler.Builder.AddId(44).
            AddSocket("AMD-31231").
            AddTDP(10).
            Build();

        HardDisk.HardDisk hardDisk = HardDisk.HardDisk.Builder.AddId(5).
            AddPowerConsumption(50).
            AddCapacity(500).
            AddSpindleSpeed(30).
            Build();

        SSD.SSD ssd = SSD.SSD.Builder.AddId(10).
            AddCapacity(200).
            AddConnectionType(new PCI(0)).
            AddMaxWorkSpeed(12).
            AddPowerConsumption(50).
            Build();

        Ram ram = Ram.Builder.AddId(1).
            AddPowerConsumption(50).
            AddFormFactor(new SIMM(5)).AddDDRVersion(3.5f).
            AddSupportedFrequency(3).
            AddAvailableXMPProfiles(5).
            AddAvailableMemorySize(10).
            Build();

        Chipset.Chipset chipset = Chipset.Chipset.Builder.AddId(12).
            AddPciLinesNumber(3).
            AddXMPSupply().
            AddAvailableMemoryFrequencies(10).
            Build();

        Motherboard.Motherboard motherboard = Motherboard.Motherboard.Builder.AddId(13).
            AddSocket(new Socket("AMD-31231", 33)).
            AddDDRVersion(3.5f).
            AddFormFactor(new MidiTower(2)).
            AddChipset(chipset).
            AddBios(bios).
            AddMaxRamNumber(2).
            AddRamFormFactor(5).
            Build();

        var powerSupply = new PowerSupply.PowerSupply(10, 1000);

        var builder = new PcBuilder();
        PCBuildResult result = builder.AddCase(pcCase).
            AddMotherboard(motherboard).
            AddProcessor(processor).
            AddVideocard(videocard).
            AddRam(ram).
            AddCoolingSystem(cooler).
            AddHardDisk(hardDisk).
            AddSSD(ssd).
            AddPowerSupply(powerSupply).
            Build();

        if (result is PCBuildResult.Fail failResult)
        {
            foreach (CompareResult res in failResult.CompareResult)
            {
                Assert.Equal(res, new CompareResult.Fail(nameof(Processor.Processor), nameof(Cooler), "Max TDP is lower then usable."));
            }
        }
    }

    [Fact]
    public void PCBuildShouldReturnFailVideocard()
    {
        Bios bios = Bios.Builder.AddId(0).
            AddType("SomeType").
            AddVersion(3.5f).
            AddSupportedProccessor(3).
            AddSupportedProccessor(12).
            Build();

        VideoCard videocard = VideoCard.Builder.AddId(1).
            AddLength(100).
            AddWidth(40).
            AddPciVersion(3.0f).
            AddChipFrequency(144).
            AddPowerConsumption(50).
            Build();

        Processor.Processor processor = Processor.Processor.Builder.AddId(3).
            AddSocket(new Socket("AMD-31231", 33)).
            AddTdp(20).
            AddCoreNumber(8).
            AddCoreFrequency(300).
            AddPowerConsumption(50).
            AddAvailableMemoryFrequencies(12).
            Build();

        PCCase pcCase = PCCase.Builder.AddId(24).
            AddMaxLength(150).
            AddMaxWidth(60).
            AddSupportedFormFactor(2).
            AddSize(200).
            Build();

        Cooler cooler = Cooler.Builder.AddId(44).
            AddSocket("Rizen-23132").
            AddTDP(50).
            Build();

        HardDisk.HardDisk hardDisk = HardDisk.HardDisk.Builder.AddId(5).
            AddPowerConsumption(50).
            AddCapacity(500).
            AddSpindleSpeed(30).
            Build();

        SSD.SSD ssd = SSD.SSD.Builder.AddId(10).
            AddCapacity(200).
            AddConnectionType(new PCI(0)).
            AddMaxWorkSpeed(12).
            AddPowerConsumption(50).
            Build();

        Ram ram = Ram.Builder.AddId(1).
            AddPowerConsumption(50).
            AddFormFactor(new SIMM(5)).AddDDRVersion(3.5f).
            AddSupportedFrequency(3).
            AddAvailableXMPProfiles(5).
            AddAvailableMemorySize(10).
            Build();

        Chipset.Chipset chipset = Chipset.Chipset.Builder.AddId(12).
            AddPciLinesNumber(1).
            AddXMPSupply().
            AddAvailableMemoryFrequencies(10).
            Build();

        Motherboard.Motherboard motherboard = Motherboard.Motherboard.Builder.AddId(13).
            AddSocket(new Socket("AMD-31231", 33)).
            AddDDRVersion(3.5f).
            AddFormFactor(new MidiTower(2)).
            AddChipset(chipset).
            AddBios(bios).
            AddMaxRamNumber(2).
            AddRamFormFactor(5).
            Build();

        var powerSupply = new PowerSupply.PowerSupply(10, 1000);

        var builder = new PcBuilder();
        PCBuildResult result = builder.AddCase(pcCase).
            AddMotherboard(motherboard).
            AddProcessor(processor).
            AddVideocard(videocard).
            AddRam(ram).
            AddCoolingSystem(cooler).
            AddHardDisk(hardDisk).
            AddSSD(ssd).
            AddPowerSupply(powerSupply).
            Build();

        if (result is PCBuildResult.Fail failResult)
        {
            int i = 0;
            foreach (CompareResult res in failResult.CompareResult)
            {
                if (i == 0)
                {
                    Assert.Equal(res, new CompareResult.Fail(nameof(Motherboard.Motherboard), nameof(Cooler), "Cooler doesnt support motherboard socket"));
                }
                else
                {
                    Assert.Equal(res, new CompareResult.Fail(nameof(Chipset), "Usable Pci lines", "Doesnt have enough PCI lines."));
                }

                ++i;
            }
        }
    }
}