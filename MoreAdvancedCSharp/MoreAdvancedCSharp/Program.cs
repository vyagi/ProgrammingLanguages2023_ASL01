//Demos.NullableDemo();
//Demos.StructClassesDemo();
//Demos.GenericDemos();
//Demos.ExtensionMethodsDemo();
//Demos.EnumerableDemo();
//Demos.AnonymousTypesDemo();
//Demos.TupleDemo();

//boxing and unboxing

int x = 10;

object y = x; //boxing

int z = (int)y; //unboxing

int[] myObjects = new int[10];
myObjects[0] = 30;
myObjects[1] = 20;

//Not finished yet, a good, valid example did not come to my mind in the classes
//MyMethod(myObjects);

void MyMethod(object[] input)
{
    //do something
}

public static class Demos
{
    public static void NullableDemo()
    {
        //In C# we basically have two types of types
        // There are classes (reference types) like string, array, List, many other
        // There are structs (value types) like int, decimal, float, DateTime, bool and some other

        //Before C# 8.0
        // classes are nullable
        // structs are NOT nullable

        //Now C# introduced nullable and not nullable reference types - adoption is very slow

        // bool condition = null;   //will not compile
        // int height = null;   //will not compile

        //T? is the language support for Nullable<T>
        int? height = null;
        bool? condition = null;

        Console.WriteLine(height);
        Console.WriteLine(condition);
        Console.WriteLine(height.HasValue);
        // Console.WriteLine(height.Value);//exception

        height = 192;
        condition = true;

        Console.WriteLine(height);
        Console.WriteLine(condition);
        Console.WriteLine(height.HasValue);
        Console.WriteLine(height.Value);

        /////// 
        string name = null;
        string? secondName = null;
    }

    public static void StructClassesDemo()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(1, 2);

        Console.WriteLine(point1.Equals(point2));

        ChangePoint(point1);
        Console.WriteLine($"{point1.X} {point1.Y}");
        void ChangePoint(Point point)
        {
            point.X = 100;
            point.Y = 100;
        }
    }
    
    public static void GenericDemos()
    {
        var p = new Pair<int, int>
        {
            A = 10,
            B = 20
        };

        var s = new Pair<string, string> { A = "James", B = "Bond" };
        var t = new Pair<DateTime, DateTime> { A = DateTime.Now, B = DateTime.Now.AddDays(10) };

        var result = p.A + p.B;
        var length = s.A.Length + s.B.Length;

        var pairOfDifferentThings = new Pair<int, string> { A = 10, B = "Marcin" };
    }

    public static void ExtensionMethodsDemo()
    {
        var name = "marcin"; // -> "Marcin"

        Console.WriteLine(StringUtilities.Capitalize(name));
        name.Capitalize();

        Console.WriteLine(5.IsOdd());
        Console.WriteLine(50.IsOdd());
        Console.WriteLine(61.IsPrime());
        Console.WriteLine(6.IsPrime());

        //some more linq
        var heights = new[] { 176, 120, 185 };
        Console.WriteLine(heights.Any(x => x > 150));

        Console.WriteLine(Enumerable.Any(heights, x => x > 150));

        var xx = heights
            .Where(x => x > 150)
            .OrderBy(x => x)
            .Select(x => x % 3)
            .OrderByDescending(x => x);

        var yy = Enumerable.OrderBy(Enumerable.Where(heights, x => x > 150), x => x);
    }

    public static void EnumerableDemo()
    {
        IEnumerable<string> names = new List<string> { "Marcin", "James" };

        int height = 180;

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("--------");
        var personNames = new Names { FirstName = "James", SecondName = "Junior", LastName = "Bond" };

        //foreach (var piece in personNames)
        //{
        //    Console.WriteLine(piece);
        //}

        ////I can now use Linq operators on my Names type, because... it implements IEnumerable<T>
        //Console.WriteLine(personNames.First());
        //Console.WriteLine(personNames.OrderBy(x=>x).FirstOrDefault());

        //Prove that linq operators are lazy (not every, but most)
        foreach (var name in personNames.Take(2))
        {
            Console.WriteLine(name);
        }

        //another example
        var heights = new List<int> { 178, 190, 182 };

        var twoBiggestHeights = heights.OrderByDescending(x => x).Take(2);
        heights.Add(205);

        foreach (var h in twoBiggestHeights)
        {
            Console.WriteLine(h); //this is because Linq operators are lazy
        }
    }

    public static void AnonymousTypesDemo()
    {
        var p1 = new Person("James Bond", 70, "Spy");
        var p2 = new Person("James Bond", 70, "Spy");

        var persons = new[] {
            p1,
            p2,
            new ("Jane", 40, "Nurse"),
            new ("Kate",20, "Student") };

        var info = persons.Select(x => new { Description = $"{x.Name} ({x.Occupation})", x.Age });

        foreach (var p in info)
        {
            Console.WriteLine(p.GetType());
            Console.WriteLine($"{p.Description} is {p.Age} years old");
        }

        Console.WriteLine(p1 == p2);

        //with anonymous types we no longer need this kind of class (or record)
        //public record PersonInfo(string Description, int Age);
    }

    public static void TupleDemo()
    {
        var p1 = new Person("James Bond", 70, "Spy");
        var p2 = new Person("James Bond", 70, "Spy");

        var persons = new[] {
            p1,
            p2,
            new ("Jane", 40, "Nurse"),
            new ("Kate",20, "Student") };

        //old school syntax:
        // var xx = persons.Select(x => new Tuple<string, int>($"{x.Name} ({x.Occupation})", x.Age));
        //new syntax:

        var xx = persons.Select(x => ($"{x.Name} ({x.Occupation})", x.Age));
        Display(xx);
        void Display(IEnumerable<(string Name, int Description)> collection)
        {
            foreach (var element in collection)
            {
                Console.WriteLine($"{element.Name} is {element.Description}");
            }
        }
    }
}