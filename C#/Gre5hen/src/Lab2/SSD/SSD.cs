using System;
using Itmo.ObjectOrientedProgramming.Lab2.ConnectionType;

namespace Itmo.ObjectOrientedProgramming.Lab2.SSD;

public class SSD
{
    public SSD(int id, IConnection connectionType, int capacity, int maxWokSpeed, int powerConsumption)
    {
        Id = id;
        ConnectionType = connectionType;
        Capacity = capacity;
        MaxWokSpeed = maxWokSpeed;
        PowerConsumption = powerConsumption;
    }

    public static IIdBuilder<ISSDBuilder> Builder => new SSDBuilder();

    public int Id { get; }
    public IConnection ConnectionType { get; }
    public int Capacity { get; }
    public int MaxWokSpeed { get; }
    public int PowerConsumption { get; }

    private class SSDBuilder : ISSDBuilder, IIdBuilder<ISSDBuilder>
    {
        private int? _id;
        private IConnection? _connectionType;
        private int? _capacity;
        private int? _maxWokSpeed;
        private int? _powerConsumption;

        public ISSDBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public ISSDBuilder AddConnectionType(IConnection type)
        {
            _connectionType = type;

            return this;
        }

        public ISSDBuilder AddCapacity(int capacity)
        {
            _capacity = capacity;

            return this;
        }

        public ISSDBuilder AddMaxWorkSpeed(int speed)
        {
            _maxWokSpeed = speed;

            return this;
        }

        public ISSDBuilder AddPowerConsumption(int consumption)
        {
            _powerConsumption = consumption;

            return this;
        }

        public SSD Build()
        {
            return new SSD(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _connectionType ?? throw new ArgumentNullException(nameof(_connectionType)),
                _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
                _maxWokSpeed ?? throw new ArgumentNullException(nameof(_maxWokSpeed)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
        }
    }
}