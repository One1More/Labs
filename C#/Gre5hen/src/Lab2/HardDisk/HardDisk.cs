using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.HardDisk;

public class HardDisk
{
    public HardDisk(int id, int capacity, int spindleSpeed, int powerConsumption)
    {
        Id = id;
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public static IIdBuilder<IHardDiskBuilder> Builder => new HardDiskBuilder();

    public int Id { get; }
    public int Capacity { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }

    private class HardDiskBuilder : IHardDiskBuilder, IIdBuilder<IHardDiskBuilder>
    {
        private int? _id;
        private int? _capacity;
        private int? _spindleSpeed;
        private int? _powerConsumption;

        public IHardDiskBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IHardDiskBuilder AddCapacity(int capacity)
        {
            _capacity = capacity;

            return this;
        }

        public IHardDiskBuilder AddSpindleSpeed(int spindleSpeed)
        {
            _spindleSpeed = spindleSpeed;

            return this;
        }

        public IHardDiskBuilder AddPowerConsumption(int powerConsumption)
        {
            _powerConsumption = powerConsumption;

            return this;
        }

        public HardDisk Build()
        {
            return new HardDisk(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
                _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
        }
    }
}