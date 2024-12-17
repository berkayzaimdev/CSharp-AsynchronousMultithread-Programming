#region Thread Local Storage (TLS)

/*
    * Her thread'a özel hafıza alanıdır diyebiliriz
    * Veri İzolasyonu sağlar. Her thread izole edilmiş kendi TLS örneğine erişebilir bu sayede senkronizasyon sağlanır.
    * Performans İyileşirmesi sağlar. Senaryoya bağımlı olarak her thread'e özel değişken kopyası tutma ihtiyacımız olabilir.
    * Bağlam İzlemeye yarar. Threadlerin birbirinden çalıştığı uygulamalarda kullanılabilir. (context a,b,c ayrı ayrı thread için izlenebilir)
*/

#endregion

#region ThreadStatic

// TLS kullanımının en kolay yoludur.
// Sadece static fieldlar ıçin kullanılmaktadır (adı üzerinde)

// internal class Program
// {
//     [ThreadStatic] 
//     static int x = 0;
//
//     public static void Main(string[] args)
//     {
//         Thread th1 = new(() =>
//         {
//             while (x<=10)
//             {
//                 Console.WriteLine($"Thread 1 -> {++x}");
//             }
//         });
//
//         Thread th2 = new(() =>
//         {
//             while (x<=10)
//             {
//                 Console.WriteLine($"Thread 2 -> {++x}");
//             }
//         });
//
//         Thread th3 = new(() =>
//         {
//             while (x<=10)
//             {
//                 Console.WriteLine($"Thread 3 -> {++x}");
//             }
//         });
//
//         th1.Start();
//         th2.Start();
//         th3.Start();  
//     }
// }

#endregion

#region ThreadLocal 

// ThreadLocal<int> x = new ThreadLocal<int>(() => 0);
//     
// Thread th1 = new(() =>
// {
//     while (x.Value <= 10)
//     {
//         Console.WriteLine($"Thread 1 -> {++x.Value}");
//     }
// });
//
// Thread th2 = new(() =>
// {
//     while (x.Value <= 10)
//     {
//         Console.WriteLine($"Thread 2 -> {++x.Value}");
//     }
// });
//
// Thread th3 = new(() =>
// {
//     while (x.Value <= 10)
//     {
//         Console.WriteLine($"Thread 3 -> {++x.Value}");
//     }
// });
//
// th1.Start();
// th2.Start();
// th3.Start();  

#endregion

#region GetData & SetData

// static tanımlamaya ihtiyaç duyarız.
// oluşturulan field için özel get-set metotları oluştururuz

internal class Program
{
    static LocalDataStoreSlot slot = Thread.GetNamedDataSlot("x");

    static int x
    {
        get
        {
            var data = (int?)Thread.GetData(slot);
            return data is null ? 0 : data.Value;
        }

        set
        {
            Thread.SetData(slot, value);
        }
    }

    public static void Main(string[] args)
    {
        Thread th1 = new(() =>
        {
            while (x<=10)
            {
                Console.WriteLine($"Thread 1 -> {++x}");
            }
        });

        Thread th2 = new(() =>
        {
            while (x<=10)
            {
                Console.WriteLine($"Thread 2 -> {++x}");
            }
        });

        Thread th3 = new(() =>
        {
            while (x<=10)
            {
                Console.WriteLine($"Thread 3 -> {++x}");
            }
        });

        th1.Start();
        th2.Start();
        th3.Start();  
    }
} 

#endregion