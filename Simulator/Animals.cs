namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            value = value.Trim();

            if (value.Length > 15)
            {
                value = value.Substring(0, 15).TrimEnd();
            }

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            description = value.ToUpper()[0] + value[1..value.Length];

            description = value;
        }
    }


    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}