using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Barbearia.Shared
{
    public static class Conversoes
    {
        #region Object

        /// <summary>
        /// Conversão de um objeto para um determinado tipo.
        /// </summary>
        /// <typeparam name="Type">Tipo que será convertido o objeto.</typeparam>
        /// <param name="value"></param>
        /// <returns>Retorna o objeto convertido para o novo tipo.</returns>
        public static Type ConvertToObject<Type>(this object value)
        {
            Type retObject = default(Type);

            if (value != null)
            {
                try
                {
                    retObject = (Type)value;
                }
                catch { }
            }
            return retObject;
        }

        #endregion

        #region String

        /// <summary>
        /// Convert String em Decimal
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static decimal ConvertToDecimal(this string pTexto)
        {
            return ConvertToDecimal(pTexto, decimal.MinValue);
        }

        /// <summary>
        /// Convert String em Decimal
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static decimal ConvertToDecimal(this string pTexto, decimal pValorDefault)
        {
            if (pTexto == "")
            {
                return pValorDefault;
            }

            decimal Valor = pValorDefault;

            decimal.TryParse(pTexto, out Valor);

            return (Valor != decimal.MinValue ? Valor : pValorDefault);
        }

        /// <summary>
        /// Convert String em Int
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static int ConvertToInt(this string pTexto)
        {
            return ConvertToInt(pTexto, int.MinValue);
        }

        /// <summary>
        /// Convert String em Int
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static int ConvertToInt(this string pTexto, int pValorDefault)
        {
            if (pTexto == "")
            {
                return pValorDefault;
            }

            int Valor = pValorDefault;

            int.TryParse(pTexto, out Valor);

            return (Valor != int.MinValue ? Valor : pValorDefault);
        }

        /// <summary>
        /// Convert String em Int16
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static Int16 ConvertToInt16(this string pTexto)
        {
            return ConvertToInt16(pTexto, Int16.MinValue);
        }

        /// <summary>
        /// Convert String em Int16
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static Int16 ConvertToInt16(this string pTexto, Int16 pValorDefault)
        {
            if (pTexto == "")
            {
                return pValorDefault;
            }

            Int16 Valor = pValorDefault;

            Int16.TryParse(pTexto, out Valor);

            return (Valor != Int16.MinValue ? Valor : pValorDefault);
        }

        /// <summary>
        /// Convert String em Int32
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static Int32 ConvertToInt32(this string pTexto)
        {
            return ConvertToInt32(pTexto, Int32.MinValue);
        }

        /// <summary>
        /// Convert String em Int32
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static Int32 ConvertToInt32(this string pTexto, Int32 pValorDefault)
        {
            if (pTexto == "")
            {
                return pValorDefault;
            }

            Int32 Valor = pValorDefault;

            Int32.TryParse(pTexto, out Valor);

            return (Valor != Int32.MinValue ? Valor : pValorDefault);
        }

        /// <summary>
        /// Convert String em Int64
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static Int64 ConvertToInt64(this string pTexto)
        {
            return ConvertToInt64(pTexto, Int64.MinValue);
        }

        /// <summary>
        /// Convert String em Int64
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static Int64 ConvertToInt64(this string pTexto, Int64 pValorDefault)
        {
            if (pTexto == "")
            {
                return pValorDefault;
            }

            Int64 Valor = pValorDefault;

            Int64.TryParse(pTexto, out Valor);

            return (Valor != Int64.MinValue ? Valor : pValorDefault);
        }

        /// <summary>
        /// Convert String em Double
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static double ConvertToDouble(this string pTexto)
        {
            return ConvertToDouble(pTexto, double.MinValue);
        }

        /// <summary>
        /// Convert String em Double
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static double ConvertToDouble(this string pTexto, double pValorDefault)
        {
            if (pTexto == "")
            {
                return pValorDefault;
            }

            double Valor = pValorDefault;

            double.TryParse(pTexto, out Valor);

            return (Valor != double.MinValue ? Valor : pValorDefault);
        }

        /// <summary>
        /// Convert String em Boolean
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        /// 
        public static bool ConvertToBool(this string pTexto)
        {
            return ConvertToBool(pTexto, false);
        }

        /// <summary>
        /// Convert String em Boolean
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static bool ConvertToBool(this string pTexto, bool pCondicaoDefault)
        {
            if (pTexto == "")
            {
                return pCondicaoDefault;
            }

            bool Condicao = pCondicaoDefault;

            bool.TryParse(pTexto, out Condicao);

            return Condicao;
        }

        /// <summary>
        /// Convert String em DateTime
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static string ConvertToDateTimeToString(this DateTime pTexto, string pMascara)
        {
            if (pTexto.ToString(pMascara).Contains("01/01/0001"))
                return string.Empty;
            else
                return pTexto.ToString(pMascara);
        }

        /// <summary>
        /// Convert String em DateTime
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível ou Valor Mínimo</returns>
        public static DateTime ConvertToDateTime(this string pTexto)
        {
            return ConvertToDateTime(pTexto, DateTime.MinValue);
        }

        /// <summary>
        /// Convert String em DateTime
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <param name="pValorDefault">Valor Default de Retorno</param>
        /// <returns>Retorna Conversão se possível ou Valor Default</returns>
        public static DateTime ConvertToDateTime(this string pTexto, DateTime pDataDefault)
        {
            if (pTexto == "")
            {
                return pDataDefault;
            }

            DateTime Data = pDataDefault;

            DateTime.TryParse(pTexto, out Data);

            return (Data != DateTime.MinValue ? Data : pDataDefault);
        }

        /// <summary>
        /// Convert string to DateTime
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public static string ConvertToDateTimeExtenso(this DateTime pData)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = pData.Day;
            int ano = pData.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(pData.Month));
            string dataExtenso = dia + " de " + mes + " de " + ano;

            return dataExtenso;
        }

        /// <summary>
        /// Convert objeto em string
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível</returns>
        public static string ConvertObjectToString(this object pTexto, string pValorDefault = "")
        {
            if (string.IsNullOrEmpty(pTexto.ToString()))
            {
                return pValorDefault;
            }

            return (pTexto.ToString());
        }

        /// <summary>
        /// Convert objeto em DateTime
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível</returns>
        public static DateTime ConvertObjectToDateTime(this object pTexto)
        {
            if (string.IsNullOrEmpty(pTexto.ConvertObjectToString()))
            {
                return DateTime.MinValue;
            }

            return (pTexto.ConvertObjectToString().ConvertToDateTime());
        }

        /// <summary>
        /// Convert objeto em inteiro
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível</returns>
        public static int ConvertObjectToInt(this object pTexto, int pValorDefault = 0)
        {
            if (string.IsNullOrEmpty(pTexto.ConvertObjectToString()))
            {
                return 0;
            }

            return (int.Parse(pTexto.ToString()));
        }

        /// <summary>
        /// Convert objeto em decimal
        /// </summary>
        /// <param name="pTexto">Texto que será Convertido</param>
        /// <returns>Retorna Conversão se possível</returns>
        public static decimal ConvertObjectToDecimal(this object pTexto, decimal pValorDefault = 0)
        {
            if (string.IsNullOrEmpty(pTexto.ConvertObjectToString()))
            {
                return pValorDefault;
            }

            return (decimal.Parse(pTexto.ToString()));
        }

        public static bool ConvertObjectToBoolean(this object pValor)
        {
            string valor = pValor.ConvertObjectToString().Trim();

            bool resultado = false;

            if (!string.IsNullOrEmpty(valor) && (valor == "true" || valor == "1"))
            {
                resultado = true;
            }

            return resultado;
        }


        /// <summary>
        /// Convert Moeda em Extenso
        /// </summary>
        /// <param name="pValor">Valor que será convertido</param>
        /// <returns>Retorna o valor por extenso</returns>
        public static string ConvertValorToExtenso(this string pValor)
        {
            if (pValor.ConvertToDecimal(0) <= 0 || pValor.ConvertToDecimal(0) >= 1000000000000000)
                throw new Exception("maior que 0 ou menor que 10.000.000.000.000,00");
            else
            {
                string strValor = pValor.ConvertToDecimal(0).ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;

                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += escreva_parte(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " TRILHÃO" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);

                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " DE";
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                                valor_por_extenso += " DE";
                            else
                                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                                valor_por_extenso += " DE";

                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += " REAL";
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            valor_por_extenso += " REAIS";

                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " E ";
                    }

                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " CENTAVO";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " CENTAVOS";
                }
                return valor_por_extenso;
            }
        }

        /// <summary>
        /// Escreve unidade, dezena e centena
        /// </summary>
        /// <param name="pValor">Valor que será convertido</param>
        /// <returns></returns>
        static string escreva_parte(decimal pValor)
        {
            if (pValor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (pValor > 0 & pValor < 1)
                {
                    pValor *= 100;
                }
                string strValor = pValor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Converter DataTime em string no Padrão de Formatação
        /// </summary>
        /// <param name="pData">Data que será convertida e Formatada</param>
        /// <param name="pWithHora">Verdadeiro para Formatar com Horas e Falso para Formatar somente a Data</param>
        /// <returns>Retorna Data Formatada</returns>
        public static string ConvertDateTimeToString(this DateTime pData, bool pWithHora)
        {
            DateTime data = pData;
            string _data = string.Empty;

            if (pWithHora)
            {
                _data = data.ToString("dd/MM/yyyy hh:mm:ss");
            }
            else
            {
                _data = data.ToString("dd/MM/yyyy");
            }

            return _data;
        }

        #endregion
    }
}
