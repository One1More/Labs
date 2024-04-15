namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector.Models;

public class PhotonDeflector
{
    private int _photonHp;

    public PhotonDeflector()
    {
        _photonHp = 0;
    }

    public int AntimatterDamage()
    {
        _photonHp -= 1;

        return _photonHp;
    }

    public void MadePhotonModification()
    {
        _photonHp = 3;
    }
}