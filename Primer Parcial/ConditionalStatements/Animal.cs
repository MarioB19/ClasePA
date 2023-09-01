using System.Data.Common;
using Microsoft.VisualBasic;

public class Animal

{
    public String ? Name;
    public DateTime Born;
    public int Legs ;
    public bool IsDomestic;
    public int Age;


    Animal [] animals = new Animal ?[]{
        new Pig{
            Name = "Oreo",
            Born = new (year:2012 , month :8 , day:2),
            Legs = 4,
            IsDomestic = true,
            Age = 12
        },

        new Cat{
             Name = "Gato1",
            Born = new (year:2019 , month :6 , day:3),
            Legs = 4,
            IsDomestic = true,
            Age = 8
        },

        new Dog{

             Name = "Gasper",
            Born = new (year:2017 , month :6 , day:3),
            Legs = 4,
            IsDomestic = false,
            Age = 14

        }



    };
}


public class Cat : Animal{

    public bool is poisoonos;
    

}

public class Pig:Animal{

}

public class Dog : Animal{

}


/*


simplified switch | minamilist switch

message = animal switch

// => Lambda

Cat threeLegCat when threeLegCat.Legs == 3 =>




*/