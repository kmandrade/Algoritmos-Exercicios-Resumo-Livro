using System.Text.RegularExpressions;

public static class Program
{
    public static void Main(string[] args)
    {
        BuscaBinaria();

    }

    #region Array e Lista encadeada

    /*
        no array sabemos exatamente cada posicacao de cada item , porem possuimos limite de posicoes.
        
        na lista encadeada não sabemos, posicionamos aleatoriamente os itens no vetor nos espaços livres na memoria,
        mas para acessar o 10° item por ex precisamos percer todos os itens que possuem o endereco do proximo item, pois
        o endereco do item posterior vai estar armazenado no anterior.

        ou seja para leitura o array é melhor O(1) mas para escrita é O(n) pois precisa escrever de 1 a 1, mas para ler ja sabemos a posicacao exata
        mas na lista encadeada a leitura é O(n) pois nao sabemos a posicacao entao precisamos ler de 1 a 1 ja na escrita é O(1) pois podemos inserir em qualquer posicacao
    */

    #endregion

    #region BuscaBinaria
    // Big O(log n) medimos o quanto o algoritmo é rapido enquanto a lista aumenta (crescimento do numero de operacoes) não o tempo de execucao em si.
    // não medimos o tempo em s mas sim o tempo de execucao em si
    // Big O(n!) - fatorial de operacoes, ex Anagrama de uma lista: “ABC” → 3! = 6 anagramas: ABC, ACB, BAC, BCA, CAB, CBA
    /*
     Exemplo de for com complexidade log de n:

        for (i = 0; i < n; i++)
            for (j = n; j > 1; j /= 2)

     */

    private static void BuscaBinaria()
    {
        var numeros = Enumerable.Range(1, 1024).ToArray();
        var numeroEscolhido = 38;
        var (quantidadeTentativas, numeroEncontrado) = EncontrarNumeroBuscaBinaria(numeros, numeroEscolhido);

        Console.WriteLine("=========Busca Binária=========");

        Console.WriteLine($"Quantidade tentativas: {quantidadeTentativas}, " +
            $"\n Numero encontrado:{numeroEncontrado}" +
            $"\n Numero escolhido: {numeroEscolhido}");

        Console.WriteLine("=========Busca Binária=========");
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
