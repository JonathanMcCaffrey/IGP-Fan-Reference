using Model.Entity;
using Model.Types;

namespace Services.Immortal;

public class GameLogicService : IGameLogicService
{
    private ITimingService timingService;
    private IEconomyService economyService;
    private IBuildOrderService buildOrderService;
    
    public GameLogicService(ITimingService timingService, IEconomyService economyService, IBuildOrderService buildOrderService)
    {
        this.timingService = timingService;
        this.economyService = economyService;
        this.buildOrderService = buildOrderService;
    }
    
    public bool Add(EntityModel entity, int atInterval)
    {
        throw new NotImplementedException();
    }

    public int MeetsRequirements(EntityModel entity, int interval)
    {
        var buildOrders = buildOrderService.GetCompletedBefore(interval);
        
        
        
       
        return -1;
    }

    public int MeetsAlloy(EntityModel entity, int interval)
    {
        throw new NotImplementedException();
    }

    public int MeetsEther(EntityModel entity, int interval)
    {
        throw new NotImplementedException();
    }

    public int MeetsPyre(EntityModel entity, int interval)
    {
        throw new NotImplementedException();
    }

    public int MeetsSupply(EntityModel entity, int interval)
    {
        throw new NotImplementedException();
    }

    public int MeetsTrainingQueue(EntityModel entity, int interval)
    {
        throw new NotImplementedException();
    }
}