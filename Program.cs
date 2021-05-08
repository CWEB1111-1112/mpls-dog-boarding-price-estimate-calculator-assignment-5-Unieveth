using System;

namespace mpls_dog_boarding_price_estimate_calculator_assignment_5_Unieveth
{
    class Program
    {
        static void Main(string[] args)
        {
          //Create a three object instances of Estimate and output data using toString Method from Estimate class  
          string owner, name, services;
          double weight;
          int days;

          Estimate [] estimatesList = new Estimate[3];

          for (int i = 0; i < estimatesList.Length - 1; i++)
          {
              Console.WriteLine("What is your Name? ");
              owner = Console.ReadLine();
              
              Console.WriteLine("What is your dog's name? ");
              name = Console.ReadLine();
              
              Console.WriteLine($"What is {name}'s weight? ");
              weight = Convert.ToDouble(Console.ReadLine());
              
              Console.WriteLine($"How many days will {name} be staying? ");
              days = Convert.ToInt32(Console.ReadLine());
              
              Console.WriteLine("What services would you like to addon? \n\tA = Bathing & Grooming \n\tC = Bathing Only");
              services = Console.ReadLine();

              estimatesList[i] = new Estimate(days, services, owner, name, weight);
              
              Console.WriteLine(estimatesList[i]);

          }
        }

        //Create a class called Estimate
    }

    class Estimate
    {
        public string Owner { get; }
        public string Name { get;}
        public double Weight { get; }
        public int Days { get;}
        public int Total = 0;
        
        public const int Night = 75;
        public const int A = 169;
        public const int C = 112;
        public string AddOn { get; set; }
        
        public Estimate(int numDays, string serviceCode, string ownerName, string dogName, double dogWeight)
        {
            Days = numDays;
            AddOn = serviceCode;
            Owner = ownerName;
            Name = dogName;
            Weight = dogWeight;
            generateCost();
        }
        
        public void generateCost(){
            string sel = this.AddOn.ToUpper();
            while(sel != "A" && sel != "C"){
                Console.WriteLine("You have entered an invalid code \n\tA = Bathing & Grooming \n\tC = Bathing");
                this.AddOn = Console.ReadLine();
                sel = this.AddOn.ToUpper();
            }

            Console.WriteLine($"Will {Name} be staying overnight? Y/N");
            string yn = Console.ReadLine();
            if(yn.ToUpper() == "Y"){ 

                this.Total += Night * Days;
                
                if (sel == "A"){
                    this.Total += this.Days * A;
                
                }else if(sel == "C"){
                    this.Total += this.Days * C;
                }
            }else if (yn.ToUpper() == "N"){
                
                if (sel == "A"){
                    this.Total += this.Days * A;
                
                }else if(sel == "C"){
                    this.Total += this.Days * C;
                }
            }

        }
        public override string ToString(){
            return $"Estimate:" +
                   $"\nOwners Name: {Owner}" +
                   $"\nDog's Name: {Name}" +
                   $"\nDog Weight: {Weight}" +
                   $"\nSelected Service: {AddOn}" +
                   $"\nTotal Cost: {Total}";
        }
    }
}
