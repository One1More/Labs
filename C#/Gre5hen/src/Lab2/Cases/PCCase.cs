using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cases;

public class PCCase : ICompatibility<VideoCard>, ICompatibility<Motherboard.Motherboard>
{
    public PCCase(int id, int maxLength, int maxWidth, int dimensions, IEnumerable<int> supportedFormFactors)
    {
        Id = id;
        MaxLength = maxLength;
        MaxWidth = maxWidth;
        Size = dimensions;
        SupportedFormFactors = supportedFormFactors.ToList();
    }

    public static IIdBuilder<ICaseBuilder> Builder => new CaseBuilder();

    public int Id { get; }
    public int MaxLength { get; }
    public int MaxWidth { get; }
    public int Size { get; }
    public IList<int> SupportedFormFactors { get; }

    public CompareResult Compare(VideoCard workWith)
    {
        if (MaxLength < workWith.Length)
            return new CompareResult.Fail(nameof(VideoCard), nameof(PCCase), "Videocard length is too big.");
        else if (MaxWidth < workWith.Width)
            return new CompareResult.Fail(nameof(VideoCard), nameof(PCCase), "Videocard width is too big.");

        return new CompareResult.Success();
    }

    public CompareResult Compare(Motherboard.Motherboard workWith)
    {
        if (!SupportedFormFactors.Contains(workWith.FormFactor.Id))
        {
            return new CompareResult.Fail(nameof(Motherboard.Motherboard), nameof(PCCase), "Doesnt support this motherboard Formfactor.");
        }

        return new CompareResult.Success();
    }

    private class CaseBuilder : ICaseBuilder, IIdBuilder<ICaseBuilder>
    {
        private int? _id;
        private List<int> _supportedFormFactors;
        private int? _maxLength;
        private int? _maxWidth;
        private int? _size;

        public CaseBuilder()
        {
            _supportedFormFactors = new List<int>();
        }

        public ICaseBuilder AddId(int id)
        {
            _id = id;

            return this;
        }

        public ICaseBuilder AddMaxLength(int maxLength)
        {
            _maxLength = maxLength;

            return this;
        }

        public ICaseBuilder AddMaxWidth(int maxWidth)
        {
            _maxWidth = maxWidth;

            return this;
        }

        public ICaseBuilder AddSize(int size)
        {
            _size = size;

            return this;
        }

        public ICaseBuilder AddSupportedFormFactor(int formFactor)
        {
            _supportedFormFactors.Add(formFactor);

            return this;
        }

        public PCCase Build()
        {
            return new PCCase(
                _id ?? throw new ArgumentNullException(nameof(_id)),
                _maxLength ?? throw new ArgumentNullException(nameof(_maxLength)),
                _maxWidth ?? throw new ArgumentNullException(nameof(_maxWidth)),
                _size ?? throw new ArgumentNullException(nameof(_size)),
                _supportedFormFactors);
        }
    }
}