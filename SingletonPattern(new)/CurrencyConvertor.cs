using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class CurrencyConvertor
    {
        private IEnumerable<ExchangeRate> _exchangeRates;
        private static object _lock = new();
        private static CurrencyConvertor _instance;


        private CurrencyConvertor()
        {
            LoadExchangeRates();
        }
        public static CurrencyConvertor Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CurrencyConvertor();
                        }
                    }
                }
                return _instance;
            }
        }

        private void LoadExchangeRates()
        {
            Thread.Sleep(3000);
            _exchangeRates = new[]
            {
                new ExchangeRate("USD", "SYR", 10000m),
                new ExchangeRate("USD", "SAR", 3.75m),
                new ExchangeRate("SAR", "EGY", 8.16m),
            };
        }
        public decimal Convert(string baseCurrency, string targetCurrency, decimal amount)
        {
            var exchangerate = _exchangeRates.FirstOrDefault(r => r.BaseCurrency == baseCurrency && r.TargetCurrency == targetCurrency);
            return amount * exchangerate.Rate;
        }
    }
}
