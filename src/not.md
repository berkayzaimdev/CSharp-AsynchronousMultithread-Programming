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
