using System.Text.RegularExpressions;

public static class Program
{
    public static void Main(string[] args)
    {
        
    }

    #region BuscaBinaria
    private static void BuscaBinaria()
    {
        var numeros = Enumerable.Range(1, 1024).ToArray();
        var numeroEscolhido = 38;
        var (quantidadeTentativas, numeroEncontrado) = EncontrarNumeroBuscaBinaria(numeros, numeroEscolhido);

        Console.WriteLine($"Quantidade tentativas: {quantidadeTentativas}, " +
            $"\n Numero encontrado:{numeroEncontrado}" +
            $"\n Numero escolhido: {numeroEscolhido}");
    }

    /// <summary>
    /// Em um range de numeros, dado um numero encontra-o usando busca binaria;
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="numeroEscolhido"></param>
    /// <returns></returns>
    private static (int quantidadeTentativas, int numeroEncontrado) EncontrarNumeroBuscaBinaria(int[] nums, int numeroEscolhido)
    {
        // numero de 1 a 100
        var numerosOrdernados = nums.OrderBy(x => x).ToArray();

        var inicio = 0; //1 
        var fim = numerosOrdernados[numerosOrdernados.Length - 1];// 100

        var quantiadeTentativasPossiveis = ObterQuantidadeTentativasPossiveis(fim);

        var meio = 0;
        var quantidadeTentativas = 0;

        while (quantidadeTentativas != quantiadeTentativasPossiveis)
        {
            meio = (inicio + fim) / 2;

            var chute = numerosOrdernados[meio];
            
            if (chute == numeroEscolhido)
                return (quantidadeTentativas, meio);

            if (chute > numeroEscolhido)
            {
                fim = meio - 1;
            }
            else
            {
                inicio = meio + 1;
            }

            quantidadeTentativas++;
        }
        return (0, 0);
    }

    //Log2(n) (inverso de exponencial), ou seja quantas vezes teriamos que ter de 2 pra chegar em n
    // ou seja Log2(8) = seria 2³ = 2x2x2 = 8 entao teriamos ate 3 tentattivas
    private static int ObterQuantidadeTentativasPossiveis(int quantidadeNumerosTotais)
    {
        var numero = Convert.ToInt32(Math.Round(Math.Log2(quantidadeNumerosTotais), 1));

        var quantidadeTentativas = 1;
        bool numeroEncontrado = false;
        var numeroAtual = 2;
        while (!numeroEncontrado)
        {
            quantidadeTentativas++;

            numeroAtual *= 2;

            if (numeroAtual >= quantidadeNumerosTotais)
            {
                numeroEncontrado = true;
            }

        }
        return quantidadeTentativas;

        //var numero = Convert.ToInt32(Math.Round(Math.Log2(quantidadeNumerosTotais),1));

        //return numero;
    }
    #endregion
}
