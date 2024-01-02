# Sistema de gerenciamento de Workshop 🚀📊
___

## Contexto
Na FAST Soluções, trimestralmente, sempre às quintas-feiras das 16h às 17h, é
realizado um workshop sobre algum tema relacionado ao desenvolvimento de
software. Estes eventos são oportunidades para nossos colaboradores
aprenderem de forma descontraída e saírem um pouco da rotina. Apesar da
presença opcional, a maioria dos colaboradores comparece.
Recentemente, o comitê responsável pela organização desses workshops
expressou o desejo de aprofundar sua compreensão sobre os eventos, buscando
informações mais detalhadas. Com o objetivo de atender a essa demanda, a
proposta é utilizar métricas geradas para construir uma interface web. Essa
interface terá a capacidade de listar de maneira abrangente os detalhes de
cada workshop, atas de presença e a participação dos colaboradores. Essa
abordagem permitirá uma análise mais aprofundada e eficaz dos eventos,
proporcionando insights valiosos para o aprimoramento contínuo de nossas
iniciativas.ados por espaço.

## Overview
A plataforma envolve uma API Rest desenvolvida em .Net que é dividida em 3 camadas:
- Dominio🌐
- Persistencia🎲
- Aplicação📈
- API 🛜

Além disso, também possui uma aplicação Angular responsável pela camada de visualização com duas telas:
- Atas 📝
- Dashboards 📊

___

## Como utilizar

Primeiro nós precisamos executar nossa API e nosso banco de dados SQL Server:
- após executar o ```git clone```, dentro da pasta da Solution execute:
```
  docker-compose up
```

- Abra outro terminal e execute cada um dos 3 comandos e um de cada vez:
  ```
  cd workshop-app
  npm install
  ng serve
  ```
- Perfeito! Agora nós temos nosso gerenciador de Workshops funcionando!
  
