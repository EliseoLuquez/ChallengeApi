# ChallengeApi
O desafio
Nosso desafio contempla em resolver a seguinte situação do cotidiano dos operadores de pontos de venda (PDV):

Esses profissionais tem grande responsabilidade em suas mãos e a maior parte do seu tempo é gasto recebendo valores de clientes e, em alguns casos, fornecendo troco.

Seu desafio é criar uma API que leia o valor total a ser pago e o valor efetivamente pago pelo cliente, em seguida informe o menor número de cédulas e moedas que devem ser fornecidas como troco.

Regras
Notas disponíveis: R$ 10,00 - R$ 20,00 - R$ 50,00 - R$ 100,00
Moedas disponíveis: R$0,01 - R$0,05 - R$0,10 - R$0,50
Entregar o menor número de notas possíveis
Exemplo:

Valor do Troco: R$ 30,00
Resultado Esperado: Entregar 1 nota de R$20,00 e 1 nota de R$10,00

Valor do Troco: R$ 80,00
Resultado Esperado: Entregar 1 nota de R$50,00, 1 nota de R$20,00 e 1 nota de R$10,00

O que será avaliado
Estrutura e organização do código
Qualidade do código
Boas práticas e padrões utilizados
Requisitos obrigatórios
.Net Core
A aplicação deve conectar-se em um banco de dados utilizando Entity Core (SQL Server ou Postgree)
As consultas devem ser realizadas utilizando o ORM Dapper
As transações de troco (saída de caixa) devem ficar registradas
A aplicação deve estar coberta com testes unitários
Swagger para documentação das rotas
Requisitos desejáveis
Docker
Transações em um banco não relacional


**Instruções

Execute SCRIPTS para criar o banco de dados no MICROSOFT SQL SERVER localizado na pasta /DB

Modifique o arquivo "appsettings.Development.json" no projeto TotvsChallengeApp.Api modificando a chave "DefaultConnection" com a connectionString do banco de dados local criado em seu computador.

Execute o projeto APIPuntoVenta, ele será iniciado na documentação do swagger

Existem dois terminais no controlador.

ChargeAndCalculate: recebe o valor a pagar e o valor pago, valida os valores, se não houver erro calcula o troco e salva a transação
GetTransactions: lista as transações realizadas ordenadas da mais recente para a mais antiga