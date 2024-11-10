
# 🚗 **MauiAppMeuCombustivel** 

![Platform](https://img.shields.io/badge/Platform-Multiplatform-blue?style=flat-square) ![Language](https://img.shields.io/badge/Language-C%23-brightgreen?style=flat-square) ![Framework](https://img.shields.io/badge/Framework-.NET%20MAUI-yellowgreen?style=flat-square) ![Status](https://img.shields.io/badge/Status-Completed-green?style=flat-square)

---

## ✨ **Resumo**
O **MauiAppMeuCombustivel** é um aplicativo multiplataforma desenvolvido com **.NET MAUI** em **C#**. O app calcula o custo de combustível baseado na distância percorrida, preço do combustível e eficiência do veículo. Foi projetado para ser executado em diversas plataformas, incluindo **Android**, **iOS**, **Windows**, **macOS**, entre outras. 

---

## 📋 **Objetivos**
- Desenvolver um app multiplataforma com uma interface gráfica intuitiva e responsiva.
- Facilitar o cálculo do consumo de combustível, oferecendo uma interface amigável.
- Explorar as capacidades do **.NET MAUI** em criar aplicativos que rodem em diferentes dispositivos com um único código-base.

---

## 💡 **Funcionalidades**
- **Entrada de dados:** Insira a distância percorrida, o consumo médio do veículo (km/l) e o preço do combustível.
- **Cálculo:** Cálculo automático do custo de combustível baseado nos dados fornecidos.
- **Multiplataforma:** Suporte a Android, iOS, macOS, Windows.
- **Interface amigável e responsiva:** Layout adaptado a diferentes tamanhos de tela, garantindo boa usabilidade.

---

## 📂 **Estrutura do Projeto**

### 🗂️ **Pastas e Arquivos Principais**

| **Diretório/Arquivo**            | **Descrição**                                                                                       |
|-----------------------------------|-----------------------------------------------------------------------------------------------------|
| `bin/` e `obj/`                   | Pastas temporárias utilizadas durante a compilação e geração de binários.                            |
| `Platforms/`                      | Contém arquivos específicos de cada plataforma (Android, iOS, etc).                                 |
| `Properties/launchSettings.json`  | Configurações de execução e variáveis de ambiente.                                                   |
| `Resources/`                      | Armazena ícones, imagens, fontes e estilos usados no app.                                            |
| `App.xaml`                        | Define os recursos globais como estilos e temas do aplicativo.                                       |
| `App.xaml.cs`                     | Código por trás da inicialização do aplicativo e navegação.                                          |
| `AppShell.xaml`                   | Estrutura a navegação do aplicativo com Shell (abas e hierarquias).                                  |
| `MainPage.xaml`                   | Define a interface principal onde o cálculo de combustível é realizado.                              |
| `MainPage.xaml.cs`                | Código C# associado à lógica de cálculo da página principal.                                         |
| `MauiAppMeuCombustivel.csproj`    | Arquivo de projeto que especifica as dependências e configurações do app.                            |
| `.gitignore`                      | Arquivo para ignorar pastas e arquivos não necessários ao controle de versão, como binários.         |
| `MauiAppMeuCombustivel.sln`       | Arquivo de solução que agrega o projeto no Visual Studio para facilitar sua organização.             |

---

## ⚙️ **Tecnologias Utilizadas**
- **Linguagem:** C#
- **Framework:** .NET MAUI
- **Plataformas:** Android, iOS, macOS, Windows
- **IDE:** Visual Studio 2022

---

## 🚀 **Como Executar o Projeto**

### **Pré-requisitos**
- .NET SDK 8.0 ou superior.
- Visual Studio 2022 com o workload .NET MAUI instalado.
- Emulador ou dispositivo real para Android/iOS se necessário.

### **Passos para Compilar e Executar**
```bash
# Clone o repositório
git clone https://github.com/usuario/MauiAppMeuCombustivel.git

# Navegue até o diretório do projeto
cd MauiAppMeuCombustivel

# Compile e execute o projeto
dotnet build
dotnet run
```
- Para rodar especificamente em Android:
```bash
dotnet build -t:Run -f net8.0-android
```

---


## 🔄 **Última Alteração**
A última alteração implementada no projeto envolveu a **adição de novos campos de entrada** no formulário, permitindo que o usuário insira a **marca** e o **modelo** do veículo antes de realizar o cálculo. Além disso, a lógica do botão "Qual compensa mais?" foi atualizada para incluir essas informações na mensagem de resultado, tornando a experiência mais personalizada.

### Detalhes da alteração:
1. **Adição de campos**:
   - Foram adicionados dois novos campos de texto para a entrada da marca e modelo do veículo.
   
   No arquivo `mainpage.xaml`, os campos foram adicionados da seguinte forma:

   ```xml
   <Label Text="Marca do Veículo:" />
   <Entry x:Name="txt_marca" Placeholder="Ex: Ford" />

   <Label Text="Modelo do Veículo:" />
   <Entry x:Name="txt_modelo" Placeholder="Ex: Fiesta" />
   ```

2. **Atualização da lógica do cálculo**:
   - A lógica do botão foi modificada para incluir a marca e o modelo do veículo na mensagem final.

   No arquivo `mainpage.xaml.cs`, a lógica foi alterada assim:

   ```csharp
   private void Button_Clicked(System.Object sender, System.EventArgs e)
   {
       try
       {
           double etanol = Convert.ToDouble(txt_etanol.Text);
           double gasolina = Convert.ToDouble(txt_gasolina.Text);
           string marca = txt_marca.Text;
           string modelo = txt_modelo.Text;

           string msg = "";

           if (etanol <= (gasolina * 0.7))
           {
               msg = $"O etanol está compensando para o seu {marca} {modelo}.";
           }
           else
           {
               msg = $"A gasolina está compensando para o seu {marca} {modelo}.";
           }

           DisplayAlert("Calculado", msg, "OK");

       } catch(Exception ex)
       {
           DisplayAlert("Ops", ex.Message, "Fechar");
       }
   }
   ```

### O que mudou?
- **Antes**: O app apenas comparava os preços de etanol e gasolina e retornava qual dos dois era mais vantajoso.
- **Agora**: Além de fazer a comparação, o app exibe uma mensagem personalizada com a marca e o modelo do veículo inseridos pelo usuário.

Essa alteração melhora a usabilidade e adiciona um toque pessoal ao resultado, tornando o aplicativo mais interessante para o usuário.

---


## 🛠️ **Conclusão**
O **MauiAppMeuCombustivel** exemplifica como o **.NET MAUI** pode ser usado para criar aplicativos eficientes e funcionais em diversas plataformas com um único código. A adição dos novos campos e o refinamento da interface refletem o compromisso de melhorar continuamente a usabilidade e a funcionalidade do app.

---


