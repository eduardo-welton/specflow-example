using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDD.Ferramentas;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD.Specflow
{
    [Binding]
    public sealed class CalculadoraSteps
    {
        private Calculator Calculator { get; set; }

        #region .: Propriedades utilizando ScenarioContext :.
        public List<double> Numeros
        {
            get
            {
                if (ScenarioContext.Current.ContainsKey("numeros"))
                {
                    return ScenarioContext.Current["numeros"] as List<double>;
                }

                return null;
            }
            set => ScenarioContext.Current[nameof(Numeros)] = value;
        }
        #endregion

        [BeforeScenario]
        public void SetupScenario()
        {
            Calculator = new Calculator();
            ScenarioContext.Current["numeros"] = new List<double>();
        }

        [Given(@"que eu entre com o valor (.*)")]
        public void DadoQueEuEntreComOValor(int number1)
        {
            var numbers = ScenarioContext.Current["numeros"] as List<double>;
            numbers.Add(number1);
        }

        [When(@"eu realizar a operação de soma")]
        public void QuandoEuRealizarAOperacaoDeSoma()
        {
            var numbers = ScenarioContext.Current["numeros"] as List<double>;
            var result = Calculator.Sum(numbers[0], numbers[1]);

            ScenarioContext.Current["resultado"] = result;
        }

        [Then(@"obterei o resultado (.*) da calculadora")]
        public void EntaoObtereiOResultadoDaCalculadora(int expectedNumber)
        {
            var result = (double)ScenarioContext.Current["resultado"];
            Assert.AreEqual(expectedNumber, result);
        }

        [Given(@"que eu tenha realizado a seguinte soma")]
        public void DadoQueEuTenhaRealizadoASeguinteSoma(Table table)
        {
            var row = table.Rows[0];
            var number1 = double.Parse(row["numero1"]);
            var number2 = double.Parse(row["numero2"]);

            Calculator.Sum(number1, number2);
        }

        [When(@"que eu adicionar (.*) ao meu resultado")]
        public void QuandoQueEuAdicionarAoMeuResultado(int number)
        {
            ScenarioContext.Current["resultado"] = Calculator.Sum(number);
        }

    }
}