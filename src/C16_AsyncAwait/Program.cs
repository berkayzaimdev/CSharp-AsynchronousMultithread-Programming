// async & await ⭐

#region async

// Bir metodun asenkron operasyon yapacağını ifade eder.
// Asenkron işlevin olacağı metodun imzası, bu keyword ile işaretlenir.
// Bu işaretleme sonucu dönecek sonuç mutlaka; void, Task ya da Task<T> olmalıdır.
// "async Task<T>" (void de dahil) türünden işaretleme yaptıysak, "return T;" deriz. Aksi takdirde "return Task<T>;" deriz.

#region async Keyword'ün Sağladığı Avantajlar

// Await kullanımına izin verir;
   // metot içinde await kullanımına olanak tanır
   // bu sayede asenkron işlemler senkron bir biçimde yazılabilir

// Daha kolay hata yönetimi sağlar;
   // async-await kullanımı asenkron işlemler sırasında meydana gelen hataların try-catch yapısı ile kolayca yakalnmasını sağlar

#endregion

// async Task<string> ReadFile()
// {
//    StreamReader streamReader = new("...");
//    string result1 = streamReader.ReadToEnd();
//    string result2 = await streamReader.ReadToEndAsync();
//
//    return result2;
// }
//
// var result1 = ReadFile();
// var result2 = await ReadFile();

#endregion

#region await

// Asenkron bir metodun senkron olarak çalıştırılmasını bekler!

#endregion

#region Dikkat Edilmesi Gerekenler

// Ctor, Dtor ve property gibi yapılarda async-await kullanılamaz
// Ctor içerisinde asenkron işlemlerden kaçınılmalıdır. Ctor senkron çalışır ve asenkron işlemleri desteklemez

// Neden "async void" imzası kullanmamalıyız?
   // bu imza ile işaretlenmiş metotlar, senkron kod ve asenkron kod arasındaki sınırları bulanıklaştırır. Bu yüzden kodun akışı ve kontrolü zorlaşır.
   // metodu çağıran taraf, metotların tamamlanıp tamamlanmadığını kontrol edemez. bu, özellikle bir işlemin tamamlanması beklendiğinde sorun yaratır.
   // bu imza kullanımı halinde oluşan bir hata, çağıran tarafa bildirilmez! bu durum hataların tespit ve kontrolünü zorlaştırır.

#endregion

async void ReadFile()
{
   throw new Exception("test1");
}

async Task ReadFileAsync()
{
   throw new Exception("test2");
}

try
{
   ReadFile(); // hata yakalanamaz
   await ReadFileAsync(); // hata yakalanır
}
catch (Exception e)
{
   Console.WriteLine(e);
   throw;
}