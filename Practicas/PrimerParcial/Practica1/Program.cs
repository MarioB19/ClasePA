//HEADER
WriteLine("{0,-74}\n{1,-8}{2,-31}{3,4}{4,31}\n{5,-74}",
   "--------------------------------------------------------------------------",
   "Type", "Byte(s) of memory", "Min", "Max" ,
   "--------------------------------------------------------------------------");
//ROWS
//Creacion de lista con 4 elementos de tipo string
 List<(string typeName, string size, string minValue, string maxValue)> data = new List<(string, string, string, string)>
        {
            ("sbyte", $"{sizeof(sbyte)}", $"{sbyte.MinValue}", $"{sbyte.MaxValue}"),
            ("byte", $"{sizeof(byte)}", $"{byte.MinValue}", $"{byte.MaxValue}"),
            ("short", $"{sizeof(short)}", $"{short.MinValue}", $"{short.MaxValue}"),
            ("ushort", $"{sizeof(ushort)}", $"{ushort.MinValue}", $"{ushort.MaxValue}"),
            ("int", $"{sizeof(int)}", $"{int.MinValue}", $"{int.MaxValue}"),
            ("uint", $"{sizeof(uint)}", $"{uint.MinValue}", $"{uint.MaxValue}"),
            ("long", $"{sizeof(long)}", $"{long.MinValue}", $"{long.MaxValue}"),
            ("ulong", $"{sizeof(ulong)}", $"{ulong.MinValue}", $"{ulong.MaxValue}"),
            ("float", $"{sizeof(float)}", $"{float.MinValue}", $"{float.MaxValue}"),
            ("double", $"{sizeof(double)}", $"{double.MinValue}", $"{double.MaxValue}"),
            ("decimal", $"{sizeof(decimal)}", $"{decimal.MinValue}", $"{decimal.MaxValue}")
            //tipoDato , sizeof(tipoDato) *obtenemos los bytes de memoria del tipo de dato
            //tipoDato.MinValue *Valor minimo que puede tomar dicho dato , 
            //tipoDato.MinValue *Valor maximo que puede tomar dicho dato , 
            
        };

        //recorremos nuestra Lista de tuplas
        foreach (var item in data)
        {
            //Imprimimos cada fila de nuestra tabla , que corresponde a nuestra lista , dandole el formato (margen) adecuado
            Console.WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
            item.typeName, item.size, item.minValue, item.maxValue);
        }

//Footer
WriteLine("{0,-74}",
"--------------------------------------------------------------------------");







/*
//HEADERS
WriteLine("{0,-74}",
"--------------------------------------------------------------------------");

WriteLine("{0,-8}{1,-31}{2,4}{3,31}",
    "Type", "Byte(s) of memory", "Min", "Max");

WriteLine("{0,-74}",
"--------------------------------------------------------------------------");

//ROWS
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"sbyte" , $"{sizeof(sbyte)}" , $"{sbyte.MinValue}" , $"{sbyte.MaxValue}");


WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"byte" , $"{sizeof(byte)}" , $"{byte.MinValue}" , $"{byte.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"short" , $"{sizeof(short)}" , $"{short.MinValue}" , $"{short.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"ushort" , $"{sizeof(ushort)}" , $"{ushort.MinValue}" , $"{ushort.MaxValue}");

WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"int" , $"{sizeof(int)}" , $"{int.MinValue}" , $"{int.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"uint" , $"{sizeof(uint)}" , $"{uint.MinValue}" , $"{uint.MaxValue}");

WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"long" , $"{sizeof(long)}" , $"{long.MinValue}" , $"{long.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"ulong" , $"{sizeof(ulong)}" , $"{ulong.MinValue}" , $"{ulong.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"float" , $"{sizeof(float)}" , $"{float.MinValue}" , $"{float.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"double" , $"{sizeof(double)}" , $"{double.MinValue}" , $"{double.MaxValue}");
WriteLine("{0,-8}{1,-5}{2,30}{3,31}",
"decimal" , $"{sizeof(decimal)}" , $"{decimal.MinValue}" , $"{decimal.MaxValue}");

WriteLine("{0,-74}",
"--------------------------------------------------------------------------");
*/
