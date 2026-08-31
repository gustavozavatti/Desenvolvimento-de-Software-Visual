Console.Write("Digite um valor positivo inteiro: ");
int valor = Convert.ToInt32(Console.ReadLine());

int primeiro = 0;
int segundo = 1;

while (primeiro <= valor)
{
    Console.Write(primeiro + " ");

    int proximo = primeiro + segundo;
    primeiro = segundo;
    segundo = proximo;
}
