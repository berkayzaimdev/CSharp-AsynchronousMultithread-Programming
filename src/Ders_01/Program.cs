X();
Y();

Console.ReadLine();

async void X()
{
    await Task.Run(() =>
    {
        for (int i = 0; i < 1000; i++) // veri seti büyüdükçe asenkron operasyonlar arasındaki rastgelelik de o oranda artacaktır
        {
            Console.WriteLine($"X -> {i}");
        }
    });
}

async void Y()
{
    await Task.Run(() =>
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine($"Y -> {i}");
        }
    });
}
