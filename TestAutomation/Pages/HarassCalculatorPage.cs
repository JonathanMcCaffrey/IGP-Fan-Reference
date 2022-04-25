namespace TestAutomation.Pages; 

public class HarassCalculatorPage : BasePage {
    private IWebElement NumberOfWorkersLostToHarass => website.Find("numberOfWorkersLostToHarass");
    private IWebElement NumberOfTownHallsExisting  => website.Find("numberOfTownHallsExisting");
    private IList<IWebElement> OnTownHallTravelTimes  => website.FindChildren("numberOfTownHallTravelTimes", "input");
    private int TotalAlloyHarassment => website.FindInt("totalAlloyHarassment");
    private int WorkerReplacementCost  => website.FindInt("workerReplacementCost");
    private int DelayedMiningCost => website.FindInt("delayedMiningCost");
    private int AverageTravelTime  => website.FindInt("getAverageTravelTime");
    
    private int ExampleTotalAlloyLoss => website.FindInt("exampleTotalAlloyLoss");
    private int ExampleWorkerCost => website.FindInt("exampleWorkerCost");
    private int ExampleMiningTimeCost => website.FindInt("exampleMiningTimeCost");
    private int ExampleTotalAlloyLossDifference => website.FindInt("exampleTotalAlloyLossDifference");
    private int ExampleTotalAlloyLossAccurate => website.FindInt("exampleTotalAlloyLossAccurate");
    private int ExampleTotalAlloyLossAccurateDifference => website.FindInt("exampleTotalAlloyLossAccurateDifference");

    public HarassCalculatorPage(Website website) : base(website) { }

    public HarassCalculatorPage SetWorkersLostToHarass(int number) {
        website.EnterInput(NumberOfWorkersLostToHarass, number);
        return this;
    }
    
    public HarassCalculatorPage SetNumberOfTownHallsExisting(int number) {
        website.EnterInput(NumberOfTownHallsExisting, number);
        return this;
    }
    
    public HarassCalculatorPage SetTownHallTravelTime(int forTownHall, int number) {
        website.EnterInput(OnTownHallTravelTimes[forTownHall], number);
        return this;
    }
    
    public HarassCalculatorPage GetTotalAlloyHarassment(out int result) {
        result = TotalAlloyHarassment;
        return this;
    }
    
    
    public HarassCalculatorPage GetExampleTotalAlloyLoss(out int result) {
        result = ExampleTotalAlloyLoss;
        return this;
    }

    public HarassCalculatorPage GetExampleWorkerCost(out int result) {
        result = ExampleWorkerCost;
        return this;
    }

    public HarassCalculatorPage GetExampleMiningTimeCost(out int result) {
        result = ExampleMiningTimeCost;
        return this;
    }
    public HarassCalculatorPage GetExampleTotalAlloyLossAccurate(out int result) {
        result = ExampleTotalAlloyLossAccurate;
        return this;
    }
    public HarassCalculatorPage GetExampleTotalAlloyLossDifference(out int result) {
        result = ExampleTotalAlloyLossDifference;
        return this;
    }
    
    public HarassCalculatorPage GetExampleTotalAlloyLossAccurateDifference(out int result) {
        result = ExampleTotalAlloyLossAccurateDifference;
        return this;
    }
    
}