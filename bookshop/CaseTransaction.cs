using System;
using System.Collections.Generic;
using System.Text;

namespace bookshop
{
    class CaseTransaction : BaseClass
    {
        public static List<CaseTransaction> CaseTransactions = new List<CaseTransaction>();
            public double Amount { get; set; }  //tutar

            public TransactionTypeEnums TransactionType { get; set; }



        //CaseTransaction Sınıfımın constructor
        //yapici method
        public CaseTransaction(double _amount, TransactionTypeEnums _transactionType)
        {
            Amount = _amount;
            TransactionType = _transactionType;
        }

        // kasa işlemesi kaydetme methodum
        public static void saveCaseTransaction(CaseTransaction caseTransaction)
        {
            CaseTransactions.Add(caseTransaction);
        }



        public static double calculateAmount(double price, int qty)
        {
            return price * qty;
        }

        public static void kasaHaraketleriniListele()
        {
            Console.WriteLine("KASA HARAKETLERİ");
            double kasaToplam = 0;

            foreach(CaseTransaction kasaHaraketi in CaseTransactions)
            {
                Console.WriteLine("-----------------------------------");
                if(kasaHaraketi.TransactionType == TransactionTypeEnums.EXPENSE)
                {
                    kasaToplam -= kasaHaraketi.Amount;

                    
                }
                else
                {
                    kasaToplam -= kasaHaraketi.Amount;

                }
                Console.WriteLine(kasaHaraketi.ToString());
            }
            Console.WriteLine("Kasa Toplam Tutarı: " + kasaToplam);
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - Type: {1} - " + "Amount: {2} - Crated Time: {3}"+ Id, TransactionType, Amount, CreatedTime);
        }




        //public int Id { get; set; }
        //public double Amount { get; set; } // tutar
        //public DateTime CreatedTime { get; set; }
        //public DateTime UpdatedTime { get; set; }
    }
}
