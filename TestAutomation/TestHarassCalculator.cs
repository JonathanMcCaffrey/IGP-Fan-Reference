using TestAutomation.Utils;

namespace TestAutomation;

[TestFixture]
public class TestHarassCalculator : BaseTest
{
    
    [SetUp]
    public void SetUp()
    {
        TestReport.CreateTest();
    }

    [TearDown]
    public void TearDown()
    {
        TestReport.ThrowErrors();
    }
    
    [Test]
    public void CalculatorInput()
    {
        

        var expectedTotalAlloyHarassment = 240;

        Website.HarassCalculatorPage
            .Goto()
            .SetWorkersLostToHarass(3)
            .SetNumberOfTownHallsExisting(2)
            .SetTownHallTravelTime(0, 30)
            .GetTotalAlloyHarassment(out var foundTotalAlloyHarassment);

        TestReport.CheckPassed(expectedTotalAlloyHarassment.Equals(foundTotalAlloyHarassment),
            TestMessage.CreateFailedMessage($"expectTotalAlloyHarassment of {expectedTotalAlloyHarassment} " +
                                            "does not equal " +
                                            $"foundTotalAlloyHarassment of {foundTotalAlloyHarassment} "));
    }

    [Test]
    public void CalculatedExampleInformation()
    {
        

        var expectedExampleTotalAlloyLoss = 720;
        var expectedExampleWorkerCost = 300;
        var expectedExampleMiningTimeCost = 420;
        var expectedExampleTotalAlloyLossDifference = 300;
        var expectedExampleTotalAlloyLossAccurate = 450;
        var expectedExampleTotalAlloyLossAccurateDifference = 270;

        Website.HarassCalculatorPage
            .Goto()
            .GetExampleTotalAlloyLoss(out var foundTotalAlloyLoss)
            .GetExampleWorkerCost(out var foundExampleWorkerCost)
            .GetExampleMiningTimeCost(out var foundExampleMiningTimeCost)
            .GetExampleTotalAlloyLossAccurate(out var foundExampleTotalAlloyLossAccurate)
            .GetExampleTotalAlloyLossDifference(out var foundGetExampleTotalAlloyLossDifference)
            .GetExampleTotalAlloyLossAccurateDifference(out var foundExampleTotalAlloyLossAccurateDifference);

        TestReport.CheckPassed(expectedExampleTotalAlloyLoss.Equals(foundTotalAlloyLoss),
            TestMessage.CreateFailedMessage($"expectedExampleTotalAlloyLoss of {expectedExampleTotalAlloyLoss} " +
                                            "does not equal " +
                                            $"foundTotalAlloyLoss of {foundTotalAlloyLoss} "));

        TestReport.CheckPassed(expectedExampleWorkerCost.Equals(foundExampleWorkerCost),
            TestMessage.CreateFailedMessage($"expectedExampleWorkerCost of {expectedExampleWorkerCost} " +
                                            "does not equal " +
                                            $"foundExampleWorkerCost of {foundExampleWorkerCost} "));


        TestReport.CheckPassed(expectedExampleMiningTimeCost.Equals(foundExampleMiningTimeCost),
            TestMessage.CreateFailedMessage($"expectedExampleMiningTimeCost of {expectedExampleMiningTimeCost} " +
                                            "does not equal " +
                                            $"foundExampleMiningTimeCost of {foundExampleMiningTimeCost} "));


        TestReport.CheckPassed(expectedExampleTotalAlloyLossAccurate.Equals(foundExampleTotalAlloyLossAccurate),
            TestMessage.CreateFailedMessage(
                $"expectedExampleTotalAlloyLossAccurate of {expectedExampleTotalAlloyLossAccurate} " +
                "does not equal " +
                $"foundExampleTotalAlloyLossAccurate of {foundExampleTotalAlloyLossAccurate} "));


        TestReport.CheckPassed(expectedExampleTotalAlloyLossDifference.Equals(foundGetExampleTotalAlloyLossDifference),
            TestMessage.CreateFailedMessage(
                $"expectedExampleTotalAlloyLossDifference of {expectedExampleTotalAlloyLossDifference} " +
                "does not equal " +
                $"foundGetExampleTotalAlloyLossDifference of {foundGetExampleTotalAlloyLossDifference} "));


        TestReport.CheckPassed(
            expectedExampleTotalAlloyLossAccurateDifference.Equals(foundExampleTotalAlloyLossAccurateDifference),
            TestMessage.CreateFailedMessage(
                $"expectedExampleTotalAlloyLossAccurateDifference of {expectedExampleTotalAlloyLossAccurateDifference} " +
                "does not equal " +
                $"foundExampleTotalAlloyLossAccurateDifference of {foundExampleTotalAlloyLossAccurateDifference} "));
    }
}