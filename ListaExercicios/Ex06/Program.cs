int[] vetorNaoOrdernado = new int[100];

for(int i = 0; i < vetorNaoOrdernado.Length; i++){
    vetorNaoOrdernado[i] = new Random().Next(1000);
}

Array.Sort(vetorNaoOrdernado);

for(int i = 0; i < vetorNaoOrdernado.Length; i++){
    System.Console.Write(vetorNaoOrdernado[i] + " ");
}