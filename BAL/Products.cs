using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Products
    {
        private Boolean checkdata;

        public Boolean check
        {
            get { return checkdata; }
            set { checkdata = value; }
        }

        public int ProductID { get; set; }

        private string _prodname;
        public string ProductName
        {
            get
            {
                return _prodname;
            }
            set
            {
                //_prodname = value;
                if (value.Length > 40)
                {
                    throw new FormatException("lengtht of product name cannot be greater than 40 chars");
                }
                else
                {
                    _prodname = value;
                }
            }
        }
        public string QtyPerUnit { get; set; }

        private double _price;

        public double UnitPrice
        {
            get { return _price; }
            set
            {
                //_price = value;
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new DivideByZeroException("Price cannot be 0");
                }

            }
        }


        private int? _catid;
        public int? CategoryID
        {
            get
            {
                return _catid;
            }
            set
            {

                if (value != null)
                {
                    _catid = value;
                }
                else
                {
                    throw new NullReferenceException("Category id cannot be null");
                }
            }

        }
        private int? SupID;

        public int? SupplierID
        {
            get { return SupID; }
            set { SupID = value; }
        }

    }
}

