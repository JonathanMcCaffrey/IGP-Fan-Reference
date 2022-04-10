using System.Collections.Generic;

namespace Model.MemoryTester;

public class MemoryEntityModel
{
    public static List<MemoryEntityModel> TestData = new()
    {
        new MemoryEntityModel { Id = 1, Name = "Masked Hunter" },
        new MemoryEntityModel { Id = 2, Name = "Scepter" },
        new MemoryEntityModel { Id = 3, Name = "Wraith Bow" },
        new MemoryEntityModel { Id = 4, Name = "Thrum" }
    };

    public int Id { get; set; }
    public string Name { get; set; }
}