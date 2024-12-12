#region SpinLock

/*
   * Spinning, blocking'e nazaran daha maliyetsizdir çünkü threadler durdurulmamakta ve işletim sistemine yük bindirilmemektedir.
   * Yalnız şu istisna bulunur; 
      * Blocking'de kaynakların boşalması beklenirken CPU döngüsünün kullanılması gerekmeyeceğinden dolayı, threadler pasif kalmaktadır.
      * Spinning'te ise CPU aktif kalacaktır ve boşuna bir tüketim söz konusu olacaktır.
      * Senaryoya bağlı olarak düşük ihtimalle de olsa kullanılabilir.  
 
   * SpinLock yapısı ile bir thread, t zamanda kullanılmakta olan kaynağa erişmeye çalışıyorsa; erişmek isteyen thread'i en kısa t+1 zamana kadar bekletir. (thread uyutulmaz!)
   * Ardından thread serbest kalıp hedef kaynağa erişir.
*/

int value = 0;

SpinLock spinLock = new SpinLock();

Thread th1 = new(() =>
{
   bool lockTaken = false;
   try
   {
      spinLock.Enter(ref lockTaken);
      if (lockTaken)
      {
         for (int i = 0; i < 999; i++)
         {
            Console.WriteLine($"Thread1: {++value}");
         }
      }
   }
   finally
   {
      spinLock.Exit();
   }
});

Thread th2 = new(() =>
{
   bool lockTaken = false;
   try // senkronizasyon durumlarında her zaman try-catch yapısına ihtiyacımız var. hata olma ihtimali her zaman var
   {
      spinLock.Enter(ref lockTaken);
      if (lockTaken)
      {
         for (int i = 0; i < 999; i++)
         {
            Console.WriteLine($"Thread2: {value--}");
         }
      }
   }
   finally
   {
      spinLock.Exit();
   }
});

//th1.Start();
//th2.Start();

#endregion

#region SpinWait

/*
   * SpinLock yapısına nazaran daha hafif bir hacme sahiptir
*/

bool waitMod = false, condition = false;

Thread th3 = new(() =>
{
   while (true)
   {
      if (waitMod)
      {
         continue;
      }

      if (!condition)
      {
         continue;
      }

      Console.WriteLine($"Thread3 işleniyor..");
   }
});

Thread th4 = new(() =>
{
   while (true)
   {
      SpinWait.SpinUntil(() =>
      {
         return waitMod || !condition;
      });

      Console.WriteLine($"Thread4 işleniyor..");
   }
});

th3.Start();
th4.Start();

#endregion