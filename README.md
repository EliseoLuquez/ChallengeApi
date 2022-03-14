# ChallengeApi
**Instruções

Execute SCRIPTS para criar o banco de dados no MICROSOFT SQL SERVER localizado na pasta /DB

Modifique o arquivo "appsettings.Development.json" no projeto TotvsChallengeApp.Api modificando a chave "DefaultConnection" com a connectionString do banco de dados local criado em seu computador.

Execute o projeto APIPuntoVenta, ele será iniciado na documentação do swagger

Existem dois terminais no controlador.

ChargeAndCalculate: recebe o valor a pagar e o valor pago, valida os valores, se não houver erro calcula o troco e salva a transação
GetTransactions: lista as transações realizadas ordenadas da mais recente para a mais antiga