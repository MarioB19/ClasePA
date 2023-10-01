using System.Diagnostics.Contracts;

WriteLine(IntToRoman(3999));


    


static string IntToRoman(int num)
{

    int unidad = 0, decena = 0, centena = 0, millar = 0;

    string u = "", d = "", c = "", m = "";

    string val;

    

    if (num >= 1 || num <= 3999)
    {

        val = num.ToString();

        if (num >= 1 && num <= 9)
        {

            unidad = val[0] - 48;
        }
        else if (num >= 10 && num <= 99)
        {
            unidad = val[1] - 48;
            decena = val[0] - 48;

        }
        else if (num >= 100 && num <= 999)
        {
            unidad = val[2] - 48;
            decena = val[1] - 48;
            centena = val[0] - 48;
        }
        else if (num >= 1000)
        {

            unidad = val[3] - 48;
            decena = val[2] - 48;
            centena = val[1] - 48;
            millar = val[0] - 48;
        }

        if (unidad >= 0)
        {
            for (int i = 1; i <= unidad; i++)
            {

                if (i == 4)
                {
                    u = "IV";
                }
                else if (i == 5)
                {
                    u = "V";
                }
                else if (i == 9)
                {
                    u = "IX";

                }
                else
                {
                    u += "I";
                }

            }

        }
        if (decena >= 0)
        {

            for (int i = 1; i <= decena; i++)
            {

                if (i == 4)
                {
                    d = "XL";
                }
                else if (i == 5)
                {
                    d = "L";
                }
                else if (i == 9)
                {
                    d = "XC";

                }
                else
                {
                    d += "X";
                }
            }

        }
        if (centena >= 0)
        {

            for (int i = 1; i <= centena; i++)
            {

                if (i == 4)
                {
                    c = "CD";
                }
                else if (i == 5)
                {
                    c = "D";
                }
                else if (i == 9)
                {
                    c = "CM";

                }
                else
                {
                    c += "C";
                }

            }

        }
        if (millar >= 0)
        {

            for (int i = 1; i <= millar; i++)
            {
                m += "M";
            }
        }


        if (num >= 1 && num <= 9)
        {
            return u;
        }
        else if (num >= 10 && num <= 99)
        {
            return d + u;
        }
        else if (num >= 100 && num <= 999)
        {

            return c + d + u;
        }
        else if (num >= 1000)
        {

            return m + c + d + u;
        }

    }
    return "";

    //obtener el prefijo de n cantidad de cadenas
  
}

