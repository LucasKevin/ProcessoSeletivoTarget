using System.Text.Json;

namespace Target
{
    class Program
    {
        public class Faturamento
        {
            public int Dia { get; set; }
            public double Valor { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Olá, meu nome é Lucas Kevin e estou em busca de uma vaga Dev!");
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Resultado da variável Soma");
            Console.WriteLine("2 - Verificação de número na sequência de Fibonacci");
            Console.WriteLine("3 - Faturamento diário");
            Console.WriteLine("4 - Percentual de representação por estado");
            Console.WriteLine("5 - Inversão de string");
            Console.WriteLine("6 - Sair");

            Console.WriteLine("------------");
            Console.Write("Selecione uma opção: ");

            if (short.TryParse(Console.ReadLine(), out short res))
            {
                switch (res)
                {
                    case 1: Soma(); break;
                    case 2: VerificarFibonacci(); break;
                    case 3: FaturamentoDiario(); break;
                    case 4: PercentualEstado(); break;
                    case 5: InverteString(); break;
                    case 6: Environment.Exit(0); break;
                    default: Menu(); break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Menu();
            }
        }

        static void Soma()
        {
            Console.Clear();

            int INDICE = 13, SOMA = 0, K = 0;

            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            Console.WriteLine($"Resultado da soma: {SOMA}"); // Resultado: 91

            Console.ReadKey();
            Menu();
        }

        static void VerificarFibonacci()
        {
            Console.Clear();
            Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");

            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                int a = 0, b = 1, c = 0;
                bool pertence = false;

                while (c <= numero)
                {
                    if (c == numero)
                    {
                        pertence = true;
                        break;
                    }
                    c = a + b;
                    a = b;
                    b = c;
                }

                if (pertence)
                    Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
                else
                    Console.WriteLine($"{numero} não pertence à sequência de Fibonacci.");
            }
            else
            {
                Console.WriteLine("Entrada inválida!");
            }

            Console.ReadKey();
            Menu();
        }

        static void FaturamentoDiario()
        {
            try
            {
                // Lê e desserializa o arquivo JSON
                var faturamento = JsonSerializer.Deserialize<Faturamento[]>(File.ReadAllText("dados.json"));

                // Filtra os dias úteis com faturamento maior que 0
                var diasUteis = faturamento?.Where(d => d.Valor > 0).ToList();

                // Verifica se há dias úteis com faturamento válido
                if (diasUteis == null || !diasUteis.Any())
                {
                    Console.WriteLine("Nenhum dado válido encontrado.");
                    return;
                }

                // Calcula e exibe os resultados, com verificações de sequências vazias
                double mediaMensal = diasUteis.Average(d => d.Valor);
                Console.WriteLine($"\nMenor valor: {diasUteis.Min(d => d.Valor)}");
                Console.WriteLine($"Maior valor: {diasUteis.Max(d => d.Valor)}");
                Console.WriteLine($"Média mensal: {mediaMensal}");
                Console.WriteLine($"Dias acima da média: {diasUteis.Count(d => d.Valor > mediaMensal)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Erro: O arquivo 'dados.json' não foi encontrado.");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro no formato do arquivo JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
            Console.ReadKey();
            Menu();
        }


        static void PercentualEstado()
        {
            Console.Clear();
            double sp = 67836.43, rj = 36678.66, mg = 29229.88, es = 27165.48, outros = 19849.53;
            double total = sp + rj + mg + es + outros;

            Console.WriteLine($"SP: {sp / total * 100:F2}%");
            Console.WriteLine($"RJ: {rj / total * 100:F2}%");
            Console.WriteLine($"MG: {mg / total * 100:F2}%");
            Console.WriteLine($"ES: {es / total * 100:F2}%");
            Console.WriteLine($"Outros: {outros / total * 100:F2}%");

            Console.ReadKey();
            Menu();
        }

        static void InverteString()
        {
            Console.WriteLine("Digite uma string para inverter:");
            string input = Console.ReadLine();
            string invertida = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                invertida += input[i];
            }

            Console.WriteLine($"String invertida: {invertida}");

                Console.ReadKey();
                Menu();
        }
    }
}
