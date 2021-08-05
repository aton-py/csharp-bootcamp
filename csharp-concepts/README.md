### Principais conceitos organizacionais em C#

- Programas
- namespaces
- tipos
- membros
- assemblies

Os programas declaram tipos, que contêm membros e podem ser organizados em namespaces

Classes e interfaces são exemplos de tipos

Campos, métodos, propriedades e eventos são exemplos de membros

Quanto o programa é compilado, é empacotado em assemblies que geralmente sõ extensões .exe ou .dll a depender se são aplicações ou libs

### Tipos de Valor

Variáveis de tipos de valor contêm diretamente seus dados.

As variáveis têm sua própria cópia dos dados e não é possível que as operações afetem outra variável ( exceto no caso das variáveis de parâmetro Ref e Out )

Numéricos: sbyte, short, int, long, byte, ushort, uint, ulong

Caracteres Unicode: char

Pontos Flutuantes: float, double, decimal

Bool: bool

< enum, struct e tipos nullable ( int? nullish coalesing operator ) >

### Tipos de Referência

Variáveis de tipos de referência armazenam referências a seus dados

É possivel que duas variáveis façam referência ao mesmo objeto e, portanto, que operações em uma variável afetem o objeto referenciado pela outra variável

Tipos Classe: class, object, string

Tipos Arrays: []

< interface, delegate >

## Instruções

Ações de um programa que podem ser agrupadas em um contexto ou bloco ( escopo ) 

- Declaração de variáveis e constantes locais
- Instruções condicionais
    - if | swich
- Instruções de repetição
    - while | do | for | foreach
- Instruções auxiliáres
    - break | continue | return
- Instruções para tratativa de exceção
    - try | catch | finally
- Import de referencias
    - using

### Classes e Objetos em C#

Classe é o tipo mais fundamental em C#. É uma estrutura de dados que combina estado ( campos ) e ações ( métodos )

Objetos são instâncias de uma classe. As classes suportam herança e polimorfismo, mecanismos pelos quais as classes derivdas podem estender e especializar as classes base

```csharp
public class C
{
	public int x, y;
	public C( int x , int y )
	{
		this.x = x;
		this.y = y;
	}
}
```

Instâncias de classes ( objetos ) são criadas usando o operador new, que aloca memória para uma nova instância, chama um construtor para inicializar a nova instância e retorna a referência à instância

```csharp
C c1 = new C( 0 , 0);
C c2 = new C( 10, 20 );
```

A memória ocupada por um objeto é recuperada automaticamente quando o objeto não está mais acessível. Não é necessário nem possível desalocar explicitamente objetos em C# ( garbage colector )

### Membros

Os membros de uma classe podem ser **estáticos** ou membros da **instância**

Membros estáticos pertencem a classe e membros de instância pertencem ao objeto

Constantes, variáveis, métodos, propriedades, construtores, etc...

### Acessibilidade

Cada membro de uma classe tem uma acessibilidade associada, que controla as regiões do texto do programa que podem acessar o membro

- public - acessível em qualquer parte
- protected - acessível por herança
- internal - somente acessado no assembly que ele faz parte
- private - somente dentro da classe que está contido

### Herança

Uma delarção de classe pode especificar uma classe base, herdando os membros public, internal e protected da classe base.

Omitir uma especificação de casse base é o mesmo que derivar do tipo object.

### Métodos

Um método é um membro que implement uma computação ou ação que pode ser executada por um objeto ou classe

Os métodos podem ter uma lista de parâmetros, que representam valores ou referências de variáveis, que especifica o tipo do  valor calculado e retornado pelo método

Boa prática : método = verbo | props = substantivo

### Structs

Como as classes, as structs são estruturas de dados que podem conter membros de dados e membros de ação, mas diferentemente de classes, os structs são tipos de valor e não requerem alocação de heap 

Uma variável de um tipo de struct armazena diretamente os dados da estrutura, enquanto uma variavél de um tipo de classe armazena uma referência a um objeto alocado na memória

Structs não aceitam herança determinda pelo desenvolvedor

São úteis para pequenas estruturas de dados que possuem semântica de valor: números complexos, pontos em um sistema de coodenadas ou pares de chave-valor em um dicionário são bons exemplos de utilização

O uso de structs em vez de classes para pequenas estruturas de dados pode fazer uma grande diferença no número de alocações de memória

```csharp
public struct Ponto
{
	public int x, y;
	public Ponto( int x, int y )
	{
		this.x = x;
		this.y = y;
	}
}
```

Construtores de structs são chamados com o operador new, semelhante a um contrutor de classe, mas em vez de alocar dinamicamente um objeto no heap gerenciado e retornar uma referência a ele, um contrutor struct simplesmente retorna o próprio valor struct ( normalmente em um local temporário na stack ), e ese valor é copiado conforme necessário

 

### Interfaces

Uma interface define um contrato que pode ser implementado por classes e structs

Uma interface pode conter métodos, propriedades, eventos e indexadores

Uma interface não fornece implementações dos membros que define - apenas suas "assinaturas"

As interfaces podem empregar herança múltipla

```csharp
interface IControl
{
	void Paint();
}
interface IListBox
{
	void SetText(string text);
}
interface IComboBox: IControl, IListBox {}

interface IDataBound
{
	void Bind(Binder b);
}
public class EditBox: IComboBox, IDataBound
{
	public void Paint(){}
	public void SetText(string texxt) {}
	public void Bind(Binder b) {}
}

```

### Enums

Um enum é um tipo de valor distinto com um conjunto de constantes nomeados

Você define enumerações quando precisa definir um tipo que pode ter um conjunto de valores discretos. Eles usam um dos tipos de valor integral como armazenamento subjacente. eles fornecem significado semântico aos valores discretos

Cada tipo de enum possui um tipo integral correspondente chamado tipo subjacente do tipo de enum

Um tipo de enumeração que não declara explicitamente um tipo subjacente tem um tipo subjacente int