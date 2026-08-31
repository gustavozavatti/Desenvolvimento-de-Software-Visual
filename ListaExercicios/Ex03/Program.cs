System.Console.Write("Digite um número: ");
int primeiroNumero = Convert.ToInt32(Console.ReadLine());
System.Console.Write("Digite outro número: ");
int segundoNumero = Convert.ToInt32(Console.ReadLine());

if(primeiroNumero > segundoNumero){
    System.Console.WriteLine($"O número {primeiroNumero} é maior!");
} else {
    if(segundoNumero > primeiroNumero){
        System.Console.WriteLine($"O número {segundoNumero} é maior!");
    } else {
        System.Console.WriteLine($"Os números são iguais!");
    }
}