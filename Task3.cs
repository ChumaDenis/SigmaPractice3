using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    struct MonthlyUse
    {
        public double BeginningOfMonth; //Consumed at the beginning of the month
        public double EndOfMonth;
    }


    class AccountingElectricyty
    {

        private int QuarterNumber { get; set; }
        private ApartmentData[] District;
        public AccountingElectricyty()
        {
            string path = @"C:\ter\data.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] buf = sr.ReadToEnd().Split(' ', '\n');
                    District = new  ApartmentData [Convert.ToInt32(buf[0])];
                    QuarterNumber = Convert.ToInt32(buf[1]);



                    for (int i = 0, j = 2; j < buf.Length; i++)
                    {
                        int Num = Convert.ToInt32(buf[j++]);
                        string Surmane = buf[j++];
                        MonthlyUse[] Month = new MonthlyUse[3];

                        for(int k =0; k<3; k++)
                        {
                            Month[k].BeginningOfMonth = Convert.ToDouble(buf[j++]);
                            Month[k].EndOfMonth = Convert.ToDouble(buf[j++]);
                        }

                        District[i] = new ApartmentData(Num ,Surmane, Month);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintoutOfReport()
        {

            Console.WriteLine(String.Format( "The number of the quarter {0} in which there are {1} apartments", QuarterNumber, District.Length));
            for(int i=0; i<District.Length; i++)
            {
                District[i].Check();
            }
        }
        public void DataApartment(int i)
        {
            Console.WriteLine(String.Format("The number of the quarter {0}", QuarterNumber));
            District[i].Check();
        }


        public void TheGreatestAdoration(double price)
        {
            double MaxArrears=0;
            int iter = 0;
            for(int i=0; i<District.Length; i++)
            {
                if(MaxArrears<(District[i].Month[2].EndOfMonth- District[i].Month[0].BeginningOfMonth))
                {
                    MaxArrears = (District[i].Month[2].EndOfMonth - District[i].Month[0].BeginningOfMonth);
                    iter = i;
                }
            }
            DataApartment(iter);
            Console.WriteLine(String.Format("Debt is {0} in the amount {1} $", MaxArrears, MaxArrears*price));
        }


        public void NoElectricityWasUsed()
        {
            for (int i = 0; i < District.Length; i++)
            {
                if (0== (District[i].Month[2].EndOfMonth - District[i].Month[0].BeginningOfMonth))
                {
                    DataApartment(i);
                }
            }
            Console.WriteLine("No electricity was used in this apartment for the quarter");
        }
    }



    class ApartmentData
    {
        protected int NumOfApartment { get; set; }
        protected string Surname { get; set; }
        public MonthlyUse[] Month;
        
        public ApartmentData(int NumOfApartment, string Surname, MonthlyUse[] Month)
        {
            this.NumOfApartment = NumOfApartment;
            this.Surname = Surname;
            this.Month = Month;
        }

        public void Check()
        {
            Console.WriteLine(String.Format("Apartment by number {0} owned by {1}", NumOfApartment, Surname));
            Console.WriteLine(String.Format("Electricity was consumed at the beginning of the first month of the quarter {0} at the end {1}", Month[0].BeginningOfMonth, Month[0].EndOfMonth));
            Console.WriteLine(String.Format("Electricity was consumed at the beginning of the second month of the quarter {0} at the end {1}", Month[1].BeginningOfMonth, Month[1].EndOfMonth));
            Console.WriteLine(String.Format("Electricity was consumed at the beginning of the third month of the quarter {0} at the end {1}", Month[2].BeginningOfMonth, Month[2].EndOfMonth));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            AccountingElectricyty A = new AccountingElectricyty();
            //A.PrintoutOfReport();
            //A.DataApartment(3);
            //A.TheGreatestAdoration(12.3);
            A.NoElectricityWasUsed();
        }
    }
}
