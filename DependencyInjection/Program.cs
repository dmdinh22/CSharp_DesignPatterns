using CSharp_DesignPatterns.Interfaces;
using CSharp_DesignPatterns.IOC;
using NodaTime;

namespace CSharp_DesignPatterns.DependencyInjection
{
    public class Program
    {
        static void Main()
        {
            Injector injector = new Injector();
            var presenter = injector.CreateDiaryPresenter()
            presenter.Start();
        }
    }
}