criar a base de dados

remover a pasta em "Suprema.Comum.Infra\Migrations"

seta o projeto 
Suprema.WebApi

no console   executar o comando "add-migration inicio"

![image](https://github.com/lvmendes01/suprema/assets/4749630/56589331-b1e8-4973-9cb7-b21015d0ff63)


depois executar o comando "update-database"
![image](https://github.com/lvmendes01/suprema/assets/4749630/7d68b2d2-9a45-47cd-b666-249276bebb84)


# suprema

#Teste de Desenvolvedor Back-End

#Requisitos

• Crie um projeto ASP.NET Core Web API.
• Utilize Entity framework ou Dapper com banco em memória.
• Implemente a autenticação JWT para proteger os endpoints da API.
• Documentação Swagger


#Regras de Negócio

• Garanta que o mesmo usuário não possa ser inserido duas vezes na mesma mesa.
• Uma mesa precisa ter no mínimo 3 jogadores para que haja um ganhador.
• Validar minimamente os dados imputados como cpf, phone.
