namespace Car_Parts.Data
{
    public class DataConstants
    {
        public class Admin
        {
            public const int NameMaxLength = 30;
        }

        public class Part
        {

            public const int NameMaxLength = 100;
            public const int NameMinLength = 2;
            public const int DescriptionMaxLength = 200;
            public const int DescriptionMinLength = 20;
            public const string DecimalMaxValue = "79228162514264337593543950335";
        }

        public class Category
        {

            public const int NameMaxLength = 100;
        }

        public class Make
        {

            public const int NameMaxLength = 100;
            public const int NameMinLength = 2;
        }

        public class Model
        {

            public const int NameMaxLength = 100;
        }

        public class Offer
        {

            public const int NameMaxLength = 100;
        }
    }
}