using System.ComponentModel.Design;

namespace Sayi_Tahmin_Oyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dosyaAdi = "st.dat";
            //string dosyaAdi2 = "kb.dat";

            string secim = "E";

            int sayac = 0;


            //&& File.Exists(dosyaAdi2) == true
            if (File.Exists(dosyaAdi) == true)
            {
                string okunan = File.ReadAllText(dosyaAdi);
                //string okunan2 = File.ReadAllText(dosyaAdi2);
                // icini oku

                int okunanSayi = Convert.ToInt32(okunan);
                // inte cevir

                // sayaci degistir
                sayac = okunanSayi;
            }

            do
            {
                // Bilgisayarın 1'den 5'a rastgele bir sayı tutmasını sağlayalım
                sayac++;
                int tutulan = Random.Shared.Next(1, 5);
                int tahmin;
                string girilen;
                int m = 0;//maglubiyet
                int g = 0;//galibiyet
                int n = 0;// deneme sayısı
                int oyunAdedi = 5; // Oynanacak oyun adedini belirliyoruz

                Console.WriteLine("Lütfen 0 ile 6 Arasındaki Tahmininizi Giriniz:");
                do
                {
                    girilen = Console.ReadLine();

                    if (oyunAdedi - n > 2 && int.TryParse(girilen, out tahmin))
                    {
                        Console.WriteLine("Son " + (oyunAdedi - n - 1) + " Hakkınız!");
                    }

                    else if (oyunAdedi - n == 2 && int.TryParse(girilen, out tahmin))
                    {
                        Console.WriteLine("Son Hakkınız!");

                    }

                    if (!int.TryParse(girilen, out tahmin))
                    {
                        Console.WriteLine("Lütfen Geçerli Bir Tahmin Giriniz: ");
                    }

                    else if (tahmin == tutulan)
                    {
                        Console.WriteLine("TEBRİKLER BİLDİNİZ");

                        if (n < oyunAdedi - 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Tahmine Devam");

                        }
                        tutulan = Random.Shared.Next(1, 4);
                        g++;
                        n++;
                        //Console.WriteLine("Son " + (oyunAdedi - n) + " Hakkınız!");
                    }

                    else if (tahmin > tutulan)
                    {
                        if (n == oyunAdedi - 1)
                        {
                            Console.WriteLine("Maalesef Bilemediniz");
                            m++;
                            n++;
                        }
                        else
                        {
                            Console.WriteLine("Bilemediniz, Lütfen Daha Düşük Bir Değer Giriniz:");
                            m++;
                            n++;
                            //Console.WriteLine("Son " + (oyunAdedi - n) + " Hakkınız!");
                        }
                    }
                    else
                    {
                        if (n == oyunAdedi - 1)
                        {
                            Console.WriteLine("Maalesef Bilemediniz");
                            m++;
                            n++;
                        }
                        else
                        {
                            Console.WriteLine("Bilemediniz, Lütfen Daha Büyük Bir Değer Giriniz:");
                            m++;
                            n++;
                        }
                    }

                } while (n != oyunAdedi);

                Console.WriteLine();
                Console.WriteLine(g + " Kez Bildiniz " + m + " Kez Bilemediniz");
                Console.WriteLine();
                Console.WriteLine("Tekrar Oynayalim Mi (E/H)?");
                secim = Console.ReadLine();

            } while (secim == "E" || secim == "e");

            Console.WriteLine(sayac + " Adet Oyun Oynadik. Yine Gel.");

            File.WriteAllText(dosyaAdi, Convert.ToString(sayac));
        }

    }

}