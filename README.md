## finanblue
Teste realizado para a empresa Finanblue. Deterinado a criar um CRUD simples de empresas, produtos e vendas. 
O Back End foi criado usando C# e o Front End foi criado utilizando o Angular. 

## Instalação
Após baixar os dois projetos no seu comoputador serão necessárias algumas configurações antes do sistema funcionar. 

1. Configurar a ConnectionString do Porstgress -> Na solução do C# e no projeto Finanblue.API, dentro do arquivo appsettings.json e alterar o caminho colocado no FinanblueDb para a connection string do seu uso.
    1. Opcionalmente pode ser rodado o Migration para adicionar os primeiros dados do sistema.
2. Abrir o Postgress e deixar o banco de dados conectado
3. Com o projeto Finanblue.API como projeto de inicialização, iniciar a solução dentro do VisualStudio
4. Com o VisualStudioCode (já devidamente configurado com o AngularCli), abrir a pasta FinanblueFront no console e digitar ng serve. 
5. No navegador de prefercência acessar o https://localhost:4200
6. Utilizar o sistema.

## Imagens

# Swagger
![image](https://user-images.githubusercontent.com/60353241/229652041-8733b81d-4fd9-4855-88b6-46e1f42646fe.png)

#Sistema
![image](https://user-images.githubusercontent.com/60353241/229652067-6e98de4f-1f95-4590-9cb8-b7d7872a5fbd.png)
![image](https://user-images.githubusercontent.com/60353241/229652083-1fcc1f1c-d3af-48b9-91cf-deab871f183d.png)
