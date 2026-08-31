Console.Write("Digite o valor em reais: ");
double valorReais = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"Valor em dólares: {valorReais / 5.17:F2}");
Console.WriteLine($"Valor em euros: {valorReais / 6.14:F2}");
Console.WriteLine($"Valor em pesos: {valorReais / 0.05:F2}");