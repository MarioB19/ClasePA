string [] arr = new string[40];

string valor;

for(int i = 0; i < 40;i++){
    arr[i] = Random.Shared.Next(0, 1000).ToString();
}

 valor  = func(arr);







static string func(string [] arr){

    string output;



    


uint indice = (uint) arr.Length;

WriteLine(indice);




int [] val = new int[indice];

int aux;
uint min= 0;




for(int i = 0 ; i<indice;i++){

    val [i] = arr[i].Length;

}
	
		
	for(int i =0 ; i<indice ; i++){
		
		for(int j = 0 ; j<indice-1 ; j++){
			
			if( val[j] > val [j+1])
			{
			
			aux = val[j];
			val[j]= val[j+1];
			val [j+1] = aux;
            }
			
	}
    }

    min = (uint) val[0];




    for(int i =0;i<min;i++){

        for(int j =0 ; j<arr[i].Length;j++){

        }



       
    }

    string [] subarr = new string [indice];


    for(int i =0;i<indice;i++){

  
        subarr[i]= arr[i].Substring(0,40);

        
    } 