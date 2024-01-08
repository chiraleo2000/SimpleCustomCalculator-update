// SimpleCustomCalculator\Contorller\CalculatorControllers
using Microsoft.AspNetCore.Mvc;
using SimpleCustomCalculator.Models;
using Microsoft.Extensions.Configuration;

namespace SimpleCustomCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IConfiguration _configuration;

        public CalculatorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private CalculatorModel InitializeModel(string theme)
        {
            return new CalculatorModel
            {
                LightTheme = _configuration.GetSection("UI:Themes:Light").Get<ThemeSettings>(),
                DarkTheme = _configuration.GetSection("UI:Themes:Dark").Get<ThemeSettings>(),
                CurrentTheme = theme ?? _configuration["UI:InitialTheme"],
                HeaderName = _configuration["UI:HeaderName"],
                Version = _configuration["UI:Version"]
            };
        }

        public IActionResult Index()
        {
            return View(InitializeModel(null));
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model, string submitButton)
        {
            var newModel = InitializeModel(model.CurrentTheme);

            if (submitButton == "Switch Theme")
            {
                newModel.CurrentTheme = newModel.CurrentTheme == "Light" ? "Dark" : "Light";
            }
            else
            {
                newModel.Operand1 = model.Operand1;
                newModel.Operand2 = model.Operand2;
                newModel.Operation = model.Operation;

                // Perform the calculation based on the model.Operation
                switch (model.Operation)
                {
                    case "add":
                        newModel.Result = model.Operand1 + model.Operand2;
                        break;
                    case "subtract":
                        newModel.Result = model.Operand1 - model.Operand2;
                        break;
                    case "multiply":
                        newModel.Result = model.Operand1 * model.Operand2;
                        break;
                    case "divide":
                        newModel.Result = model.Operand2 != 0 ? model.Operand1 / model.Operand2 : 0;
                        break;
                }
            }

            return View(newModel);
        }
    }
}
