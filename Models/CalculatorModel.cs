// SimpleCustomCalculator\Models\CalculatorModel
namespace SimpleCustomCalculator.Models
{
    public class ThemeSettings
    {
        public string? ButtonColor { get; set; }
        public string? InputBoxColor { get; set; }
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
    }

    public class CalculatorModel
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string? Operation { get; set; }
        public double Result { get; set; }
        public ThemeSettings? LightTheme { get; set; }
        public ThemeSettings? DarkTheme { get; set; }
        public string? CurrentTheme { get; set; }
        public string? HeaderName { get; set; }
        public string? Version { get; set; }
    }
}
