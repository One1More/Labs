using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboardBuilder
{
    IMotherboardBuilder AddSocket(Socket socket);
    IMotherboardBuilder AddChipset(Chipset.Chipset chipset);
    IMotherboardBuilder AddDDRVersion(float version);
    IMotherboardBuilder AddMaxRamNumber(int number);
    IMotherboardBuilder AddFormFactor(IFormFactor formFactor);
    IMotherboardBuilder AddBios(Bios bios);
    IMotherboardBuilder AddRamFormFactor(int formId);
    Motherboard Build();
}