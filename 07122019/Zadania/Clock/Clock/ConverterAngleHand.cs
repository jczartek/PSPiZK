using System;
using System.Globalization;
using System.Windows.Data;

namespace Clock
{
    public enum Hands { Hour, Minute, Second}
    class ConverterAngleHand : IValueConverter
    {
        public Hands Hands { get; set; } = Hands.Hour;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt = (DateTime) value;
            double valueAngle = 0;

            switch(Hands)
            {
                case Hands.Hour:
                    valueAngle = dt.Hour;
                    if (valueAngle > 12) valueAngle -= 12;
                    valueAngle += dt.Minute / 60.0;
                    valueAngle /= 12.0;
                    break;
                case Hands.Minute:
                    valueAngle = dt.Minute;
                    valueAngle += dt.Second / 60.0;
                    valueAngle /= 60.0;
                    break;
                case Hands.Second:
                    valueAngle = dt.Second;
                    valueAngle /= 60.0;
                    break;
            }
            return valueAngle *= 360.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
