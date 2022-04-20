using System.ComponentModel.DataAnnotations;

namespace Model;

public class Variable
{
    [Key] public string Key { get; set; } = "";

    public string Value { get; set; } = "";
}