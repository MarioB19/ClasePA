WriteLine("Ente number of randoms");

string? input = ReadLine();

int nums =  int.Parse(input);

int [] arr = new int[nums];

for(int i = 0; i < nums ;i++){
    arr[i] = Random.Shared.Next(0, 1000);
}

for(int i = 0;i<nums;i++){
    Write($"{arr[i]}");

    if(arr[i] % 3 == 0){
    Write(" : Fizz");
    }

    if(arr[i] % 5 ==0){
        Write(" Buz");
    }

    WriteLine("");


    for(int x=0;x<1000001;x++)
    {
        Write("a");

    }
    
}