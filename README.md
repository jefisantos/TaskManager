# Gerenciador de Tarefas

## Descrição
Este projeto é uma aplicação de gerenciamento de tarefas construída com .NET para o backend e Vue.js para o frontend, utilizando banco de dados SQLite.

## Pré-requisitos
- Node.js (versão X.X.X)
- npm (versão X.X.X)
- .NET SDK (versão 9.0)
- SQLite

## Instalação

### Clonando o Repositório
1. Clone o repositório:
    ```bash
    git clone https://github.com/jefisantos/TaskManager.git
    cd TaskManager
    ```

### Backend
1. Navegue até o diretório `TaskManagerAPI`:
    ```bash
    cd TaskManagerAPI
    ```

2. Instale as dependências do .NET:
    ```bash
    dotnet restore
    ```

3. Crie um arquivo `appsettings.json` na raiz do diretório `TaskManagerAPI` com o seguinte conteúdo:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=tasks.db"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

4. Inicie o servidor backend:
    ```bash
    dotnet run
    ```

### Frontend
1. Navegue até o diretório `task-manager`:
    ```bash
    cd ../task-manager
    ```

2. Instale as dependências:
    ```bash
    npm install
    ```

3. Inicie o servidor frontend:
    ```bash
    npm run serve
    ```

4. Acesse a aplicação no navegador:
    - Frontend: `http://localhost:8080`
    - Backend: `http://localhost:5004`


## Dependências

### Backend
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.AspNetCore.OpenApi
- Moq
- Swashbuckle.AspNetCore
- System.ComponentModel.Annotations
- xUnit
- xUnit.runner.visualstudio

### Frontend
- Vue.js
- Axios
- FontAwesome


