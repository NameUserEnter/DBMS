using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public abstract class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Column(string name, string type)
        {
            Name = name;
            Type = type;
            
        }

        public abstract bool Validate(object value);

        public static Column CreateColumn(string name, string type)
        {
            switch (type.ToUpper())
            {
                case "INT":
                    return new IntColumn(name, type);
                case "REAL":
                    return new RealColumn(name, type);
                case "CHAR":
                    return new CharColumn(name, type);
                case "STRING":
                    return new StringColumn(name, type);
                case "PICTURE FILE":
                    return new PictureFileColumn(name, type);
                case "REAL INTERVAL":
                    return new RealIntervalColumn(name, type);
                default:
                    throw new ArgumentException("Invalid column type");
            }
        }
    }

    public class IntColumn : Column
    {
        public IntColumn(string name, string type) : base(name, type) { }

        public override bool Validate(object value) => int.TryParse((string)value, out _);
    }

    public class RealColumn : Column
    {
        public RealColumn(string name, string type) : base(name, type) { }

        public override bool Validate(object value) => double.TryParse((string)value, out _);
    }

    public class CharColumn : Column
    {
        public CharColumn(string name, string type) : base(name, type) { }

        public override bool Validate(object value) => char.TryParse((string)value, out _);
    }

    public class StringColumn : Column
    {
        public StringColumn(string name, string type) : base(name, type) { }

        public override bool Validate(object value) => value is string;
    }

    public class PictureFileColumn : Column
    {
        public PictureFileColumn(string name, string type) : base(name, type) { }

        public override bool Validate(object value)
        {
            try
            {
                using (FileStream stream = File.Open((string)value, FileMode.Open))
                {
                    Image image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
             return true;
        }
    }

    public class RealIntervalColumn : Column
    {
        public RealIntervalColumn(string name, string type) : base(name, type) { }

        public override bool Validate(object value)
        {
            string[] buf = value.ToString().Split(' ');
            return (buf.Length == 2) && double.TryParse(buf[0], out _) && double.TryParse(buf[1], out _) && double.Parse(buf[0]) < double.Parse(buf[1]);
        }
    }

}
