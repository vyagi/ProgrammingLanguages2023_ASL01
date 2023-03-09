//NONO : don't do this. Ever.
// public class PairObject
// {
//     public object A;
//     public object B;
// }

//public class PairInt
//{
//    public int A;
//    public int B;
//}
//public class PairString
//{
//    public string A;
//    public string B;
//}

//public class PairDates
//{
//    public DateTime A;
//    public DateTime B;
//}

public struct Point// : AbstractConceptOfGeometry //with struct it is not possible to inherit
{
    public int X;
    public int Y;

    public Point() { }//was not possible in structs in previous versions of C#
    public Point(int x, int y) => (X, Y) = (x, y);
}