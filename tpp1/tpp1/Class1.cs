using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpp1
{
    class Phone
    {
        private string name;
        private string country;
        private double diagonal;
        private int price;
        private bool used;

        public Phone(string name, string country, double diagonal, int price, bool used)
        {
            this.name = name;
            this.country = country;
            this.diagonal = diagonal;
            this.price = price;
            this.used = used;
        }

        public string getName()
        {
            return this.name;
        }

        public string getCountry()
        {
            return this.country;
        }

        public double getDiagonal()
        {
            return this.diagonal;
        }

        public int getPrice()
        {
            return this.price;
        }

        public bool getUsed()
        {
            return this.used;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setCountry(string country)
        {
            this.country = country;
        }

        public void setDiagonal(double diagonal)
        {
            this.diagonal = diagonal;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public void setUsed(bool used)
        {
            this.used = used;
        }
    }
}
