System.Console.Write("Digite sua idade: ");
int idade = Convert.ToInt32(Console.ReadLine());

if(idade <= 13){
    System.Console.WriteLine("Você é uma criança!");
} else {
    if(idade > 13 && idade <= 18){
        System.Console.WriteLine("Você é um adolescente!");
    } else {
        if(idade > 18 && idade <= 60){
            System.Console.WriteLine("Você é um adulto!");
        } else { 
            System.Console.WriteLine("Você é um idoso!");
        }
    }
}