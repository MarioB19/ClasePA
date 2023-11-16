
int[] numeros = { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 5, 5, 3, 2, 2, 1, 1, 1, 8, 2, 4, 4, 2, 1, 6, 4, 4, 4, 4, 4, 4, 4, 4 };

numeros = (TopKFrequent(numeros, 4));

for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine(numeros[i]);
}

int[] TopKFrequent(int[] nums, int k)
{

    // Utilizar HashSet para almacenar valores únicos
    HashSet<int> conjuntoUnico = new HashSet<int>(nums);

    // Crear un nuevo arreglo sin duplicados
    int[] arregloSinDuplicados = new int[conjuntoUnico.Count];

    conjuntoUnico.CopyTo(arregloSinDuplicados);

    int[] contFrecuency = new int[arregloSinDuplicados.Length];

    List<Num> listaNums = new List<Num>();

    int[] aux = new int[k];







    for (int i = 0; i < arregloSinDuplicados.Length; i++)
    {

        for (int j = 0; j < nums.Length; j++)
        {

            if (arregloSinDuplicados[i] == nums[j])
            {
                contFrecuency[i]++;



            }
        }
    }


    for (int i = 0; i < arregloSinDuplicados.Length; i++)
    {

        Num num = new Num { number = arregloSinDuplicados[i], frecuency = contFrecuency[i] };

        listaNums.Add(num);

    }




    listaNums.Sort((num1, num2) => num2.frecuency.CompareTo(num1.frecuency));


    foreach (var num in listaNums)
    {
        Console.WriteLine($"Numero {num.number} , frecuency {num.frecuency}");
    }


    int x = 0;


    foreach (Num num in listaNums)
    {

        if (x < k)
            aux[x] = num.number;

        x++;

    }

    return aux;

}

public class Num
{
    public int number;
    public int frecuency;
}
























