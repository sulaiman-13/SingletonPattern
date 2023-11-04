using SingletonPattern;

while (true)
{
    Console.WriteLine("please enter base currency :");
    var baseCurrency = Console.ReadLine();
    Console.WriteLine("please enter target Currency :");
    var targetCurrency = Console.ReadLine();
    Console.WriteLine("please enter target amount :");
    decimal amount = decimal.Parse(Console.ReadLine());

    
    var ExchangedAmount= CurrencyConvertor.Instance.Convert(baseCurrency, targetCurrency, amount);
    Console.WriteLine($"{amount} {baseCurrency}= {ExchangedAmount} {targetCurrency}");
    Console.WriteLine("------------------------------------------------------------------");


}