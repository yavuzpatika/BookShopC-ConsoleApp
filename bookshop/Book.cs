using System;
using System.Collections.Generic;
using System.Text;

namespace bookshop
{
    public class Book : BaseClass
    {

        public static List<Book> Books = new List<Book>();

        public string Name { get; set; } // kitabın adı
        public BookTypeEnums BookType { get; set; } // kitap türü
        public double CostPrice { get; set; } // maliyet fiyati
        public int TaxPercantage { get; set; } // toplam vergiyi belirtir
        public int ProfitMargin { get; set; } // kazanç yüzedi ör. 15 => %18
        public double Price { get; set; } // ürün fiyatı
        public int QTY { get; set; } // quantity qty -> stokdaki adedi gösterir



        //Constructors
        public Book(string _name, double _costPrice, BookTypeEnums _bookTypeEnums, int _taxPercantage = 1, int _profitMargin = 10, int _qty = 12)
        {
            Name = _name;
            CostPrice = _costPrice;
            BookType = _bookTypeEnums;
            TaxPercantage = _taxPercantage;
            ProfitMargin = _profitMargin;
            QTY = _qty;

            Price = calculatePrice(_costPrice, _taxPercantage, _profitMargin);
        }
        public double calculatePrice(double costPrice, int tax, int profitMargin)
        {
            double taxPrice = (costPrice * tax) / 100;
            double profitPrice = (costPrice * profitMargin) / 100;
            double Price = costPrice + taxPrice + profitMargin;
            return Price;
        }

        public static void addBook(Book book)
        {
            try
            {
                //kitp olusturuldu
                Books.Add(book);

                // ürün maliyeti hesaplanan Metot asyeside tutar hesaplandı
                double amount = CaseTransaction.calculateAmount(book.CostPrice, book.QTY);

                // Kasa hareketleri nesnesi olusturuldu
                CaseTransaction caseTransaction = new CaseTransaction(amount, TransactionTypeEnums.EXPENSE);

                //kasa haraketini kaydetmek icin  CaseTransaction sınıfındaki save metodu
                CaseTransaction.saveCaseTransaction(caseTransaction);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata olustu:" + ex.Message);
            }
        }


        public static void removeBook(int Id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == Id)
                {
                    Books.Remove(book);
                    Console.WriteLine("Kitabınız basari ile silindi");
                    break;
                }
            }

        }


        // satilacak kitabin id sini ve kac adet satildigini 
        public static void sellBook(int bookId, int bookQty)
        {
            foreach (Book kitap in Books)
            {
                if (kitap.Id == bookId)
                {
                    // satilan kitap miktari kitap listesindeki kitap bilgisinden cikarildi
                    // satilan kitap miktari toplam miktardan fazla ise hata
                    kitap.QTY = kitap.QTY - bookQty;

                    //satisi kasaya kaydetme islemleri

                    // satis tytarı hesaplandi
                    double satisTutar = CaseTransaction.calculateAmount(kitap.Price, bookQty);

                    // kasa hareketinden yeni bir object/ nesne  olusturuldu
                    CaseTransaction kasaHaraketi = new CaseTransaction(satisTutar, TransactionTypeEnums.INCOMING);
                    CaseTransaction.saveCaseTransaction(kasaHaraketi);

                    // olusturmus oldugum kasaHareketimi , kasa haraketi listeme ekledim
                    CaseTransaction.saveCaseTransaction(kasaHaraketi);

                }
            }

        }




        public override string ToString()
        {
            return string.Format("Id : {0} " + "Name:{1}, " + "Type: {2}, " + "Cost Price: {3}, " + "Price: {4} " + "Quantity: {5}", Id, Name, BookType, CostPrice, Price, QTY);
        }
    }
}
