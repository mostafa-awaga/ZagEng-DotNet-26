using System;
namespace TaskOne
{
    class Program
    {
        //Question 2
        enum FeatureType
        {
            Login,
            Export,
            AdminPanal
        }

        class Feature
        {
            public readonly FeatureType Type;
            public bool IsEnable;
            public double MinVersion;

            public Feature(FeatureType type, bool enabled, double minVersion)
            {
                Type = type;    
                IsEnable = enabled;
                MinVersion = minVersion;
            }
        }

        class FeatureManager
        {
            public const double AppVertion = 2.5;
            public bool CanRun(Feature f)
            {
                return f.IsEnable && AppVertion >= f.MinVersion;
            }

        }


        static void Main(string[] args)
        {
            Feature login = new Feature(FeatureType.Login, true, 1.0);
            Feature Export = new Feature(FeatureType.Export, false, 2.0);
            Feature AdminPanal = new Feature(FeatureType.AdminPanal, true, 3.0);

            FeatureManager manger = new FeatureManager();

            Console.WriteLine($"Can Run Login: {manger.CanRun(login)}");
            Console.WriteLine($"Can Run Export: {manger.CanRun(Export)}");
            Console.WriteLine($"Can Run Admin: {manger.CanRun(AdminPanal)}");
        }
    }
}