using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class Ram
{
    public Ram(int id, IEnumerable<int> supportedFrequency, IEnumerable<int> availableXmpProfiles, IRamFormFactor formFactor, int availableMemorySize, float ddrVersion, int powerConsumption)
    {
        Id = id;
        SupportedFrequency = supportedFrequency.ToList();
        AvailableXmpProfiles = availableXmpProfiles.ToList();
        FormFactor = formFactor;
        AvailableMemorySize = availableMemorySize;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public static IIdBuilder<IRamBuilder> Builder => new RamBuilder();

    public int Id { get; }
    public IList<int> SupportedFrequency { get; }
    public IList<int> AvailableXmpProfiles { get; }
    public IRamFormFactor FormFactor { get; }
    public int AvailableMemorySize { get; }
    public float DdrVersion { get; }
    public int PowerConsumption { get; }

    private class RamBuilder : IRamBuilder, IIdBuilder<IRamBuilder>
    {
        private int? _id;
        private List<int> _supportedFrequency;
        private List<int> _availableXMPProfiles;
        private IRamFormFactor? _formFactor;
        private int? _availableMemorySize;
        private float? _ddrVersion;
        private int? _powerConsumption;

        public RamBuilder()
        {
            _supportedFrequency = new List<int>();
            _availableXMPProfiles = new List<int>();
        }

        public IRamBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IRamBuilder AddAvailableMemorySize(int size)
        {
            _availableMemorySize = size;

            return this;
        }

        public IRamBuilder AddSupportedFrequency(int frequency)
        {
            _supportedFrequency.Add(frequency);

            return this;
        }

        public IRamBuilder AddAvailableXMPProfiles(int profile)
        {
            _availableXMPProfiles.Add(profile);

            return this;
        }

        public IRamBuilder AddDDRVersion(float version)
        {
            _ddrVersion = version;

            return this;
        }

        public IRamBuilder AddFormFactor(IRamFormFactor formFactor)
        {
            _formFactor = formFactor;

            return this;
        }

        public IRamBuilder AddPowerConsumption(int consumption)
        {
            _powerConsumption = consumption;

            return this;
        }

        public Ram Build()
        {
            return new Ram(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _supportedFrequency,
                _availableXMPProfiles,
                _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
                _availableMemorySize ?? throw new ArgumentNullException(nameof(_availableMemorySize)),
                _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
        }
    }
}