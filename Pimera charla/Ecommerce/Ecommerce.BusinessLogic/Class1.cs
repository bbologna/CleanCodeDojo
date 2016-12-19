using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic
{
    public class ProcessPayment
    {
        public double Process(Cart cart)
        {
            double totalPrice = 0;
            foreach (var item in cart.Items)
                totalPrice += item.Price;
            return totalPrice;

            int i = 6; // elapsed time in days
        }

        private List<int[]> theList;
        public List<int[]> getThem()
        {
            List<int[]> list1 = new List<int[]>();
            foreach (var x in theList)
                if (x[0] == 4)
                    list1.Add(x);
            return list1;
        }

        private const int STATUS_VALUE = 0;
        private const int FLAGGED = 4;


        private List<int[]> gameBoard;




        public List<int[]> getFlaggedCells()
        {
            List<int[]> flaggedCells = new List<int[]>();
            foreach (var cell in gameBoard)
                if (cell[STATUS_VALUE] == FLAGGED)
                    flaggedCells.Add(cell);
            return flaggedCells;
        }

        //public class Part
        //{
        //    private string m_dsc; // The textual description
        //    public void setName(String name)
        //    {
        //        m_dsc = name;
        //    }
        //}


       private List<Pet> pets;
       public void Add(Pet pet)
       {
            pets.Add(pet);
       }

       public void Add(List<Pet> pets)
       {
            foreach (var pet in pets)
            {
                if (this.pets.Contains(pet))
                    pets.Add(pet);
            }
       }

       public class Pet
       {
            public string Name { get; set; }
       }


        public class Part
        {
            string description;
            public void setDescription(String description)
            {
                this.description = description;
            }

            void copyFromFirstToSecond(Part first, Part second) {}

            void copyFromSourceToDestination(Part source, Part destination) {}

            void copy(Part source, Part destination) {}
        }




    }

    public class Cart
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }

        public int[] Categories { get; set; }

        public double Price { get; set; }
    }
}

