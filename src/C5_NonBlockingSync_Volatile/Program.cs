internal class Program
{
    public static void Main(string[] args)
    {
        Run();
    }
    
    static volatile int i = 0; // daha basit kurgularda düşünülebilir. tek bir keyword yardımı ile senkronizasyon sağlar
    // volatile, değişkenleri register'dan okumak yerine hafızadan okumayı sağlar.
    // Data register, aşırı hızlı bir yapı olduğu için [t - t++] zamanları arasında senkronizasyon sorunu yaratabilir
    
    private static void Run()
    {
        Thread th1 = new(() =>
        {
            while (true)
            {
                i++;
            }
        });
        
        Thread th2 = new(() =>
        {
            while (true)
            {
                Console.WriteLine(i);
            }
        });
        
        Thread th3 = new(() =>
        {
            while (true)
            {
                i--;
            }
        });

        th1.Start();
        th2.Start();
        th3.Start();
    }
}