# 🧩 GFM.Mediator.netcore9

## 📖 Visão Geral

O **GFM.Mediator.netcore9** é um projeto criado com o objetivo de substituir bibliotecas pagas ou com planos comerciais futuros como **MediatR** ou **Autometer**, oferecendo uma alternativa open source leve, extensível e de fácil integração.

Este projeto foi desenvolvido em **.NET Core 9.0** e segue os princípios do **CQRS**, com suporte nativo a:

- 📤 `Send` (requisições com resposta)
- 📣 `Publish` (eventos do tipo pub/sub)
- 🧪 Behaviors (`Pipeline` para validações, exceções e extensões futuras)
- ✅ Validadores personalizados
- 🧲 Tratamento de exceções centralizado
- 📦 Injeção de dependência baseada em Assembly (como no MediatR)

---

## 🏗 Estrutura da Solução

```bash
📂 GFM.Mediator.Foundation
├── 📂 App              # Projeto de testes, exemplos e validações
│   ├── GFM.Foundation.Application
│   ├── GFM.Foundation.Batch
│   ├── GFM.Foundation.CrossCutting
│   ├── GFM.Foundation.Domain
│   ├── GFM.Foundation.Infrastructure
├── 📂 src              # Projeto principal reutilizável
│   ├── GFM.Foundation
```

---

## ⚙️ Tecnologias Utilizadas

- **.NET Core 9.0**
- **CQRS Pattern**
- **Pipeline Behaviors** (como MediatR)
- **Injeção de dependência via Assembly**
- **xUnit** (para testes unitários)
- **Console App** como exemplo

---

## 🚀 Como Executar o Projeto

### 🧪 Rodar o exemplo

```bash
cd App
dotnet run --project GFM.Foundation.Batch
```

### ✅ Rodar testes

```bash
dotnet test
```

---

## 📁 Organização do Código

### 📂 src/GFM.Foundation

Contém o core do `Mediator` customizado, incluindo:

- `IMediator`, `IRequest`, `IRequestHandler`
- `INotification`, `INotificationHandler`
- `PipelineBehavior`, `ValidationBehavior`, `ExceptionHandlingBehavior`
- `Validator`, `IErrorHandler` (opcional)

### 📂 App/GFM.Foundation.Application

Contém os exemplos de uso e handlers reais simulando comandos, eventos e subscribers.

---

## ✨ Por que usar este projeto?

- ✅ **Zero dependências externas**
- 🔓 **Open Source**
- 💡 **Extensível**: você pode adicionar logging, métricas, policies, cache...
- 🔁 **Padronizado**: segue arquitetura moderna baseada em CQRS, como grandes frameworks

---

## 📫 Como contribuir

Pull requests são bem-vindos! Sinta-se à vontade para propor melhorias, ajustes ou abrir uma issue.

---

## 👨‍💻 Autor

- **Guilherme Figueiras Maurila**

[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)  
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

---

## 📂 Licença

Este projeto está licenciado sob a licença MIT.  
Sinta-se livre para usar em projetos comerciais ou educacionais.
