## labs

Dois projetos nessa <i>branch:</i><br><br>

### 1 - API<br>
  Responsável pela manipulação dos dados de empregados (<i>Employee</i>):<BR>
  Lista (paginado), Insere e Exclui.<br>
  ```bash
  Solution LlabsAPI.sln
  ```
  Está configurado para rodar na porta 8000 (http://localhost:8000/)
   
### 2 - MVC<br>
  Faz o uso da API para trabalhar com os dados.<br>
  ```bash
  Solution LlabsMVC.sln
  ```
  Se conecta à API pela porta 8000, a configuração da conexão é feita no arquivo web.config<br>
  
```c#
   <!-- Configuration for URL API -->
    <add key="urlAPI" value ="http://localhost:8000/"/>
``` 
  Para usar:<br>
  Abra a Solution LlabAPI<br>
  Rode em modo debug. Ele irá iniciar uma api na porta 8000 local.<br>
  Abra a Solution LlabMVC<BR>
  Rode a Solution. Essa aplicação MVC fará o uso da API.<br><br>
  
### extra - Teste Unitário<br>
  Existe um terceiro projeto, UnitTestProject (encontra-se na solution da API), que faz um teste básico nos três métodos principais da API (insert, delete, list).<br>
  Para rodá-lo é necessario alterar a string de conexão da API, informe o caminho físico do banco de dados (como é um projeto totalmente local, o Banco de dados é um arquivo MDF local).<br>
  Para configurar, altere a linha 16 da classe ```c#RepositoryEmployee```: <br>
  ```c#
  ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\LlabEmployee.mdf; Integrated Security = True";
  ``` 
  

