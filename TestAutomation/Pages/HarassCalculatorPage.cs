using TestAutomation.Shared;
using TestAutomation.Utils;

namespace TestAutomation.Pages;

public class HarassCalculatorPage : BaseElement
{
    public HarassCalculatorPage(Website website) : base(website)
    {
    }

    private IWebElement NumberOfWorkersLostToHarass => Website.Find("numberOfWorkersLostToHarass");
    private IWebElement NumberOfTownHallsExisting => Website.Find("numberOfTownHallsExisting");
    private IList<IWebElement> OnTownHallTravelTimes => Website.FindChildren("numberOfTownHallTravelTimes", "input");
    private int TotalAlloyHarassment => Website.FindInt("totalAlloyHarassment");
    private int WorkerReplacementCost => Website.FindInt("workerReplacementCost");
    private int DelayedMiningCost => Website.FindInt("delayedMiningCost");
    private int AverageTravelTime => Website.FindInt("getAverageTravelTime");

    private int ExampleTotalAlloyLoss => Website.FindInt("exampleTotalAlloyLoss");
    private int ExampleWorkerCost => Website.FindInt("exampleWorkerCost");
    private int ExampleMiningTimeCost => Website.FindInt("exampleMiningTimeCost");
    private int ExampleTotalAlloyLossDifference => Website.FindInt("exampleTotalAlloyLossDifference");
    private int ExampleTotalAlloyLossAccurate => Website.FindInt("exampleTotalAlloyLossAccurate");
    private int ExampleTotalAlloyLossAccurateDifference => Website.FindInt("exampleTotalAlloyLossAccurateDifference");

    public HarassCalculatorPage SetWorkersLostToHarass(int number)
    {
        Website.EnterInput(NumberOfWorkersLostToHarass, number);
        return this;
    }

    public HarassCalculatorPage SetNumberOfTownHallsExisting(int number)
    {
        Website.EnterInput(NumberOfTownHallsExisting, number);
        return this;
    }

    public HarassCalculatorPage SetTownHallTravelTime(int forTownHall, int number)
    {
        Website.EnterInput(OnTownHallTravelTimes[forTownHall], number);
        return this;
    }

    public HarassCalculatorPage GetTotalAlloyHarassment(out int result)
    {
        result = TotalAlloyHarassment;
        return this;
    }


    public HarassCalculatorPage GetExampleTotalAlloyLoss(out int result)
    {
        result = ExampleTotalAlloyLoss;
        return this;
    }

    public HarassCalculatorPage GetExampleWorkerCost(out int result)
    {
        result = ExampleWorkerCost;
        return this;
    }

    public HarassCalculatorPage GetExampleMiningTimeCost(out int result)
    {
        result = ExampleMiningTimeCost;
        return this;
    }

    public HarassCalculatorPage GetExampleTotalAlloyLossAccurate(out int result)
    {
        result = ExampleTotalAlloyLossAccurate;
        return this;
    }

    public HarassCalculatorPage GetExampleTotalAlloyLossDifference(out int result)
    {
        result = ExampleTotalAlloyLossDifference;
        return this;
    }

    public HarassCalculatorPage GetExampleTotalAlloyLossAccurateDifference(out int result)
    {
        result = ExampleTotalAlloyLossAccurateDifference;
        return this;
    }
}