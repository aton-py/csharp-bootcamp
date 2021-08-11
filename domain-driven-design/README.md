# Domain Driven Design

É uma abordagem de Design de software disciplinada que reúne um conjunto de conceitos, técnicas e princípios para construção de software baseados em um modelo de domínio

O livro escrito por Eric Evans é um grande catálogo de Padrões, baseaos em experiêcias do autor ao longo de mais de 20 anos de desenvolvimento de software utilizando técnicas de Orientação a Objetos.

## Principais conceitos

- Alinamento do código com o negócio:
    - O contato dos desenvolvedores, com os especialistas do domínio é algo essencial quando se faz DDD. Se faz necessário o uso de uma linguagem úbiqua para descrever o domínio e suas regras
- Favorecer a reutilização:
    - Os blocos de construção. Facilitam aproveitar um mesmo conceito de domínio ou um mesmo código em vários lugares
- Mínimo de acoplamento:
    - Com um modelo bem feito, as várias partes de um sistema interagem sem que haja muita dependêcia entre módulos ou classes de objetos de conceitos distintos
- Independência da Tecnologia:
    - DDD não foca em tecnologia, mas sim em entender as regras de negocio e como eas devem estar refletidas no código e no modelo de domínio. Não que a tecnologia usada não seja importante, mas essa não é uma preocupação de DDD

## Criando um Modelo de Domínio (MDD)

A idéia por trás de MDD é a de que seu modelo abstrat deve ser uma representação perfeita do seu domínio. Tudo que existe no seu negócio deve aparecer no modelo. Só aparece no modelo aquilo que está no negócio

O desenho do modelo é criado em conjunto entre especialistas de negócio e domínio, analistas, arquitetos e desenvolvedores, utilizando a linguagem úbiqua para que todos tenham o mesmo entendimento do domínio

O processo de maturação de um sistema desenvolvido usando MDD deve ser contínuo. O modelo servirá de guia para a criação do código e, ao mesmo tempo, o código ajuda a aperfeiçoar o modelo

## Blocos de Construção do MDD

Uma vez que decidimos criar um modelo usando MDD, precisamos inicialmente, isolar o modelo de domínio das demais partes que compôem o sistema. Essa separação pode ser feita utilizando-se uma arquitetura em camadas, que dividirá nossa aplicação em quatro partes:

- Interface do Usuário
- Aplicação
- Domínio
- Infra-estrutura

<img />

## Regras de Modelagem do Domínio

- Entidades:
    - Classes de objetos que necessitam de uma identidade. Normalmente são elementos do domínio que possuem ciclo de vida dentro de nossa aplicação.
- Objeto de Valores:
    - Objetos que só carregam valores, mas que não possuem distinção de identidade.
- Agregados:
    - Compostos de entidades ou objetos de valores que são encapsulado numa única classe. Agregado serve para manter a integridade do modelo. Elegemos uma classe para servir de raiz de agregado. Quando algum cliente quiser manipular dados de uma das classes que compõem o agregado, essa manipulação só poderá ser feita através da raiz