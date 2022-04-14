using Model.Entity;
using Model.Entity.Data;
using Model.MemoryTester;
using static Services.IMemoryTesterService;

namespace Services.Immortal;

public enum MemoryTesterEvent {
    OnVerify,
    OnRefresh
}

public class MemoryTesterService : IMemoryTesterService {
    private readonly List<MemoryEntityModel> memoryEntities = MemoryEntityModel.TestData;
    private readonly List<MemoryQuestionModel> memoryQuestions = MemoryQuestionModel.TestData;


    private readonly Random random = new();

    
    private event MemoryAction OnChange = null!;

    
    public void Subscribe(MemoryAction action) {
        OnChange += action;
    }

    public void Unsubscribe(MemoryAction action) {
        OnChange -= action;
    }

    public void GenerateQuiz() {
        memoryEntities.Clear();
        memoryQuestions.Clear();

        //TODO redo this
        var units = (from entity in EntityModel.GetListOnlyHotkey()
            where entity.EntityType == EntityType.Army
            where entity.Weapons().Count > 0
            select entity).OrderBy(entity => random.Next()).Take(4).ToList();

        var entityIndex = 0;
        var questionIndex = 0;

        foreach (var unit in units) {
            memoryEntities.Add(new MemoryEntityModel {
                Id = ++entityIndex,
                Name = unit.Info().Name
            });

            var weaponIndex = 0;
            foreach (var weapon in unit.Weapons()) {
                weaponIndex++;

                memoryQuestions.Add(new MemoryQuestionModel {
                    Id = ++questionIndex,
                    MemoryEntityModelId = entityIndex,
                    Name = $"Range (Weapon {weaponIndex})",
                    Answer = weapon.Range,
                    IsRevealed = entityIndex == 1 || entityIndex == 3
                });
            }

            memoryQuestions.Add(new MemoryQuestionModel {
                Id = ++questionIndex,
                MemoryEntityModelId = entityIndex,
                Name = "Speed",
                Answer = (int)unit.Movement().Speed,
                IsRevealed = entityIndex == 1 || entityIndex == 2
            });
        }

        NotifyDataChanged(MemoryTesterEvent.OnRefresh);
    }

    public List<MemoryEntityModel> GetEntities() {
        return memoryEntities;
    }

    public List<MemoryQuestionModel> GetQuestions() {
        return memoryQuestions;
    }

    public void Update(MemoryQuestionModel memoryQuestion) {
        memoryQuestions[memoryQuestion.Id - 1].Guess = memoryQuestion.Guess;
    }

    public void Verify() {
        NotifyDataChanged(MemoryTesterEvent.OnVerify);
    }


    //public delegate void MemoryAction(MemoryTesterActions memoryAction);

    private void NotifyDataChanged(MemoryTesterEvent memoryAction) {
        OnChange?.Invoke(memoryAction);
    }

}