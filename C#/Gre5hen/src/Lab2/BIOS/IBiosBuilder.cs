namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public interface IBiosBuilder
{
    IBiosBuilder AddType(string type);
    IBiosBuilder AddVersion(float version);
    IBiosBuilder AddSupportedProccessor(int processor);
    Bios Build();
}