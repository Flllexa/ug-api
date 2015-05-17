using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class CustomVariables
    {
        public string name { get; set; }
        public string value { get; set; }
        public bool _destroy { get; set; }

    }

    public class Logs
    {
        /// <summary>
        /// Descrição da Entrada de Log
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Anotações da Entrada de Log
        /// </summary>
        public string notes { get; set; }

    }

    public class Feature
    {
        /// <summary>
        /// Nome da Funcionalidade
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Identificador único da funcionalidade
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// Valor da Funcionalidade (número maior que 0)
        /// </summary>
        public int value { get; set; }
    }

    public class Prices
    {
        /// <summary>
        /// Moeda do Preço (Somente "BRL" por enquanto)
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// Preço do Plano em Centavos
        /// </summary>
        public int value_cents { get; set; }
    }

    public class CreditCard
    {
        /// <summary>
        /// Número do Cartão de Crédito
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// CVV do Cartão de Crédito
        /// </summary>
        public string verification_value { get; set; }

        /// <summary>
        /// Nome do Cliente como está no Cartão
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Sobrenome do Cliente como está no Cartão
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Mês de Vencimento no Formato MM (Ex: 01, 02, 12)
        /// </summary>
        public string month { get; set; }

        /// <summary>
        /// Ano de Vencimento no Formato YYYY (2014, 2015, 2016)
        /// </summary>
        public string year { get; set; }
    }

    public class PaymentMethodData
    {
        public string token { get; set; }
        public string display_number { get; set; }
        public string brand { get; set; }
    }

    public class ChargeItem
    {
        public string description { get; set; }
        public int quantity { get; set; }
        public string price_cents { get; set; }
    }

    public class Payer
    {
        public string cpf_cnpj { get; set; }
        public string name { get; set; }
        public string phone_prefix { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public Address address { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string number { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip_code { get; set; }
    }

    public class BankSlip
    {
        public string digitable_line { get; set; }
        public string barcode_data { get; set; }
        public string barcode { get; set; }
    }

    public class InvoiceItem
    {
        public string id { get; set; }
        public string description { get; set; }
        public int price_cents { get; set; }
        public int quantity { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string price { get; set; }
    }

    public class Variable
    {
        public string id { get; set; }
        public string variable { get; set; }
        public string value { get; set; }
    }

    public class InvoiceListModel
    {
        public Facets facets { get; set; }
        public int totalItems { get; set; }
        public List<InvoiceResponse> items { get; set; }
    }

    public class Term
    {
        public string term { get; set; }
        public int count { get; set; }
    }

    public class Status
    {
        public string _type { get; set; }
        public int missing { get; set; }
        public int total { get; set; }
        public int other { get; set; }
        public Term[] terms { get; set; }
    }

    public class Facets
    {
        public Status status { get; set; }
    }

    public class MarketplaceAccount
    {
        /// <summary>
        ///  ('Até R$ 100,00', 'Entre R$ 100,00 e R$ 500,00', 'Mais que R$ 500,00')
        /// </summary>
        public string price_range { get; set; }
        public bool physical_products { get; set; }

        /// <summary>
        /// business description
        /// </summary>
        public string business_type { get; set; }

        /// <summary>
        /// 'Pessoa Física' ou 'Pessoa Jurídica'
        /// </summary>
        public string person_type { get; set; }

        /// <summary>
        /// true is recommended
        /// </summary>
        public bool automatic_transfer { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string cnpj { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string company_name { get; set; }

        /// <summary>
        /// (optional) case is cnpj
        /// </summary>
        public string cpf { get; set; }

        /// <summary>
        /// (optional) case is cnpj
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string cep { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// (optional) case is cpf
        /// </summary>
        public string resp_name { get; set; }

        /// <summary>
        /// (optional) case is cpf
        /// </summary>
        public string resp_cpf { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string bank { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string bank_ag { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string account_type { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string bank_cc { get; set; }

        public string document_id { get; set; }

        public string document_cpf { get; set; }

        public string document_activity { get; set; }
    }
}
