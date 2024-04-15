using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Chipset;

public class Chipset
{
    public Chipset(int id, int pciLinesNumber, IEnumerable<int> availableMemoryFrequencies, bool xmpSupply)
    {
        Id = id;
        PciLinesNumber = pciLinesNumber;
        AvailableMemoryFrequencies = availableMemoryFrequencies.ToList();
        XMPSupply = xmpSupply;
    }

    public static IIdBuilder<IChipsetBuilder> Builder => new ChipsetBuilder();

    public int Id { get; }
    public int PciLinesNumber { get; }
    public IList<int> AvailableMemoryFrequencies { get; }
    public bool XMPSupply { get; }

    private class ChipsetBuilder : IChipsetBuilder, IIdBuilder<IChipsetBuilder>
    {
        private int? _id;
        private int? _pciLinesNumber;
        private List<int> _availableMemoryFrequencies;
        private bool _xmpSupply;

        public ChipsetBuilder()
        {
            _xmpSupply = false;
            _availableMemoryFrequencies = new List<int>();
        }

        public IChipsetBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IChipsetBuilder AddPciLinesNumber(int number)
        {
            _pciLinesNumber = number;

            return this;
        }

        public IChipsetBuilder AddAvailableMemoryFrequencies(int frequency)
        {
            _availableMemoryFrequencies.Add(frequency);

            return this;
        }

        public IChipsetBuilder AddXMPSupply()
        {
            _xmpSupply = true;

            return this;
        }

        public Chipset Build()
        {
            return new Chipset(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _pciLinesNumber ?? throw new ArgumentNullException(nameof(_pciLinesNumber)),
                _availableMemoryFrequencies,
                _xmpSupply);
        }
    }
}