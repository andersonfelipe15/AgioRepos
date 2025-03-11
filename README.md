# AgioRepos - Testes Automatizados em C#

![Test Automation](https://img.shields.io/badge/Test%20Automation-C%23-blue)

## 📌 Sobre o Projeto
Este repositório contém testes automatizados desenvolvidos em **C#**, utilizando frameworks modernos para garantir qualidade e confiabilidade no desenvolvimento de software.

## 🚀 Tecnologias Utilizadas

- **C#** - Linguagem principal de programação.
- **Selenium WebDriver** - Para automação de testes em navegadores.
- **xUnit/NUnit** - Frameworks de testes unitários.
- **FluentAssertions** - Para asserções mais legíveis e intuitivas.
- **SpecFlow** - Para testes BDD (Behavior Driven Development) (opcional, se aplicável).

## 📂 Estrutura do Projeto

```
AgioRepos/
│-- src/               # Código-fonte do projeto
│-- tests/             # Testes automatizados
│   ├── UI/            # Testes de interface gráfica (Selenium)
│   ├── API/           # Testes de API
│   ├── Unit/          # Testes unitários
│-- reports/           # Relatórios de execução
│-- README.md          # Documentação
```

## 🔧 Como Configurar e Executar

### 1️⃣ Pré-requisitos
- .NET SDK instalado ([Download aqui](https://dotnet.microsoft.com/download))
- Navegador compatível com o WebDriver (se estiver usando Selenium)

### 2️⃣ Clonar o repositório
```sh
 git clone https://github.com/andersonfelipe15/AgioRepos.git
 cd AgioRepos
```

### 3️⃣ Restaurar pacotes NuGet
```sh
 dotnet restore
```

### 4️⃣ Executar os testes
Para rodar os testes unitários e de API:
```sh
 dotnet test
```

Se houver testes de UI com Selenium:
```sh
 dotnet test --filter Category=UI
```

### 5️⃣ Executar testes de UI com Selenium
#### Configuração inicial
1. Instale o WebDriver correto para seu navegador:
   - **Chrome**: [Download ChromeDriver](https://sites.google.com/chromium.org/driver/)
   - **Firefox**: [Download GeckoDriver](https://github.com/mozilla/geckodriver/releases)
   - **Edge**: [Download EdgeDriver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/)

2. Adicione o WebDriver ao PATH do sistema ou configure no código.

#### Executando os testes de UI
1. Navegue até a pasta dos testes de UI:
   ```sh
   cd tests/UI
   ```
2. Execute os testes:
   ```sh
   dotnet test
   ```
3. Para rodar testes específicos:
   ```sh
   dotnet test --filter "FullyQualifiedName=Namespace.TestClass.Method"
   ```
4. Caso precise visualizar a execução dos testes em tempo real, certifique-se de que o modo "headless" está desativado no código do WebDriver.


## 📊 Relatórios de Testes
Caso utilize um gerador de relatórios, como **ExtentReports** ou **Allure**, os relatórios estarão disponíveis na pasta `reports/`.

## 🤝 Contribuição
Sinta-se à vontade para abrir **issues** ou enviar **pull requests** para melhorias.

## 📜 Licença
Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---

💡 **Dica:** Mantenha seu README sempre atualizado para facilitar a colaboração! 🚀
