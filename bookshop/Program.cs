using System;

namespace bookshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int secim = 0;
            while (secim != 8)
            {


                Console.WriteLine("1- Kitap Ekle");
                Console.WriteLine("2- Kitap Silme");
                Console.WriteLine("3- Kitap Güncelleme");
                Console.WriteLine("4- Kitap Satış");
                Console.WriteLine("5- Kitap Listeleme");
                Console.WriteLine("6- Kitap Ara ");
                Console.WriteLine("7- Kasa Haraketleri");
                Console.WriteLine("8- Kasa Cikis");

                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        kitapEkleCase();
                        break;


                    case 2:
                        kitaplariListele();
                        Console.Write("Silmek istediğiniz kitap Idsi");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Book.removeBook(bookId);

                        break;
                    case 3:
                        Console.Write("Guncelleneek kitap idsini girermisiniz");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        updateBook(updateId);
                        break;
                    case 4:
                        kitaplariListele();
                        Console.Write("Satilan kitap idsini girermisiniz");
                        int satilanKitapId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Satilan kitap adetini girermisiniz");
                        int satilanKitapAdeti = Convert.ToInt32(Console.ReadLine());

                        Book.sellBook(satilanKitapId, satilanKitapAdeti);
                        kitaplariListele();

                        break;

                    case 5:
                        kitaplariListele();


                        break;

                    default:
                        break;

                    case 7:
                        CaseTransaction.kasaHaraketleriniListele();
                        break;

                }

            }



            //int sayac = 0;
            //Random rastgele = new Random();
            //while (sayac < 50)
            //{

            //    Book book = new Book("Kitap "+(sayac+1),//kitap adi
            //                         rastgele.Next(35,51), // maliyey fiyatı
            //                         (BookTypeEnums)rastgele.Next(0,5), //
            //                         rastgele.Next(1,21), // vergi orani
            //                         rastgele.Next(10,31), //kazanc orani
            //                         rastgele.Next(1,16) //miktar
            //                         ) ;

            //    // olusturulan kitap listeye eklendi
            //    Book.addBook(book);
            //    sayac++;


            //        Console.WriteLine(book);

            foreach (CaseTransaction caseTransaction in CaseTransaction.CaseTransactions)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(caseTransaction.ToString());
            }
        }

        public static void kitapEkleCase()
        {
            // Kitap ekleme
            // adı, maliyet fiyati, turu, tax, kazanc orani, adet

            //Kitap adi
            Console.Write("Kitap Adi");
            string bookName = Console.ReadLine();

            //Kitap Maliyeti
            Console.Write("Kitap Maliyeti");
            double costPrice = Convert.ToDouble(Console.ReadLine());

            //Kitap Turu
            Console.Write("Kitap turu");
            BookTypeEnums bookType = (BookTypeEnums)Convert.ToInt32(Console.ReadLine());

            //vergi orani
            Console.Write("Vergi orani");
            int taxPrecantage = Convert.ToInt32(Console.ReadLine());

            //Kazanc orani 
            Console.Write(" Kazanc orani");
            int profitMargin = Convert.ToInt32(Console.ReadLine());

            // Adeti
            Console.Write("Adeti");
            int qty = Convert.ToInt32(Console.ReadLine());

            Book newbook = new Book(bookName, costPrice, bookType, taxPrecantage, profitMargin, qty);
            Book.addBook(newbook);
        }

        public static void kitaplariListele()
        {
            Console.WriteLine("KITAP LISTESI");
            foreach (Book item in Book.Books)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(item.ToString());
            }
        }

        public static void updateBook(int Id)
        {

            foreach (Book book in Book.Books)
            {
                if (book.Id == Id)
                {
                    //Kitap adi
                    Console.Write("Kitap Adi");
                    string bookName = Console.ReadLine();

                    //Kitap Maliyeti
                    Console.Write("Kitap Maliyeti");
                    double costPrice = Convert.ToDouble(Console.ReadLine());

                    //Kitap Turu
                    Console.Write("Kitap turu");
                    BookTypeEnums bookType = (BookTypeEnums)Convert.ToInt32(Console.ReadLine());

                    //vergi orani
                    Console.Write("Vergi orani");
                    int taxPrecantage = Convert.ToInt32(Console.ReadLine());

                    //Kazanc orani 
                    Console.Write(" Kazanc orani");
                    int profitMargin = Convert.ToInt32(Console.ReadLine());

                    // Adeti
                    Console.Write("Adeti");
                    int qty = Convert.ToInt32(Console.ReadLine());


                    Book newbook = new Book(bookName, costPrice, bookType, taxPrecantage, profitMargin, qty);
                    Book.addBook(newbook);
                }


            }
        }
    }
}
