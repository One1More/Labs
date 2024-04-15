using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Videocard;

public class VideoCard
{
    public VideoCard(int id, int length, int width, float pciVersion, int chipFrequency, int powerConsumption)
    {
        Id = id;
        Length = length;
        Width = width;
        PciVersion = pciVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public static IIdBuilder<IVideocardBuilder> Builder => new VideocardBuilder();

    public int Id { get; }
    public int Length { get; }
    public int Width { get; }
    public float PciVersion { get; }
    public int ChipFrequency { get;  }
    public int PowerConsumption { get; }

    private class VideocardBuilder : IVideocardBuilder, IIdBuilder<IVideocardBuilder>
    {
        private int? _length;
        private int? _width;
        private float? _pciVersion;
        private int? _chipFrequency;
        private int? _powerConsumption;
        private int? _id;

        public IVideocardBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IVideocardBuilder AddLength(int length)
        {
            _length = length;

            return this;
        }

        public IVideocardBuilder AddWidth(int width)
        {
            _width = width;

            return this;
        }

        public IVideocardBuilder AddPciVersion(float version)
        {
            _pciVersion = version;

            return this;
        }

        public IVideocardBuilder AddChipFrequency(int frequency)
        {
            _chipFrequency = frequency;

            return this;
        }

        public IVideocardBuilder AddPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public VideoCard Build()
        {
            return new VideoCard(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _length ?? throw new ArgumentNullException(nameof(_length)),
                _width ?? throw new ArgumentNullException(nameof(_width)),
                _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
                _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
        }
    }
}