# Google Tests
Testes funcionais do site google.com utilizando Selenium WebDriver e .Net

## Como Usar

Primeiro é necessário baixar ou clonar o repositório a partir da brach main

Para clonar o projeto basta executar o comando em um terminal na pasta de destino

```bash
git clone "https://github.com/jguih/GoogleTests.git"
```

Também é possível fazer download do projeto aqui pelo github

Com uma cópia local do projeto, existem duas formas de executar os testes

### .NET CLI

<strong>Requisitos:</strong> .NET Core 3.1 SDK ou versão superior

Abra a pasta do projeto e execute o comando no terminal:

```bash
dotnet test
```

Os testes serão executados e o resultado aparecerá no terminal

### Visual Studio

<strong>Requisitos:</strong> Visual Studio

#### Abra a solução do projeto no Visual Studio

É possível abrir a solução de duas formas:

1. Com o Visual Studio aberto, no menu superior, clique em Arquivo > Abrir > Projeto/Solução

   ![image](https://user-images.githubusercontent.com/62079543/210150110-d75e24bf-7764-4cb3-a702-5524f931c4da.png)
   
   Em seguida, encontre o arquivo "GoogleTests.sln" na pasta do projeto e clique em "Abrir"

2. Na página inicial do Visual Studio, clique em "Abrir um Projeto ou uma Solução"

   ![image](https://user-images.githubusercontent.com/62079543/210150152-f068c361-4659-48a8-b801-a7dd423026ec.png)

   Em seguida, encontre o arquivo "GoogleTests.sln" na pasta do projeto e clique em "Abrir"
   
3. Encontre o arquivo "GoogleTests.sln" na pasta do projeto, dê dois clicks para abrí-lo e escolha Visual Studio

#### Executar os Testes

No menu superior, clique em Teste > Executar Todos os Testes

![image](https://user-images.githubusercontent.com/62079543/210149872-a676213a-c1a4-4fc9-99b0-83280766fdc1.png)

Todos os testes serão executados e os resultados estarão visíveis no genrenciador de testes
