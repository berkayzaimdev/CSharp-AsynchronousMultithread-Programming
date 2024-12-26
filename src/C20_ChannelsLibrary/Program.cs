/*
   * Producer-Consumer yaklaşımını, thread'ler arasında asenkron bir şekilde sergilememizi sağlayan yapılardır.
      * Producer -> channel writes async & Consumer -> channel reads async (ikisi de thread'tir)
   
   * Unbounded Channel : sınırsız kapasiteye sahiptir
   * Bounded Channel : kapasite ve davranış ctor'da BoundedChannelOptions sınıfı yardımıyla belirlenebilir
*/

using System.Threading.Channels;

var channel = Channel.CreateBounded<int>(new BoundedChannelOptions(5)
{    
    // FullMode = BoundedChannelFullMode.Wait, // default davranış. producer bloklanarak kapasitenin uygun hale gelmesi beklenir
    // FullMode = BoundedChannelFullMode.DropWrite, // yazılmaya çalışılan öğeler yoksayılır
    // FullMode = BoundedChannelFullMode.DropNewest, // en yeni öğe atılır, yerine yazılan öğe eklenir
    // FullMode = BoundedChannelFullMode.DropOldest, // en eski öğe atılır, yerine yazılan öğe eklenir
});

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 50; i++)
    {
        await channel.Writer.WriteAsync(i);
        await Console.Out.WriteLineAsync($"+ Produced => {i}");
        await Task.Delay(100);
    }
    
    channel.Writer.Complete(); // tüm mesajlar gönderildi. writing kanalı kapatılabilir
});

Task consumer = Task.Run(async () =>
{
    await foreach (var value in channel.Reader.ReadAllAsync()) // mesaj geldiği an taranır
    {
        await Console.Out.WriteLineAsync($"- Consumed => {value}");
        await Task.Delay(700); // eğer bu şekilde bir bekleme süresi verirsek, mesaj sayısı artıp kapasite dolacağı için producer mesaj tüketilene kadar bloklanır
    }
});

await Task.WhenAll(producer, consumer);