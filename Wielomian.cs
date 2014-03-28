using System;
using System.Text;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace PhoneApp1
{
    public class Wielomian
    {
        List<Double> wspolczynniki;

        public Wielomian(List<Double> wektor)
        {
            this.wspolczynniki = wektor;
        }

        public double Wartosc(double x)
        {
            double y = 0.0;
            for (int i = 0; i < wspolczynniki.Count; i++)
            {
                y = y + wspolczynniki[i] * Math.Pow(x, i);
            }
            return y;
        }

        public String RownanieKwadratowe()
        {
            String wyjscie = "";

            if (wspolczynniki.Count > 2)
            {
                Double a = wspolczynniki[2];
                Double b = wspolczynniki[1];
                Double c = wspolczynniki[0];

                Double delta = Math.Pow(b, 2) - (4 * a * c);
                if (delta < 0) wyjscie = "no roots";
                if (delta == 0) wyjscie = (-1 * b) / (2 * a) + "";
                if (delta > 0)
                {
                    Double x1 = ((-1 * b) - Math.Sqrt(delta)) / (2 * a);
                    Double x2 = ((-1 * b) + Math.Sqrt(delta)) / (2 * a);
                    wyjscie = Math.Round(x1, 3) + " and " + Math.Round(x2, 3);
                }
            }
            else
                wyjscie = "error";

            return wyjscie;
        }

        public int Stopien()
        {
            int stopien = 0;
            for (int i = 0; i < wspolczynniki.Count; i++)
            {
                if (wspolczynniki[i] != 0) stopien = i;
            }
            return stopien;
        }
        
        public override string ToString()
        {
            string wyjscie = "";
            for (int i = wspolczynniki.Count - 1; i > 1; i--)
            {
                //ta czesc kodu generuje mi ladnie indeks gorny
                String superscript = "";
                if (i < 10)
                {
                    switch (i)
                    {
                        case 2:
                            superscript = "\x00B2";
                            break;
                        case 3:
                            superscript = "\x00B3";
                            break;
                        case 4:
                            superscript = "\x2074";
                            break;
                        case 5:
                            superscript = "\x2075";
                            break;
                        case 6:
                            superscript = "\x2076";
                            break;
                        case 7:
                            superscript = "\x2077";
                            break;
                        case 8:
                            superscript = "\x2078";
                            break;
                        case 9:
                            superscript = "\x2079";
                            break;
                    }
                }
                else superscript = "^" + i;
                //--
                if (wspolczynniki[i] != 0 && wspolczynniki[i] != 1) wyjscie = wyjscie + wspolczynniki[i] + "x" + superscript + " + ";
                else if (wspolczynniki[i] != 0) wyjscie = wyjscie + "x" + superscript + " + ";
            }
            if (wspolczynniki.Count > 1 && wspolczynniki[1] != 1 && wspolczynniki[1] != 0) wyjscie = wyjscie + wspolczynniki[1] + "x + ";
            else if (wspolczynniki.Count > 1 && wspolczynniki[1] != 0) wyjscie = wyjscie + "x + ";
            if(wspolczynniki[0] != 0) wyjscie = wyjscie + wspolczynniki[0] + " + ";

            if(wyjscie.Length > 3) wyjscie = wyjscie.Substring(0, wyjscie.Length - 3);

            return wyjscie;
        }
    }
}
