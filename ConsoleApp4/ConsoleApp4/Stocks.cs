using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ConsoleApp4{
    class Stocks
    {

        private long reference;//ref number
        private string description;//description of the item
        private double priceBT;//BT = Before Tax
        private int qttInStock;//Quantity in stock

        public Stocks(long r, string d, double p, int q)
        {
            reference = r;
            description = d;
            priceBT = p;
            qttInStock = q;
        }
        public long Reference
        {
            get { return reference; }
            set { reference = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double PriceBT
        {
            get { return priceBT; }
            set { priceBT = value; }
        }
        public int QttInStock
        {
            get { return qttInStock; }
            set { qttInStock = value; }
        }
        public void newStock(int units)
        {
            qttInStock = units;

        }
        public bool Sold(int unitsSold){
            if(unitsSold > qttInStock){
                return false;
            }
            else{
                qttInStock = qttInStock - unitsSold;
                return true;
            }
        }
        public double PriceTI(){//TI = Tax Included
        //Selon https://www.economie.gouv.fr/cedef/taux-tva-france-et-union-europeenne
        //<<Le taux normal de la TVA est fixé à 20 % (art. 278 du code général des impôts), pour la majorité des ventes de biens et des prestations de services : il s'applique à tous les produits ou services pour lesquels aucun autre taux n'est expressément prévu.>>
         double realPrice = (double)(priceBT*1.2);
         Console.WriteLine(realPrice);
         return realPrice;
        }
        public string toString(){
            string str = $"Reference Number : {reference} \nItem : {description} \nPrice Before And After Tax : {priceBT} => {priceBT*1.2}";
            Console.WriteLine(str);
            return str;
        }
        public bool Equals(Stocks anArticle){
            if(anArticle.reference == reference){
                Console.WriteLine("Identical Reference Numbers!!!");
                return true;
            }else{
                Console.WriteLine("Non-Identical Reference Numbers...");
                return false;
            }
        }

    }
}
