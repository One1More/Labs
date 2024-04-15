using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public class Bios
{
    public Bios(int id, string type, float version, IEnumerable<int> supportedProcessors)
    {
        Id = id;
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors.ToList();
    }

    public static IIdBuilder<IBiosBuilder> Builder => new BiosBuilder();

    public int Id { get; }
    public string Type { get; }
    public float Version { get; }
    public IList<int> SupportedProcessors { get; }

    private class BiosBuilder : IBiosBuilder, IIdBuilder<IBiosBuilder>
    {
        private int? _id;
        private string? _type;
        private float? _version;
        private List<int> _supportedProcessors;

        public BiosBuilder()
        {
            _supportedProcessors = new List<int>();
        }

        public IBiosBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public IBiosBuilder AddType(string type)
        {
            _type = type;

            return this;
        }

        public IBiosBuilder AddVersion(float version)
        {
            _version = version;

            return this;
        }

        public IBiosBuilder AddSupportedProccessor(int processor)
        {
            _supportedProcessors.Add(processor);

            return this;
        }

        public Bios Build()
        {
            return new Bios(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _type ?? throw new ArgumentNullException(nameof(_type)),
                _version ?? throw new ArgumentNullException(nameof(_version)),
                _supportedProcessors);
        }
    }
}