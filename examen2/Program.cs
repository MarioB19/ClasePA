public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {

      
        IList<IList<int>> result = new List<IList<int>>(); //Declaracion de lista Ilist
        //Bucle for que permite iterar todo el array, a traves de las variables i,j,k
        //donde para que i != j, i != k, and j != k, i = algo , j = i+1 , k = j+1

        //Verificar que por lo menos el arreglo tenga 3 elementos
          if(nums.Length<3){
            return result;
        }
        


        for(int i=0; i<nums.Length; i++) {
            for(int j=i+1; j<nums.Length; j++) {
                for(int k=j+1; k<nums.Length; k++) {
                    if(nums[i] + nums[j] + nums[k] == 0) {  //Verificar si en algun momento se forma una terna que sea igual a 0
                         int[] arr = new int[3]; //Creacion de arreglo para ordenar la terna

                        //Definicion de elementos de la terna
                        arr[0] = nums[i];
                        arr[1] = nums[j];
                        arr[2] = nums[k];

                        //Creacion de lista para ordenar la terna
                        List<int> listaNums = new List<int>();

                        //Agregacion de los elementos de la terna
                        listaNums.Add(arr[0]);
                        listaNums.Add(arr[1]);
                        listaNums.Add(arr[2]);

                        //Ordenar los elementos
                        listaNums.Sort();

                        //Igualar el arreglo de la terna a la lista ordenada
                        int x = 0;
                        foreach (var item in listaNums){
                            arr[x] = item;
                            x++;

                        }

                  
                        bool exists = false;
                  
                        //Verificar si los elementos de la terna, se repiten
                        foreach (var terna in result) {
                            if (terna[0] == arr[0] && terna[1] == arr[1] && terna[2] == arr[2]) {
                                exists = true;
                                break;
                            }
                         

                        }

                       //Si no se repite se anaden a la lista
                        if (!exists) {
                            result.Add(new List<int> {arr[0], arr[1], arr[2]});
                        }
                    }
                }
            }
        }

        //Devolver el valor
        return result;
    }
}