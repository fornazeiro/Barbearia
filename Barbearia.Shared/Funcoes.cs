using System;
using System.ComponentModel;

namespace Barbearia.Shared
{
    public static class Funcoes
    {
        public static string cryptographyPass(this string input)
        {
            System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha1.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        #region Int

        /// <summary>
        /// Conta a quantidade de repetição de um Caracter em uma string.
        /// </summary>
        /// <param name="pTexto">String que deve ser efetuada a contagem.</param>
        /// <param name="pCaracter">Letra que será buscada na string.</param>
        /// <returns>Retorna a quantidade de repetição de uma letra em uma string.</returns>
        public static int ContarCaracter(this string pTexto, string pCaracter)
        {
            int contador = 0;

            for (int i = 0; i < pTexto.Length; i++)
            {
                if (pTexto[i].ToString() == pCaracter)
                {
                    contador++;
                }
            }

            return contador;
        }

        /// <summary>
        /// Dividir um Valor
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser dividido
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a divisão</param>
        /// <param name="pDivisor">Valor do Divisor</param>
        /// <returns>Retorna Divisão se possível ou Valor Mínimo</returns>
        public static int Dividir(this int pValor, int pDivisor)
        {
            return Dividir(pValor, pDivisor, int.MinValue);
        }

        /// <summary>
        /// Dividir um Valor 
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser dividido
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a divisão</param>
        /// <param name="pDividor">Valor do Divisor</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Divisão se possível ou Valor Default</returns>
        public static int Dividir(this int pValor, int pDividor, int pValorDefault)
        {
            int Valor = pValorDefault;

            try
            {
                Valor = pValor / pDividor;
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        /// <summary>
        /// Multiplicar um Valor
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser multiplicado
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a multiplicação</param>
        /// <param name="pMultiplicador">Valor do Multiplicador</param>
        /// <returns>Retorna multiplicação se possível ou Valor Mínimo</returns>
        public static int Multiplicar(this int pValor, int pMultiplicador)
        {
            return Multiplicar(pValor, pMultiplicador, int.MinValue);
        }

        /// <summary>
        /// Multiplicar um Valor
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser multiplicado
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a multiplicação</param>
        /// <param name="pMultiplicador">Valor do Multiplicador</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna multiplicação se possível ou Valor Default</returns>
        public static int Multiplicar(this int pValor, int pMultiplicador, int pValorDefault)
        {
            int Valor = pValorDefault;

            try
            {
                Valor = pValor * pMultiplicador;
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        #endregion

        #region Int64

        /// <summary>
        /// Formata o Int64 no Padrão de CPF
        /// </summary>
        /// <param name="pCPF">Número a ser formatado</param>
        /// <returns>Número formatado no Padrão de CPF</returns>
        public static string FormatarCPF(this Int64 pCPF)
        {
            string cpfFormatado = string.Empty;

            try
            {
                cpfFormatado = pCPF.ToString(@"000\.000\.000\-00");
            }
            catch (Exception)
            {
                throw;
            }

            return cpfFormatado;
        }

        /// <summary>
        /// Formata o Int64 no Padrão de CNPJ
        /// </summary>
        /// <param name="pCNPJ">Número a ser formatado</param>
        /// <returns>Número formatado no Padrão de CNPJ</returns>
        public static string FormatarCNPJ(this Int64 pCNPJ)
        {
            string cnpjFormatado = string.Empty;

            try
            {
                cnpjFormatado = pCNPJ.ToString(@"00\.000\.000\/0000\-00");
            }
            catch (Exception)
            {
                throw;
            }

            return cnpjFormatado;
        }

        #endregion

        #region String

        /// <summary>
        /// Obter descrição do Enumerador
        /// </summary>
        /// <param name="pEnumerador">Enumerador que deseja obter a descrição</param>
        public static string ObterEnumeradorDescricao(this Enum pEnumerador)
        {
            try
            {
                var Entrada = pEnumerador.ToString().Split(',');
                var Descricao = new string[Entrada.Length];

                for (var i = 0; i < Entrada.Length; i++)
                {
                    var Info = pEnumerador.GetType().GetField(Entrada[i].Trim());
                    var Atributos = (DescriptionAttribute[])Info.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    Descricao[i] = (Atributos.Length > 0) ? Atributos[0].Description : Entrada[i].Trim();
                }

                return String.Join(", ", Descricao);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Efetua um Substring da Esquerda para Direita de uma String
        /// </summary>
        /// <param name="pTexto">Texto que será recortado.</param>
        /// <param name="pTamanho">Tamanho desejado.</param>
        /// <returns>O Texto recortado.</returns>
        public static string Left(this string pTexto, int pTamanho)
        {
            if (pTexto.Length <= pTamanho)
            {
                return pTexto;
            }
            else
            {
                return pTexto.Substring(0, pTamanho);
            }
        }

        /// <summary>
        /// Efetua um Substring da Direita para Esquerda de uma String
        /// </summary>
        /// <param name="pTexto">Texto que será recortado.</param>
        /// <param name="pTamanho">Tamanho desejado.</param>
        /// <returns>O Texto recortado.</returns>
        public static string Right(this string pTexto, int pTamanho)
        {
            if (pTexto.Length <= pTamanho)
            {
                return pTexto;
            }
            else
            {
                int inicioSubstring = ((int)pTexto.Length) - ((int)pTamanho);

                return pTexto.Substring(inicioSubstring, ((int)pTamanho));
            }
        }

        /// <summary>
        /// Efetua um substring com o tamanho desejado acrescentando "..." para informar que existe mais caracteres porém que foram
        /// desconsiderados devido o tamanho do espaço que será exibida a informação.
        /// Ex: Truncate("Financeiro 24 Horas", 13) = "Financeiro..."
        /// </summary>
        /// <param name="pTexto">Texto que será truncado.</param>
        /// <param name="pTamanho">Tamanho desejado já contando com "...".</param>
        /// <returns>O Texto truncado.</returns>
        public static string Truncate(this string pTexto, int pTamanho)
        {
            try
            {
                if (pTexto.Length <= pTamanho)
                {
                    return pTexto;
                }
                else
                {
                    return pTexto.Substring(0, pTamanho - 3) + "...";
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Remover Pontuações e Acentos de Strings
        /// </summary>
        /// <param name="pTexto">Texto que serão Removidos as Pontuações e Acentos</param>
        /// <param name="pAceitaEspaco">Condição se no Texto será aceito Espaço</param>
        /// <returns>Texto Tratado</returns>
        public static string RemoverPontuacoesAcentos(this string pTexto, bool pAceitaEspaco)
        {
            if (string.IsNullOrEmpty(pTexto))
            {
                return pTexto;
            }

            pTexto = pTexto.RemoverAcentos();

            pTexto = pTexto.RemoverPontuacoes(pAceitaEspaco);

            return pTexto;
        }

        /// <summary>
        /// Remove os Acentos do Texto
        /// </summary>
        /// <param name="pTexto">Texto que serão removidos os Acentos</param>
        /// <returns>Texto sem Acentos</returns>
        public static string RemoverAcentos(this string pTexto)
        {
            if (string.IsNullOrEmpty(pTexto))
            {
                return "";
            }
            else
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(pTexto);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }

        /// <summary>
        /// Remover Pontuações de Strings
        /// </summary>
        /// <param name="pTexto">Texto que serão Removidas as Pontuações</param>
        /// <param name="pAceitaEspaco">Condição se no Texto será aceito Espaço</param>
        /// <returns>Texto Tratado</returns>
        public static string RemoverPontuacoes(this string pTexto, bool pAceitaEspaco)
        {
            if (string.IsNullOrEmpty(pTexto))
            {
                return pTexto;
            }

            if (pAceitaEspaco)
            {
                pTexto = System.Text.RegularExpressions.Regex.Replace(pTexto, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
            }
            else
            {
                pTexto = System.Text.RegularExpressions.Regex.Replace(pTexto, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);
            }

            return pTexto;
        }

        #endregion

        #region Decimal

        /// <summary>
        /// Dividir um Valor
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser dividido
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a divisão</param>
        /// <param name="pDividor">Valor do Divisor</param>
        /// <returns>Retorna Divisão se possível ou Valor Mínimo</returns>
        public static decimal Dividir(this decimal pValor, int pDividor)
        {
            return Dividir(pValor, pDividor, decimal.MinValue);
        }

        /// <summary>
        /// Dividir um Valor 
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser dividido
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a divisão</param>
        /// <param name="pDividor">Valor do Divisor</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Divisão se possível ou Valor Default</returns>
        public static decimal Dividir(this decimal pValor, int pDividor, decimal pValorDefault)
        {
            decimal Valor = pValorDefault;

            try
            {
                Valor = pValor / pDividor;
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        /// <summary>
        /// Multiplicar um Valor
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser multiplicado
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a multiplicação</param>
        /// <param name="pMultiplicador">Valor do Multiplicador</param>
        /// <returns>Retorna multiplicação se possível ou Valor Mínimo</returns>
        public static decimal Multiplicar(this decimal pValor, int pMultiplicador)
        {
            return Multiplicar(pValor, pMultiplicador, decimal.MinValue);
        }

        /// <summary>
        /// Multiplicar um Valor
        /// Função utilizada para quando se trabalha com Valores sem o delimitador de casas decimais, e o mesmo precisa ser multiplicado
        /// </summary>
        /// <param name="pValor">Valor que deseja efetuar a multiplicação</param>
        /// <param name="pMultiplicador">Valor do Multiplicador</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna multiplicação se possível ou Valor Default</returns>
        public static decimal Multiplicar(this decimal pValor, int pMultiplicador, decimal pValorDefault)
        {
            decimal Valor = pValorDefault;

            try
            {
                Valor = pValor * pMultiplicador;
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        /// <summary>
        /// Obter String com o Valor Formatado
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoeda(this decimal pValor)
        {
            return FormatarValorMoeda(pValor, false);
        }

        /// <summary>
        /// Obter String com o Valor Formatado
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <param name="pWithPontuacaoCompleta">Se Verdadeiro deixa o número no formato de Pontuação Completa, Milhares com "." e Decimais com Vírgulas</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoeda(this decimal pValor, bool pIsPontuacaoCompleta)
        {
            return FormatarValorMoeda(pValor, pIsPontuacaoCompleta, false, false);
        }

        /// <summary>
        /// Obter String com o Valor Formatado
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <param name="pWithPontuacaoCompleta">Se Verdadeiro deixa o número no formato de Pontuação Completa, Milhares com "." e Decimais com Vírgulas</param>
        /// <param name="pWithPontoSeparadorDecimal">Se Verdadeiro coloca Ponto no Separador Decimal, no lugar de Vírgula</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoeda(this decimal pValor, bool pWithPontuacaoCompleta, bool pWithPontoSeparadorDecimal)
        {
            return FormatarValorMoeda(pValor, pWithPontuacaoCompleta, pWithPontoSeparadorDecimal, false);
        }

        /// <summary>
        /// Obter String com o Valor Formatado
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <param name="pWithPontuacaoCompleta">Se Verdadeiro deixa o número no formato de Pontuação Completa, Milhares com "." e Decimais com Vírgulas</param>
        /// <param name="pWithPontoSeparadorDecimal">Se Verdadeiro coloca Ponto no Separador Decimal, no lugar de Vírgula</param>
        /// <param name="pExcludeSeparadoDecimal">Se Verdadeiro exclui o separador decimal do Valor</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoeda(this decimal pValor, bool pWithPontuacaoCompleta, bool pWithPontoSeparadorDecimal, bool pExcludeSeparadoDecimal)
        {
            string Valor = "";

            try
            {
                Valor = pValor.ToString("###0.00");

                if (pWithPontoSeparadorDecimal)
                {
                    Valor = Valor.Replace(",", ".");
                }

                if (pWithPontuacaoCompleta)
                {
                    Valor = pValor.ToString("###,###,###,##0.00");
                }

                if (pExcludeSeparadoDecimal)
                {
                    if (pWithPontoSeparadorDecimal)
                    {
                        Valor = Valor.Replace(".", "");
                    }
                    else
                    {
                        Valor = Valor.Replace(",", "");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        /// <summary>
        /// Obter String com o Valor Formatado com 3 casas decimais
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoedaMilesimo(this decimal pValor)
        {
            return FormatarValorMoedaMilesimo(pValor, false);
        }

        /// <summary>
        /// Obter String com o Valor Formatado com 3 casas decimais
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <param name="pWithPontuacaoCompleta">Se Verdadeiro deixa o número no formato de Pontuação Completa, Milhares com "." e Decimais com Vírgulas</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoedaMilesimo(this decimal pValor, bool pIsPontuacaoCompleta)
        {
            return FormatarValorMoedaMilesimo(pValor, pIsPontuacaoCompleta, false, false);
        }

        /// <summary>
        /// Obter String com o Valor Formatado com 3 casas decimais
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <param name="pWithPontuacaoCompleta">Se Verdadeiro deixa o número no formato de Pontuação Completa, Milhares com "." e Decimais com Vírgulas</param>
        /// <param name="pWithPontoSeparadorDecimal">Se Verdadeiro coloca Ponto no Separador Decimal, no lugar de Vírgula</param>
        /// <param name="pExcludeSeparadoDecimal">Se Verdadeiro exclui o separador decimal do Valor</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoedaMilesimo(this decimal pValor, bool pWithPontuacaoCompleta, bool pWithPontoSeparadorDecimal, bool pExcludeSeparadoDecimal)
        {
            string Valor = "";

            try
            {
                Valor = pValor.ToString("###0.000");

                if (pWithPontoSeparadorDecimal)
                {
                    Valor = Valor.Replace(",", ".");
                }

                if (pWithPontuacaoCompleta)
                {
                    Valor = pValor.ToString("##,###,###,##0.000");
                }

                if (pExcludeSeparadoDecimal)
                {
                    if (pWithPontoSeparadorDecimal)
                    {
                        Valor = Valor.Replace(".", "");
                    }
                    else
                    {
                        Valor = Valor.Replace(",", "");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        /// <summary>
        /// Obter String com o Valor Formatado
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <returns>Valor Formatado</returns>
        public static string FormatarValorMoedaSemDecimal(this decimal pValor)
        {
            string Valor = "";

            try
            {
                Valor = pValor.ToString("###0");
            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        /// <summary>
        /// Caso o Valor seja negativo ele deixa o mesmo positivo
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <returns>Valor Formatado</returns>
        public static decimal RetirarSinalNegativo(this decimal pValor)
        {
            return RetirarSinalNegativo(pValor, decimal.MinValue);
        }

        /// <summary>
        /// Caso o Valor seja negativo ele deixa o mesmo positivo
        /// </summary>
        /// <param name="pValor">Valor que será formatado</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Valor Formatado</returns>
        public static decimal RetirarSinalNegativo(this decimal pValor, decimal pValorDefault)
        {
            decimal Valor = pValorDefault;

            try
            {
                if (pValor < 0)
                {
                    Valor = pValor * -1;
                }
                else
                {
                    Valor = pValor;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Valor;
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Adicionar Dias Uteis
        /// </summary>
        /// <param name="pData">Data</param>
        /// <param name="pDias">Qtde de Dias Uteis</param>
        /// <param name="pConsiderarSabado">Considera o Sábado como Dia Útil</param>
        public static DateTime AddDiasUteis(this DateTime pData, Int16 pDias, bool pConsiderarSabado = false)
        {
            Int16 dia = 0;

            try
            {
                if (pDias == 0)
                {
                    switch (pData.DayOfWeek)
                    {
                        case DayOfWeek.Saturday:

                            if (!pConsiderarSabado)
                            {
                                pData = pData.AddDays(2);
                            }
                            dia++;
                            break;

                        case DayOfWeek.Sunday:
                            pData = pData.AddDays(1);
                            dia++;
                            break;

                        default:
                            dia++;
                            break;
                    }
                }
                else if (pDias > 0)
                {
                    while (dia < pDias)
                    {
                        pData = pData.AddDays(1);

                        switch (pData.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:

                                if (!pConsiderarSabado)
                                {
                                    pData = pData.AddDays(2);
                                }
                                dia++;
                                break;

                            case DayOfWeek.Sunday:
                                pData = pData.AddDays(1);
                                dia++;
                                break;

                            default:
                                dia++;
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return pData;
        }

        /// <summary>
        /// Adicionar Dias com a Regra de Data Prevista
        /// </summary>
        /// <param name="pData">Data</param>
        /// <param name="pDias">Qtde de Dias que devem ser Adicionados</param>
        public static DateTime AddDiasDataPrevista(this DateTime pData, Int16 pDias, bool pConsiderarSabado = false)
        {
            pData = pData.AddDays(pDias);

            try
            {
                switch (pData.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        if (!pConsiderarSabado)
                        {
                            pData = pData.AddDays(-1);
                        }
                        break;

                    case DayOfWeek.Sunday:
                        pData = pData.AddDays(-2);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return pData;
        }

        /// <summary>
        /// Valida se a Data Existe, caso não subtraí um dia e repete a regra.
        /// Metodo criado para os Prazos do Trabalhista que ocorrem no dia 31 porém existem meses que não possuem o dia
        /// </summary>
        /// <param name="pData">Data</param>
        public static DateTime ObterDataValida(this string pData)
        {
            DateTime data = DateTime.MinValue;

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    data = pData.ConvertToDateTime(DateTime.MinValue);

                    if (data != DateTime.MinValue)
                    {
                        break;
                    }
                    else
                    {
                        pData = pData.Substring(0, 2).ConvertToInt() - 1 + pData.Substring(2, 8);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return data;
        }

        #endregion

    }
}


