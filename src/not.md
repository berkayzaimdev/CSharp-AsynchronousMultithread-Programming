# C#'ta Asenkron ve Multithread Programlama
---
## Ders 1

#### Asenkron vs. Senkron

- Senkron: Thread'ler birbirine bağımlı bir şekilde, sıralı olarak çalışır. Görevler çalışmak için birbirini bekler.
- Asenkron: Thread'ler birbirinden bağımsız bir şekilde, sırasız olarak çalışır. Görevlerin birbirini beklemesi gerekmez.
- Bu iki yaklaşımın ikisini de bir veya birden fazla thread üzerinde uygulayabiliriz.
- Esasında senkron ve asenkron kavramlarının thread ile bir ilgisi yoktur. Nadiren olsa da, bir thread üzerine çalışan asenkron görevler bulunabilir


#### Asenkron Programlama vs. Multithread Programlama

- Asenkron Programlama: 
	<ul style="list-style-type: square;">
	  <li>Asenkron yaklaşımı benimseyen programlama türüdür.</li>
	  <li>Bir veya birden fazla thread üzerinde uygulanabilir.</li>
	  <li>Amacımız kodun çalıştığı thread'i bloklatmaksızın sistemin işleyişini devam ettirmektir.</li>
	  <li>Düşük bir bellek kullanımına sahiptir.</li>
	  <li>Kod akışları birbirinden bağımsız seyredeceği için, eşzamanlılık nadir gelişen bir durumdur.</li>
	  <li>Web uygulamalarında, IO operasyonlarında ya da event-driven sistemlerde performans açısından oldukça verimlidir.</li>
	  <li>İşlemlerin birbirinden bağımsız olmasından ötürü debug süreci daha kolaydır.</li>
	</ul>

- Multithread Programlama: 
	<ul style="list-style-type: square;">
	  <li>Kod, direkt olarak thread odaklı bir şekilde birden fazla thread'e bölünür ve bu şekilde yürütülür.</li>
	  <li>Bu thread'ler aynı bellek alanını paylaşabilir ve birbirleriyle etkileşimde bulunabilir.</li>
	  <li>Her thread koşmak için ayrı bir bellek alanına ihtiyaç duyacağı için bellek maliyetli bir durum oluşturur.</li>
      <li>Birden fazla thread, aynı anda paylaşılan kaynaklara erişebileceği için eşzamanlık sorunu yaşanabilir.</li>
	  <li>Çoklu işletim sistemlerinde yahut yoğun hesaplama gerektiren işlemlerde kullanılabilir.</li>
	  <li>Eşzamanlık sorunları sebebiyle debug daha zordur.</li>
	</ul>

---

## Ders 2

- Main fonksiyonun kendisi bir **Main Thread**'dir.
- Kod yordamıyla oluşturup koşturduğumuz her bir thread ise bir **Worker Thread**'dir.
- Main ve Worked Thread'ler paralel bir çalışma sergiler ve hangisinin ne zaman çalıştığı, şayet senkron iseler, race condition'a göre değişkenlik gösterir.

### Thread ID

- Bir thread'in tanımlayıcısıdır. Bu kavrama C Programlama sayesinde çok da yabancı değiliz
- Uygulama debug edilirken karşımıza çıkar ID'ler tam olarak Thread ID'yi tanımlar.
- Koşmakta olan thread'in ID'sini elde etmek için şu üç yöntemden birine başvurabiliriz;
	- ```System.Environment.CurrentManagedThreadId```
	- ```AppDomain.GetCurrentThreadId() ``` *(deprecated)*
	- ```Thread.CurrentThread.ManagedThreadId```

### IsBackground Property'si

- Bir thread'in koşması Main Thread'e bağlıysa **true** deriz. Bu şekilde işaretlenmiş bir thread, Main Thread sonlandığı an işleminin neresinde olursa olsun sonlandırılır.
- false değerine sahip olursa; işaretli olan thread sonlanmadığı sürece, Main Thread sona ermez yani uygulama sonlanmaz. Default değer, false'tur.
- **Foreground Thread**'ler ise, Main Thread sonlansa dahi çalışmaya devam eder.


### Thread State'i

- Thread durumunu bize veren bir enum türüdür.

	- Unstarted -> Thread'in henüz başlamadığını ifade eder.
	- Running -> Thread'in çalıştığını ifade eder.
	- Background -> Thread'in arkaplanda çalıştığını ifade eder.
	- StopRequested -> Thread'in durdurulması istenmiştir.
	- SuspendRequested -> Thread'in askıya alınması istenmiştir
	- AbortRequested -> Thread'in abort edilmesi istenmiştir.
	- Stopped -> Thread sonlandırılmıştır.
	- Suspended -> Thread askıya alınmıştır.
	- Aborted -> Thread aniden sonlandırılmıştır.
	- WaitSleepJoin -> Thread ya başka bir thread'i beklemekte, ya da uykudadır.

---

## Ders 3

### Thread Synchronization nedir?

- Race condition'dan kaynaklanan **deadlock**, **veri bozulması** ve **performans kaybı** gibi durumları önlemeyi sağlayan bir yaklaşımlar bütünüdür.
- Ne CLR ne de İşletim Sistemi tarafından sağlanan bir yaklaşım olmamasından ötürü, bizim sağlamamız gereken bir durum olarak karşımıza çıkar.
- Blocking ve Non-Blocking Synchronization olmak üzere ikiye ayrılır;

	- **Blocking Synchronization**
		- Bir thread, diğer bir thread'in tamamlanmasını veya veriye erişimini beklemektedir.
		- Bu bekleme, belirli bir koşula bağlı olabileceği gibi **locking** mekanizmalarıyla da sağlanabilir.
		- Bloke edilen thread, diğer thread'in işi bittikten sonra devam eder.

	- **Non-Blocking Synchronization**
		- Thread'ler birbirini bloke etmeksizin eşzamanlı olarak çalışırlar.

### Spinning nedir?

- **Blocking Synchronization**'a  benzer bir yaklaşımdır.
- Thread'leri belirli bir koşula karşın döngü ile bloklatmayı sağlar.
- Beklenen koşul gerçekleşene kadar thread'in aktif bir şekilde çalışmasını sağlar. Bu bekleyiş, **busy-waiting** veya **spinning** bekleyiş olarak ifade edilebilir.

---

## Ders 5

### Blocking Synchronization

#### Avantajları
- Basitlik ve Kolaylık
	- Daha basit bir senkronizasyon yöntemidir ve daha anlaşılır bir yazımı vardır.
- Stabilite ve Güvenilirlik
	- Belirli bir kaynağa t zamanda sadece tek bir thread'in erişimine izin verir, bu da senkronizasyonu sağlar.

#### Dezavantajları
- Performans Sorunları
	- Thread'ler bekletildiği için performans sıkıntıları yaşanabilir.
- Deadlock & Race Condition
	- Kilitleme bu durumlara yol açabilir.
- Ölçeklenebilirlik Sorunları
- Uyku & Uyanma Maliyeti
	- Thread'lerin bekletilmesi, OS düzeyinde uyandırma maliyetini ortaya çıkarır. Bu da kaynak tüketimi yaratan bir durumdur.



### non-Blocking Synchronization

#### Avantajları
- Performans
	- Bloklanma olmadığı için kaynaklar daha etkili kullanılır.
- Kullanılabilirlik
	- Kod karmaşası azalır, kullanım kolaylaşır.

#### Dezavantajları
- Uygulama Karmaşıklığı
	- Kod karmaşıklığı azalmakta , fakat bu yöntem daha karmaşık algoritmalar özelinde kullanıldığı için yine de bir karmaşıklık oluşacaktır
- Bellek Kullanımı
	- Bazen fazla kullanıma neden olabilir
- Güvenlik
	- Yanlış kullanıldığı takdirde güvenlik açığı yaratabilir.

### volatile Keyword

- 