using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Motherboard : ICompatibility<Ram>, ICompatibility<int>
{
    public Motherboard(int id, Socket socket, Chipset.Chipset chipset, float availableDdrVersion, int maxRamNumber, IFormFactor formFactor, Bios bios, IEnumerable<int> ramFormFactors)
    {
        Id = id;
        Socket = socket;
        Chipset = chipset;
        AvailableDdrVersion = availableDdrVersion;
        MaxRamNumber = maxRamNumber;
        FormFactor = formFactor;
        Bios = bios;
        SupportedRamFormFactors = ramFormFactors.ToList();
    }

    public static IIdBuilder<IMotherboardBuilder> Builder => new MotherboardBuilder();

    public int Id { get; }
    public Socket Socket { get; }
    public Chipset.Chipset Chipset { get; }
    public float AvailableDdrVersion { get; }
    public int MaxRamNumber { get; }
    public IFormFactor FormFactor { get; }
    public Bios Bios { get; }
    public IList<int> SupportedRamFormFactors { get; }

    public CompareResult Compare(Ram workWith)
    {
        if (workWith.DdrVersion != AvailableDdrVersion)
            return new CompareResult.Fail(nameof(Ram), nameof(Motherboard), "Ram DDR version doesnt support.");
        else if (!SupportedRamFormFactors.Contains(workWith.FormFactor.Id))
            return new CompareResult.Fail(nameof(Ram), nameof(Motherboard), "Ram form factor doesnt support.");

        return new CompareResult.Success();
    }

    public CompareResult Compare(int workWith)
    {
        if (workWith > Chipset.PciLinesNumber)
            return new CompareResult.Fail(nameof(Chipset), "Usable Pci lines", "Doesnt have enough PCI lines.");

        return new CompareResult.Success();
    }

    private class MotherboardBuilder : IMotherboardBuilder, IIdBuilder<IMotherboardBuilder>
    {
        private int? _id;
        private Socket? _socket;
        private Chipset.Chipset? _chipset;
        private float? _availableDDRVersion;
        private int? _maxRamNumber;
        private IFormFactor? _formFactor;
        private Bios? _bios;
        private List<int> _supportedRamFormFactors;

        public MotherboardBuilder()
        {
            _supportedRamFormFactors = new List<int>();
        }

        public IMotherboardBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IMotherboardBuilder AddSocket(Socket socket)
        {
            _socket = socket;

            return this;
        }

        public IMotherboardBuilder AddChipset(Chipset.Chipset chipset)
        {
            _chipset = chipset;

            return this;
        }

        public IMotherboardBuilder AddDDRVersion(float version)
        {
            _availableDDRVersion = version;

            return this;
        }

        public IMotherboardBuilder AddMaxRamNumber(int number)
        {
            _maxRamNumber = number;

            return this;
        }

        public IMotherboardBuilder AddFormFactor(IFormFactor formFactor)
        {
            _formFactor = formFactor;

            return this;
        }

        public IMotherboardBuilder AddBios(Bios bios)
        {
            _bios = bios;

            return this;
        }

        public IMotherboardBuilder AddRamFormFactor(int formId)
        {
            _supportedRamFormFactors.Add(formId);

            return this;
        }

        public Motherboard Build()
        {
            return new Motherboard(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _socket ?? throw new ArgumentNullException(nameof(_socket)),
                _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
                _availableDDRVersion ?? throw new ArgumentNullException(nameof(_availableDDRVersion)),
                _maxRamNumber ?? throw new ArgumentNullException(nameof(_maxRamNumber)),
                _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
                _bios ?? throw new ArgumentNullException(nameof(_bios)),
                _supportedRamFormFactors);
        }
    }
}