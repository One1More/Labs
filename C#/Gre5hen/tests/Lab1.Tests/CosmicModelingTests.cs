using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class CosmicModelingTests
{
    public static IEnumerable<object[]> TestData1()
    {
        yield return new object[] { new Shuttle(new CClassEngine(), new FirstClassHull()), new ExpeditionResult.LostSpaceship() };
        yield return new object[] { new Avgur(new EClassEngine(), new JumpEngineAlpha(), new ThirdClassDeflector(), new ThirdClassHull(), new PhotonDeflector()), new ExpeditionResult.LostSpaceship() };
    }

    public static IEnumerable<object[]> TestData2()
    {
        yield return new object[] { new Vaklas(new EClassEngine(), new JumpEngineGamma(), new FirstClassDeflector(), new SecondClassHull(), new PhotonDeflector()), new Vaklas(new EClassEngine(), new JumpEngineGamma(), new FirstClassDeflector(), new SecondClassHull(), new PhotonDeflector()), new ExpeditionResult.TheCrewIsDead(), new ExpeditionResult.Success() };
    }

    public static IEnumerable<object[]> TestData3()
    {
        yield return new object[] { new Vaklas(new EClassEngine(), new JumpEngineGamma(), new FirstClassDeflector(), new SecondClassHull(), new PhotonDeflector()), new ExpeditionResult.SpaceshipDistruction() };
        yield return new object[] { new Avgur(new EClassEngine(), new JumpEngineAlpha(), new ThirdClassDeflector(), new ThirdClassHull(), new PhotonDeflector()), new ExpeditionResult.Success() };
        yield return new object[] { new Meridian(new EClassEngine(), new SecondClassDeflector(), new SecondClassHull(), new PhotonDeflector()), new ExpeditionResult.Success() };
    }

    public static IEnumerable<object[]> TestData4()
    {
        yield return new object[] { new Meridian(new EClassEngine(), new SecondClassDeflector(), new SecondClassHull(), new PhotonDeflector()), new ExpeditionResult.Success() };
        yield return new object[] { new Avgur(new EClassEngine(), new JumpEngineAlpha(), new ThirdClassDeflector(), new ThirdClassHull(), new PhotonDeflector()), new ExpeditionResult.SpaceshipDistruction() };
    }

    [Theory]
    [MemberData(nameof(TestData1))]
    public void LetsGoShouldReturnTwoLost(IShip ship, ExpeditionResult expectedResult)
    {
        var space = new Nebulae(700);

        ExpeditionResult result = space.StartExpedition(ship);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(TestData2))]
    public void LetsGoShouldReturnDeadCrewAndSuccess(Vaklas vaklas1, Vaklas vaklas2, ExpeditionResult expectedResult, ExpeditionResult expectedResult2)
    {
        vaklas2.MadePhotonModification();

        var space = new Nebulae(90);
        space.MakeObstacle();

        ExpeditionResult result1 = space.StartExpedition(vaklas1);
        ExpeditionResult result2 = space.StartExpedition(vaklas2);

        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult2, result2);
    }

    [Theory]
    [MemberData(nameof(TestData3))]
    public void LetsGoShouldReturnDefitetedAndTwoSucess(IShip ship, ExpeditionResult expectedResult)
    {
        var space = new NitrinNebulae(300);
        space.MakeObstacle();

        ExpeditionResult result = space.StartExpedition(ship);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void CompareShouldReturnShuttle()
    {
        var shuttle = new Shuttle(new CClassEngine(), new FirstClassHull());
        var vaklas = new Vaklas(new EClassEngine(), new JumpEngineGamma(), new FirstClassDeflector(), new SecondClassHull(), new PhotonDeflector());

        var space = new OpenSpace(100);

        CompareResult answer = space.CompareShips(shuttle, vaklas);

        Assert.Equal(new CompareResult.FirstSpaceshipBetter(), answer);
    }

    [Fact]
    public void CompareShouldReturnStella()
    {
        var avgur = new Avgur(new EClassEngine(), new JumpEngineAlpha(), new ThirdClassDeflector(), new ThirdClassHull(), new PhotonDeflector());
        var stella = new Stella(new CClassEngine(), new JumpEngineOmega(), new FirstClassDeflector(), new FirstClassHull(), new PhotonDeflector());

        var space = new Nebulae(500);

        CompareResult answer = space.CompareShips(avgur, stella);

        Assert.Equal(new CompareResult.SecondSpaceshipBetter(), answer);
    }

    [Fact]
    public void CompareShouldReturnVaklas()
    {
        var shuttle = new Shuttle(new CClassEngine(), new FirstClassHull());
        var vaklas = new Vaklas(new EClassEngine(), new JumpEngineGamma(), new FirstClassDeflector(), new SecondClassHull(), new PhotonDeflector());

        var space = new NitrinNebulae(633);

        CompareResult answer = space.CompareShips(shuttle, vaklas);

        Assert.Equal(new CompareResult.SecondSpaceshipBetter(), answer);
    }

    [Fact]
    public void LetsGoShouldReturnDestruction()
    {
        var stella = new Stella(new CClassEngine(), new JumpEngineOmega(), new FirstClassDeflector(), new FirstClassHull(), new PhotonDeflector());

        // здесь проверяю правильную работу брони и методов нанесения урона
        var space = new OpenSpace(300);
        space.MakeMeteorObstacle();
        space.MakeObstacle();
        space.MakeMeteorObstacle();
        space.MakeObstacle();

        ExpeditionResult answer = space.StartExpedition(stella);

        Assert.Equal(new ExpeditionResult.SpaceshipDistruction(), answer);
    }

    [Theory]
    [MemberData(nameof(TestData4))]
    public void LetsGoShouldReturnSuccessWhereShipMeridian(IShip ship, ExpeditionResult expectedResult)
    {
        // проверка на работу анти-нитринного излучателя Меридиана
        var space = new NitrinNebulae(1000);
        space.MakeObstacle();
        space.MakeObstacle();

        ExpeditionResult answer = space.StartExpedition(ship);

        Assert.Equal(expectedResult, answer);
    }

    [Fact]
    public void CompareShouldReturnBothDistruction()
    {
        var avgur = new Avgur(new EClassEngine(), new JumpEngineAlpha(), new ThirdClassDeflector(), new ThirdClassHull(), new PhotonDeflector());
        var shuttle = new Shuttle(new CClassEngine(), new FirstClassHull());

        var space = new Nebulae(1500);
        space.MakeObstacle();

        // оба корабля не подходят и будут уничтожены после столкновения с препятствием
        CompareResult answer = space.CompareShips(avgur, shuttle);

        Assert.Equal(new CompareResult.BothSpaceShipsUseless(), answer);
    }

    [Fact]
    public void CompareWithSeveralSpaces()
    {
        var vaklas = new Vaklas(new EClassEngine(), new JumpEngineGamma(), new FirstClassDeflector(), new SecondClassHull(), new PhotonDeflector());
        var avgur = new Avgur(new EClassEngine(), new JumpEngineAlpha(), new ThirdClassDeflector(), new ThirdClassHull(), new PhotonDeflector());

        var space1 = new Nebulae(1250);
        var space2 = new NitrinNebulae(300);
        space2.MakeObstacle();

        ExpeditionResult space1VaklasAnswer = space1.StartExpedition(vaklas);
        ExpeditionResult space1AvgurAnswer = space1.StartExpedition(avgur);
        ExpeditionResult space2VaklasAnswer = space2.StartExpedition(vaklas);

        CompareResult compareAnswer = space1.CompareShips(vaklas, avgur);

        // Первое пространство длинное с помощью Gamma двигателя ваклас его проходит
        Assert.Equal(new ExpeditionResult.Success(), space1VaklasAnswer);

        // У Авгура недостаточная дальность прохождения по длинным каналам (у него двигатель Alpha)
        Assert.Equal(new ExpeditionResult.LostSpaceship(), space1AvgurAnswer);

        // Космо-кит все таки уничтожит Ваклас во втором пространсвте
        Assert.Equal(new ExpeditionResult.SpaceshipDistruction(), space2VaklasAnswer);

        // Если сравнивать по первому пространству очевидно что Ваклас лучше
        Assert.Equal(new CompareResult.FirstSpaceshipBetter(), compareAnswer);
    }
}