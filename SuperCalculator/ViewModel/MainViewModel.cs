using System;
using System.Windows.Input;
using SuperCalculator.Extra;

namespace SuperCalculator.ViewModel {
    public class MainViewModel : ViewModel {
        private string _value;
        private double operand;
        private string Operator;

        public String Value {
            get => _value;
            set => SetField(ref _value, value);
        }

        public ICommand OnDigitClicked => new CommandDelegate(parameter => { Value += parameter.ToString(); });

        public ICommand OnActionClicked => new CommandDelegate(parameter => {
            operand = Double.Parse(Value);
            Operator = parameter.ToString();
            Value = "";
        });

        public ICommand OnEqualClicked => new CommandDelegate(parameter => {
            double secondOperand = Double.Parse(Value);
            double result = 0;
            switch (Operator) {
                case "+":
                    result = operand + secondOperand;
                    break;
                case "/":
                    result = operand / secondOperand;
                    break;
                case "*":
                    result = operand * secondOperand;
                    break;
                case "-":
                    result = operand - secondOperand;
                    break;
            }

            Value = $"{result}";
        });
    }
}