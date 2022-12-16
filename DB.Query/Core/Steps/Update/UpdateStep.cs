using DB.Query.Models.Entities;
using DB.Query.Core.Examples;
using DB.Query.Core.Services;
using DB.Query.Core.Steps.Base;
using System;
using System.Linq.Expressions;

namespace DB.Query.Core.Steps.Update
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class UpdateStep<TEntity> : UpdatePersistenceStep<TEntity>, IPersistenceStep where TEntity : EntityBase
    {
        /// <summary>
        ///     Responsável pela etapa de filtros da query
        ///     <para>
        ///       A expressão deve ter um resultado booleano, porém é de suma importância na comparação de propriedade evitar: associações, parses e funções que não foram tratadas. Tendo como exceção os paramêtros passados para a consulta.
        ///     </para>
        ///     <para><see href="https://github.com/LucasEvertonDev/DbQuery#readme">Consulte a documentação.</see></para>    
        ///     <para><see cref="InterpretService{TEntity}.AddWhere(Expression)">Navegue para o método de geração script.</see></para>
        /// </summary>
        /// <param name="expression">Parametro usado para indicar as condições da query.</param>
        /// <returns>
        ///     Retorno do tipo PersistenceStep, responsável por garantir o controle da próxima etapa. Impedindo que esse método seja novamente chamado na mesma operação.
        /// </returns>
        public UpdatePersistenceStep<TEntity> Where(Expression<Func<TEntity, bool>> expression = null)
        {
            return InstanceNextLevel<UpdatePersistenceStep<TEntity>>(_levelFactory.PrepareWhereStep(expression));
        }

        /// <summary>
        ///     Indica quais as colunas serão atualizadas na intrução de update
        ///     <para>ATENÇÃO!! O controle de quais entidades serão atualizadas deve ser realizado na condição WHERE!</para>
        ///     <para><see href="https://github.com/LucasEvertonDev/DbQuery#readme">Consulte a documentação.</see></para> 
        ///     <para><see cref="InterpretUpdateService{TEntity}.GenerateUpdateScript">Navegue para o método de geração script.</see></para>
        /// </summary>
        /// <param name="expression">Parametro usado para indicar as condições da query.</param>
        /// <returns>
        ///     Retorno do tipo PersistenceStep, responsável por garantir o controle da próxima etapa. Impedindo que esse método seja novamente chamado na mesma operação.
        /// </returns>
        public UpdateSetPersistenceStep<TEntity> SetCollumns(Expression<Func<TEntity, dynamic>> expression = null)
        {
            return InstanceNextLevel<UpdateSetPersistenceStep<TEntity>>(_levelFactory.PrepareUpdateSetStep(expression));
        }
    }
}
