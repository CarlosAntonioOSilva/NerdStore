// Importa o namespace System, que contém classes fundamentais e base para o desenvolvimento de aplicativos em C#.
using System;

namespace NerdStore.Core.DomainObjects
{
    /*
      Esta classe irá compartilhar recursos que são comuns entre todos os contexto do domínio, como, 
      neste caso, uma identidade única para todas as entidades.!     
    */

    // Declaração de uma classe abstrata chamada Entity.
    // abstract - indica que a classe não pode ser instanciada, pode ser apenas herdada
    public abstract class Entity
    {
        // Declaração de uma propriedade pública do tipo Guid chamada Id.
        // Guid - significa "Guia"
        // Guid -  e um tipo de dado estruturado que garante uma identificação única/global de entidades ou instância de objetos
        public Guid Id { get; set; }

/*-------------------------------------------------------------------------------------------------------------------------------*/

        // Construtor protegido da classe Entity.
        // protected - indica que a classe só pode ser instância por outras classes que a herdam
        protected Entity()
        {
            // Atribui um novo Guid à propriedade Id quando um objeto da classe é instanciado.
            /* O objetivo deste construtor é (atribuir um novo Guid à propriedade Id) do objeto,
            garantindo que cada instância de Entity tenha um identificador único. */
            Id = Guid.NewGuid();
        }

/*-------------------------------------------------------------------------------------------------------------------------------*/

        /* 
         * substitui o método Equals da classe base Object.
         * usado para comparar se o objeto atual é igual a outro objeto passado como parâmetro
         * Equals = significa "Igualar" ou "É igual a"
         * override = indica que o método está sendo sobrescreve/re-escrito
        */
        public override bool Equals(object obj)
        {
            // Converte o objeto recebido para o tipo Entity e armazena em compareTo.
            var compareTo = obj as Entity;

            //ReferenceEquals - usado para comparar duas referências de objetos, verificando
            //se as duas referências apontam para o mesmo objeto na memória

            // Verifica se o objeto atual (this) é o mesmo que (compareTo).
            // se forem iguais, retorna true
            if (ReferenceEquals(this, compareTo)) return true;

            // Verifica se compareTo é nulo.
            // se for nulo, retorna false
            if (ReferenceEquals(null, compareTo)) return false;

            // Retorna a comparação entre os Ids dos objetos.
            return Id.Equals(compareTo.Id);
        }

/*-------------------------------------------------------------------------------------------------------------------------------*/

        /* 
         * Sobrecarga do operador de igualdade (==) para objetos Entity. 
         * Permite comparar duas instâncias de Entity para determinar se são iguais
         */
        public static bool operator == (Entity a, Entity b)
        {
            // Verifica se ambos os objetos são nulos.
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            // Verifica se um dos objetos é nulo.
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            // Chama o método Equals para comparar os objetos.
            // Chama o método Equals do objeto (a) para comparar (a) com (b)
            return a.Equals(b);

            // Se o método Equals retornar true, significa que os objetos a e b
            // são considerados iguais, e o método sobrecarregado de igualdade
            // também retorna true. Caso contrário, se o método Equals retornar
            // false, os objetos são considerados diferentes, e o método
            // sobrecarregado de igualdade também retorna false.
        }

/*-------------------------------------------------------------------------------------------------------------------------------*/

        // Sobrecarga do operador de desigualdade (!=) para objetos Entity.
        public static bool operator != (Entity a, Entity b)
        {
            // Retorna o resultado negado da comparação de igualdade.
            return !(a == b);
        }

/*-------------------------------------------------------------------------------------------------------------------------------*/

        // - Sobrescrita do método GetHashCode da classe base Object.
        // - É usado para calcular um código hash para o objeto.
        // - O código hash é usado em operações de busca, como em
        // coleções que utilizam hash, para melhorar a eficiência
        // na localização de objetos.'
        // O código hash gerado é baseado no tipo da entidade e no valor do Id.
        public override int GetHashCode()
        {
            /* 
             * Para que não aja chance de errar o hashcode que, por um caso, foi gerado 
             * igual, aqui, hashcode é multiplicado por um número aleatório (907) e somado
             * como o hashcode (Id) desta classe!
            */
            // Retorna um código hash baseado no tipo da entidade e no seu Id.
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

/*-------------------------------------------------------------------------------------------------------------------------------*/

        // Sobrescrita do método ToString da classe base Object.
        public override string ToString()
        {
            // Retorna uma string formatada com o nome do tipo da entidade e seu Id.
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}

/*
 
**Guid** - permite saber o valor do ID antes de persistir na base de dados!

**Entity - t**odo mundo que for uma entidade vai herdar da classe “Entity”!

**Equals** - é um método que toda classe/objeto possui!

**GetHashCode** - é como fosse um código exclusivo de uma classe. Neste caso, 
*como uma classe está sendo comparada com outra para verificar se são iguais ou não!

*/