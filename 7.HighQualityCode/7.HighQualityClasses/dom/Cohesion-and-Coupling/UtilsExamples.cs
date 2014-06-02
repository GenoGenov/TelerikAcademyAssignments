namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(Utils.FileUtils.GetFileExtension("example"));
            Console.WriteLine(Utils.FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(Utils.FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(Utils.FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(Utils.FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(Utils.FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Utils.DistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Utils.DistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume = {0:f2}", Utils.GeometryUtils.CalcVolume(3, 4, 5));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.GeometryUtils.CalcDiagonalXYZ(3, 4, 5));
            Console.WriteLine("Diagonal XY = {0:f2}", Utils.GeometryUtils.CalcDiagonalXY(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils.GeometryUtils.CalcDiagonalXZ(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils.GeometryUtils.CalcDiagonalYZ(4, 5));
        }
    }
}