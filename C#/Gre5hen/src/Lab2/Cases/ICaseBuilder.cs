namespace Itmo.ObjectOrientedProgramming.Lab2.Cases;

public interface ICaseBuilder
{
    ICaseBuilder AddMaxLength(int maxLength);
    ICaseBuilder AddMaxWidth(int maxWidth);
    ICaseBuilder AddSize(int size);
    ICaseBuilder AddSupportedFormFactor(int formFactor);
    PCCase Build();
}